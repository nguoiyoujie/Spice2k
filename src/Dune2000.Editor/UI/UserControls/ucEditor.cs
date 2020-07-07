using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;

namespace Dune2000.Editor.UI.UserControls
{
  public partial class ucEditor : UserControl
  {
    public ucEditor()
    {
      InitializeComponent();
    }

    private IEditorControl _editor = null;

    public void SetEditor(IEditorControl editor)
    {
      try
      {
        _editor = editor;
        Path = "";
        tsmiSearch.Visible = editor.SupportSearch;
        dOpen.Filter = editor.OpenFileFilter;
        dSave.Filter = editor.SaveFileFilter;
        UpdateSearchBarVisibility();
        if (_editor is Control c) { c.Enabled = true; }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered when setting up editor '{0}'.\n\nException: {1}\nMessage: {2}".F(_editor.GetType().Name, e.GetType(), e.Message), "Dune 2000 Editor", MessageBoxButtons.OK);
        _editor = null;
      }
    }

    protected string Path { get { return _path; } set { if (_path != value) { _path = value; lblFileName.Text = _path; } } }
    private string _path = null;
    private bool _visibleSearch = false;

    private void Open()
    {
      if (_editor == null) { return; }
      if (!CheckChange()) { return; }
      if (dOpen.ShowDialog() != DialogResult.OK) { return; }

      try
      {
        if (_editor.LoadFile(dOpen.FileName))
        {
          Reload();
          Path = dOpen.FileName;
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
      Path = null;
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
      if (saveAs || Path == null || !File.Exists(Path))
      {
        if (dSave.ShowDialog() != DialogResult.OK) { return false; }
        Path = dSave.FileName;
      }
      try
      {
        _editor.SaveFile(Path);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered when saving {0}.\n\nException: {1}\nMessage: {2}".F(Path, e.GetType(), e.Message), "Dune 2000 Editor", MessageBoxButtons.OK);
        return false;
      }
      return true;
    }

    private bool CheckChange()
    {
      if (_editor.Dirty && Path != null)
      {
        switch (MessageBox.Show("You have unsaved changes on {0}.\nDo you want to save before closing?".F(Path), "Dune 2000 Editor", MessageBoxButtons.YesNoCancel))
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
      menuSearchBar.Visible = _visibleSearch && tsmiSearch.Visible;
      tsmiSearch.BackColor = menuSearchBar.Visible ? SystemColors.ActiveCaption : SystemColors.Control;
    }

    private void SearchOptionsChanged(object sender, EventArgs e)
    {
      bool valid = tscbKeyValue.SelectedIndex != -1
                && tscbComparer.SelectedIndex != -1
                && tstbSearch.Text.Length > 0;
      tsmiSearchPrev.Enabled = valid;
      tsmiSearchNext.Enabled = valid;
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
        tsmiSearchPrev.Enabled = false;
        tsmiSearchNext.Enabled = false;
      }
    }
  }
}
