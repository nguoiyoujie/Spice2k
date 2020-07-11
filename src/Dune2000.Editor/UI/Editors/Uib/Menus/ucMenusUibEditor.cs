using System;
using System.Windows.Forms;
using Dune2000.Enums;
using Dune2000.FileFormats.Uib;
using Dune2000.Structs.Uib;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;

namespace Dune2000.Editor.UI.Editors.Uib.Menus
{
  public partial class ucMenusUibEditor : UibEditorControl
  {
    public ucMenusUibEditor()
    {
      InitializeComponent();
      _dgv = dgvTable;
      _comparers.Default = new string[] { MATCH, CONTAINS, MATCH_IGNORECASE, CONTAINS_IGNORECASE };

      // translate the strings to values
      _fade.Add("0: Fade from Black", FadeAction.FADE_FROMBLACK);
      _fade.Add("1: Fade to Black", FadeAction.FADE_TOBLACK);
      _fade.Add("2: Tween", FadeAction.TWEEN);
      _fade.Add("3: Don't Fade", FadeAction.SKIP);

      // translate the values to strings
      foreach (string s in _fade.GetKeys()) { _fadeStr.Add(_fade[s], s); }

      DcFadeIn.Items.Clear();
      DcFadeOut.Items.Clear();

      DcFadeIn.Items.AddRange(_fade.GetKeys());
      DcFadeOut.Items.AddRange(_fade.GetKeys());
      panel1.Enabled = false;
    }

    private const string MATCH = "Match";
    private const string CONTAINS = "Contains";
    private const string MATCH_IGNORECASE = "Match (Ignore case)";
    private const string CONTAINS_IGNORECASE = "Contains (Ignore case)";

    private readonly Registry<string, FadeAction> _fade = new Registry<string, FadeAction>();
    private readonly Registry<FadeAction, string> _fadeStr = new Registry<FadeAction, string>();
    private MenusUibFile _uib = null;

    public override object[] SearchKeys { get { return new DataGridViewColumn[] { DcKey }; } }
    public override string OpenFileFilter { get { return "Menu uib files|menus*.uib|Dune 2000 uib files|*.uib|All files|*.*"; } }
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
      foreach (UibEntry<MenusUibData> entry in _uib.Entries)
      {
        string fadein = _fadeStr.Get(entry.Value.FadeIn);
        string fadeout = _fadeStr.Get(entry.Value.FadeOut);
        dgvTable.Rows.Add(entry.Key, entry.Value.Menu, fadein, fadeout);
      }
      _dirty = false;
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        MenusUibFile uib = new MenusUibFile();
        uib.ReadFromFile(path);
        _uib = uib;
        _dirty = false;
        _path = path;
        return true;
      }
      catch
      {
        MessageBox.Show("The file is not a valid menu uib file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      MenusUibFile uib = new MenusUibFile();
      uib.Entries.Clear();
      foreach (DataGridViewRow dataRow in dgvTable.Rows)
      {
        string key = dataRow.Cells[DcKey.Name].Value?.ToString() ?? "";
        string val = dataRow.Cells[DcMenu.Name].Value?.ToString() ?? "";
        FadeAction fadein = _fade.Get(dataRow.Cells[DcFadeIn.Name].Value?.ToString() ?? "");
        FadeAction fadeout = _fade.Get(dataRow.Cells[DcFadeOut.Name].Value?.ToString() ?? "");

        uib.Entries.Add(new UibEntry<MenusUibData>(key, new MenusUibData(val, fadein, fadeout)));
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
