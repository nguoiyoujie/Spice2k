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

    protected bool SupportSearch { get { return tsmiSearch.Visible; } set { tsmiSearch.Visible = value; } }
    protected string Path { get { return _path; } set { if (_path != value) { _path = value; lblFileName.Text = _path; } } }
    protected bool _changed = false;
    private string _path = null;
    private DataGridViewColumn[] _columns = new DataGridViewColumn[0];
    private Registry<DataGridViewColumn, string[]> _comparers = new Registry<DataGridViewColumn, string[]>();

    private void Open()
    {
      if (!CheckChange()) { return; }
      if (dOpen.ShowDialog() != DialogResult.OK) { return; }

      try
      {
        if (LoadFile(dOpen.FileName))
        {
          Reload();
          Path = dOpen.FileName;
          _changed = false;
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
      UnloadInner();
      Path = null;
      _changed = false;
      return true;
    }

    private void Reload()
    {
      this.SuspendDrawing();
      ReloadInner();
      this.ResumeDrawing();
      _changed = false;
    }

    protected virtual void UnloadInner() { }
    protected virtual void ReloadInner() { }
    protected virtual bool LoadFile(string path) { return false; }
    protected virtual void SaveFile(string path) { }

    private bool Save(bool saveAs)
    {
      if (saveAs || Path == null || !File.Exists(Path))
      {
        if (dSave.ShowDialog() != DialogResult.OK) { return false; }
        Path = dSave.FileName;
      }
      try
      {
        SaveFile(Path);
        _changed = false;
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
      if (_changed && Path != null)
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

    protected void SetSearchColumns(params DataGridViewColumn[] columns)
    {
      tscbKeyValue.Items.Clear();
      foreach (DataGridViewColumn column in columns)
      {
        tscbKeyValue.Items.Add(column.HeaderText);
      }
      _columns = (DataGridViewColumn[])columns.Clone();
    }

    protected void SetSearchComparers(params string[] options)
    {
      _comparers.Default = (string[])options.Clone();
    }

    protected void SetSearchComparers(DataGridViewColumn column, params string[] options)
    {
      _comparers.Put(column, (string[])options.Clone());
    }

    private void Search(int searchDirection)
    {
      DataGridViewColumn SearchColumn = _columns[tscbKeyValue.SelectedIndex];
      try
      {
        if (!Search(SearchColumn, searchDirection, tscbComparer.Text, tstbSearch.Text))
        {
          MessageBox.Show("No match found.", "Dune 2000 Editor");
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered finding match\n\n{0}: {1}\n\nStack Trace:\n{2}".F(e.GetType(), e.Message, e.StackTrace), "Dune 2000 Editor");
      }
    }

    protected virtual bool Search(DataGridViewColumn searchColumn, int searchDirection, string comparer, string value) { return false; }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e) { Open(); }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e) { Save(false); }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) { Save(true); }

    private void ReloadToolStripMenuItem_Click(object sender, EventArgs e) { Reload(); }

    private void UnloadToolStripMenuItem_Click(object sender, EventArgs e) { Unload(); }

    private void TsmiSearchPrev_Click(object sender, EventArgs e) { Search(-1); }
  
    private void TsmiSearchNext_Click(object sender, EventArgs e) { Search(1); }

    private void TsmiSearch_Click(object sender, EventArgs e)
    {
      menuSearchBar.Visible = !menuSearchBar.Visible;
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
        DataGridViewColumn c = _columns[tscbKeyValue.SelectedIndex];
        List<string> cmplist = new List<string>(_comparers.Get(c));
        if (!cmplist.Contains(tscbComparer.Text))
        {
          tscbComparer.Items.Clear();
          tscbComparer.Items.AddRange(_comparers.Get(c));
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
