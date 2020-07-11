using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Primrose.Primitives.Extensions;

namespace Dune2000.Editor.UI.Editors
{
  public partial class ucEditorController : UserControl
  {
    public ucEditorController()
    {
      InitializeComponent();
    }

    private IEditorControl _editor = null;

    public UpdateDelegate<IEditorControl> EditorChanged;

    public void SetEditor(IEditorControl editor)
    {
      try
      {
        _editor = editor;
        tsbSearch.Visible = editor.SupportSearch;
        tscbKeyValue.Items.Clear();
        object[] skeys = editor.SearchKeys;
        if (skeys != null)
        {
          tscbKeyValue.Items.AddRange(skeys);
        }

        dOpen.Filter = editor.OpenFileFilter;
        dSave.Filter = editor.SaveFileFilter;
        UpdateFileTitle();
        UpdateSearchBarVisibility();
        editor.DirtyChanged = _ => { UpdateFileTitle(); };
        if (_editor is Control c) { c.Enabled = true; }

        EditorChanged?.Invoke(editor);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered when setting up editor '{0}'.\n\nException: {1}\nMessage: {2}".F(_editor.GetType().Name, e.GetType(), e.Message), "Dune 2000 Editor", MessageBoxButtons.OK);
        _editor = null;
      }
    }

    private bool _visibleSearch = false;

    private void Open()
    {
      if (_editor == null) { return; }
      if (!CheckChange()) { return; }

      dOpen.FileName = Path.GetFileName(_editor.OpenFilePath);
      dOpen.InitialDirectory = Path.GetDirectoryName(_editor.OpenFilePath);
      if (dOpen.ShowDialog() != DialogResult.OK) { return; }

      _editor.OpenFilePath = dOpen.FileName;
      try
      {
        if (_editor.LoadFile(dOpen.FileName))
        {
          Reload();
          UpdateFileTitle();
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered when loading {0}.\n\nException: {1}\nMessage: {2}".F(dOpen.FileName, e.GetType(), e.Message), "Dune 2000 Editor", MessageBoxButtons.OK);
      }
    }

    public bool Unload()
    {
      if (!CheckChange()) { return false; }
      _editor.Unload();
      UpdateFileTitle();
      return true;
    }

    private void Reload()
    {
      this.SuspendDrawing();
      _editor.Reload();
      this.ResumeDrawing();
    }

    private bool Save(bool saveAs)
    {
      string path = _editor.CurrFilePath;

      if (saveAs || path == null || !File.Exists(path))
      {
        dSave.FileName = Path.GetFileName(_editor.SaveFilePath);
        dSave.InitialDirectory = Path.GetDirectoryName(_editor.SaveFilePath);
        if (dSave.ShowDialog() != DialogResult.OK) { return false; }
        path = dSave.FileName;
      }
      try
      {
        _editor.SaveFilePath = path;
        _editor.SaveFile(path);
        UpdateFileTitle();
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered when saving {0}.\n\nException: {1}\nMessage: {2}".F(path, e.GetType(), e.Message), "Dune 2000 Editor", MessageBoxButtons.OK);
        return false;
      }
      return true;
    }

    private bool CheckChange()
    {
      string path = _editor.CurrFilePath;
      if (_editor.Dirty && path != null)
      {
        switch (MessageBox.Show("You have unsaved changes on {0}.\nDo you want to save before closing?".F(path), "Dune 2000 Editor", MessageBoxButtons.YesNoCancel))
        {
          case DialogResult.Yes:
            return Save(false);

          case DialogResult.No:
            return true;

          default:
            return false;
        }
      }
      return true;
    }

    private void Search(int searchDirection)
    {
      try
      {
        if (!_editor.Search(tscbKeyValue.SelectedIndex, searchDirection, tscbComparer.Text, tstbSearch.Text))
        {
          MessageBox.Show("No match found.", "Dune 2000 Editor");
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered finding match\n\n{0}: {1}\n\nStack Trace:\n{2}".F(e.GetType(), e.Message, e.StackTrace), "Dune 2000 Editor");
      }
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e) { Open(); }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e) { Save(false); }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) { Save(true); }

    private void ReloadToolStripMenuItem_Click(object sender, EventArgs e) { Reload(); }

    private void UnloadToolStripMenuItem_Click(object sender, EventArgs e) { Unload(); }

    private void TsmiSearchPrev_Click(object sender, EventArgs e) { Search(-1); }
  
    private void TsmiSearchNext_Click(object sender, EventArgs e) { Search(1); }

    private void TsmiSearch_Click(object sender, EventArgs e)
    {
      _visibleSearch = !_visibleSearch;
      UpdateSearchBarVisibility();
    }

    private void UpdateSearchBarVisibility()
    {
      tsSearch.Visible = _visibleSearch && tsbSearch.Visible;
      tsbSearch.BackColor = tsSearch.Visible ? SystemColors.ActiveCaption : SystemColors.Control;
    }

    private void UpdateFileTitle()
    {
      if (_editor == null) { return; }

      lblFileName.Text = _editor.CurrFilePath;
      lblFileName.BackColor = GetFileTitleColor(_editor);
    }

    public static Color GetFileTitleColor(IEditorControl editor)
    {
      if (string.IsNullOrEmpty(editor.CurrFilePath))
      {
        return SystemColors.Control;
      }
      else if (editor.Dirty)
      {
        return Color.DarkSeaGreen;
      }
      else
      {
        return SystemColors.MenuHighlight;
      }
    }

    private void SearchOptionsChanged(object sender, EventArgs e)
    {
      bool valid = tscbKeyValue.SelectedIndex != -1
                && tscbComparer.SelectedIndex != -1
                && tstbSearch.Text.Length > 0;
      tsbSearchPrev.Enabled = valid;
      tsbSearchNext.Enabled = valid;
    }

    private void SearchColumnChanged(object sender, EventArgs e)
    {
      try
      {
        List<string> cmplist = new List<string>(_editor.GetSearchComparers(tscbKeyValue.SelectedIndex));
        if (!cmplist.Contains(tscbComparer.Text))
        {
          tscbComparer.Items.Clear();
          tscbComparer.Items.AddRange(cmplist.ToArray());
        }
        SearchOptionsChanged(sender, e);
      }
      catch
      {
        tscbKeyValue.Items.Clear();
        tsbSearchPrev.Enabled = false;
        tsbSearchNext.Enabled = false;
      }
    }
  }
}
