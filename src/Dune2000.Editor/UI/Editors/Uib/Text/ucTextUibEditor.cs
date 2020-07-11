using System;
using System.Windows.Forms;
using Dune2000.FileFormats.Uib;
using Primrose.Primitives.Extensions;

namespace Dune2000.Editor.UI.Editors.Uib.Text
{
  public partial class ucTextUibEditor : UibEditorControl
  {
    public ucTextUibEditor()
    {
      InitializeComponent();
      _dgv = dgvTable;
      _columns = new DataGridViewColumn[] { DcKey, DcValue };
      _comparers.Default = new string[] { MATCH, CONTAINS, MATCH_IGNORECASE, CONTAINS_IGNORECASE };
      panel1.Enabled = false;
    }

    private const string MATCH = "Match";
    private const string CONTAINS = "Contains";
    private const string MATCH_IGNORECASE = "Match (Ignore case)";
    private const string CONTAINS_IGNORECASE = "Contains (Ignore case)";

    private TextUibFile _uib = null;

    public override string OpenFileFilter { get { return "Text uib files|*text*.uib;samples.uib|Dune 2000 uib files|*.uib|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 uib files|*.uib|All files|*.*"; } }

    public override void Unload()
    {
      dgvTable.Rows.Clear();
      _uib = null;
      _dirty = false;
      _path = null;
      panel1.Enabled = false;
    }

    public override void Reload()
    {
      if (_uib == null) { return; }
      dgvTable.Rows.Clear();
      foreach (UibEntry<string> entry in _uib.Entries)
      {
        dgvTable.Rows.Add(entry.Key, entry.Value);
      }
      _dirty = false;
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        TextUibFile uib = new TextUibFile();
        uib.ReadFromFile(path);
        _uib = uib;
        _dirty = false;
        _path = path;
        return true;
      }
      catch
      {
        MessageBox.Show("The file is not a valid text uib file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      TextUibFile uib = new TextUibFile();
      uib.Entries.Clear();
      foreach (DataGridViewRow dataRow in dgvTable.Rows)
      {
        string key = dataRow.Cells[DcKey.Name].Value?.ToString() ?? "";
        string val = dataRow.Cells[DcValue.Name].Value?.ToString() ?? "";
        uib.Entries.Add(new UibEntry<string>(key, val));
      }
      uib.WriteToFile(path);
      _uib = uib;
      _dirty = false;
      _path = path;
      return true;
    }

    protected override bool Search(DataGridViewColumn searchColumn, int searchDirection, string comparer, string value)
    {
      try
      {
        searchDirection = searchDirection >= 0 ? 1 : -1;
        for (int cursor = dgvTable.CurrentRow == null ? 0 : dgvTable.CurrentRow.Index + searchDirection;
             cursor >= 0 && cursor < dgvTable.Rows.Count;
             cursor += searchDirection)
        {
          string s = dgvTable.Rows[cursor].Cells[searchColumn.Name].Value?.ToString();
          bool matched = false;

          switch (comparer)
          {
            case MATCH:
              matched = string.Equals(s, value, StringComparison.Ordinal);
              break;

            case MATCH_IGNORECASE:
              matched = string.Equals(s, value, StringComparison.OrdinalIgnoreCase);
              break;

            case CONTAINS:
              matched = s != null && s.Contains(value);
              break;

            case CONTAINS_IGNORECASE:
              matched = s != null && s.ToLower().Contains(value.ToLower());
              break;

            default:
              // comparing to what?
              return false;
          }

          if (matched)
          { 
            dgvTable.Rows[cursor].Cells[searchColumn.Name].Selected = true;
            dgvTable.CurrentCell = dgvTable.Rows[cursor].Cells[searchColumn.Name];
            dgvTable.Focus();
            return true;
          }
        }
        return false;
      }
      catch (Exception e)
      {
        MessageBox.Show("Error encountered finding match\n\n{0}: {1}\n\nStack Trace:\n{2}".F(e.GetType(), e.Message, e.StackTrace), "Dune 2000 Editor");
        return false;
      }
    }

    private void DgvTable_CellValueChanged(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex > -1) _dirty = true; }
  }
}
