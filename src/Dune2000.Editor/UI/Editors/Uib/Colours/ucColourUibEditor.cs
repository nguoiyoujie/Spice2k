using System;
using System.Drawing;
using System.Windows.Forms;
using Dune2000.Editor.UI.Objects;
using Dune2000.FileFormats.Uib;
using Primrose.Primitives.Extensions;

namespace Dune2000.Editor.UI.Editors.Uib.Colours
{
  public partial class ucColourUibEditor : UibEditorControl
  {
    public ucColourUibEditor()
    {
      InitializeComponent();
      _dgv = dgvTable;
      _comparers.Default = new string[] { MATCH, CONTAINS, MATCH_IGNORECASE, CONTAINS_IGNORECASE };
      panel1.Enabled = false;
    }

    private const string MATCH = "Match";
    private const string CONTAINS = "Contains";
    private const string MATCH_IGNORECASE = "Match (Ignore case)";
    private const string CONTAINS_IGNORECASE = "Contains (Ignore case)";

    private ColourUibFile _uib = null;

    public override object[] SearchKeys { get { return new DataGridViewColumn[] { DcKey }; } }
    public override string OpenFileFilter { get { return "Colours uib files|colours*.uib|Dune 2000 uib files|*.uib|All files|*.*"; } }
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
      foreach (UibEntry<Color> entry in _uib.Entries)
      {
        int index = dgvTable.Rows.Add(entry.Key, "");
        dgvTable.Rows[index].Cells[DcColor.Name] = new DataColorCell(entry.Value);
      }
      _dirty = false;
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        ColourUibFile uib = new ColourUibFile();
        uib.ReadFromFile(path);
        _uib = uib;
        _dirty = false;
        _path = path;
        return true;
      }
      catch
      {
        MessageBox.Show("The file is not a valid colour uib file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      ColourUibFile uib = new ColourUibFile();
      uib.Entries.Clear();
      foreach (DataGridViewRow dataRow in dgvTable.Rows)
      {
        string key = dataRow.Cells[DcKey.Name].Value?.ToString() ?? "";
        uib.Entries.Add(new UibEntry<Color>(key, dataRow.Cells[DcColor.Name].Value as Color? ?? Color.Black));
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

    private void DgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == DcColor.Index && e.RowIndex > -1 && e.RowIndex < dgvTable.Rows.Count)
      {
        dColor.Color = dgvTable.Rows[e.RowIndex].Cells[DcColor.Name].Style.BackColor;
        if (dColor.ShowDialog() == DialogResult.OK)
        {
          dgvTable.Rows[e.RowIndex].Cells[DcColor.Name] = new DataColorCell(dColor.Color);
          _dirty = true;
        }
      }
    }
  }
}
