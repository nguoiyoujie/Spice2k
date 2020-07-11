using Primrose.Primitives.Factories;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors
{
  public class UibEditorControl : EditorControl
  {
    protected DataGridView _dgv;
    protected DataGridViewColumn[] _columns = new DataGridViewColumn[0];
    protected Registry<DataGridViewColumn, string[]> _comparers = new Registry<DataGridViewColumn, string[]>();

    public override bool SupportSearch { get { string[] keys = SearchKeys; return keys?.Length > 0; } }
    public override string[] SearchKeys 
    { 
      get 
      {
        if (_columns == null) { return null; }
        string[] keys = new string[_columns.Length];
        for(int i = 0; i < keys.Length; i++)
        {
          keys[i] = _columns[i].HeaderText;
        }
        return keys;
      } 
    }
    public override string[] GetSearchComparers(int index)
    {
      if (_dgv == null || index < 0 || index >= _dgv.Columns.Count)
      {
        return null;
      }
      return _comparers.Get(_dgv.Columns[index]);
    }

    public override string OpenFileFilter { get { return "Dune 2000 uib files|*.uib|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 uib files|*.uib|All files|*.*"; } }

    public override bool Search(int searchKeyIndex, int searchDirection, string comparer, string value)
    {
      if (_dgv == null || searchKeyIndex < 0 || searchKeyIndex >= _columns.Length)
      {
        return false;
      }
      return Search(_columns[searchKeyIndex], searchDirection, comparer, value);
    }
    protected virtual bool Search(DataGridViewColumn searchKeyColumn, int searchDirection, string comparer, string value) { return false; }
  }
}
