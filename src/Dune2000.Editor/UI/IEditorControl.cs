using Primrose.Primitives.Factories;
using System.Windows.Forms;

namespace Dune2000.Editor.UI
{
  public interface IEditorControl
  {
    bool SupportSearch { get; }
    object[] SearchKeys { get; }
    string[] GetSearchComparers(int index);

    string OpenFileFilter { get; }
    string SaveFileFilter { get; }

    bool LoadFile(string path);
    bool SaveFile(string path);
    void Unload();
    void Reload();

    bool Dirty { get; }

    bool Search(int searchKeyIndex, int searchDirection, string comparer, string value);
  }

  public class EditorControl : UserControl, IEditorControl
  {
    public virtual bool SupportSearch { get { return false; } }
    public virtual object[] SearchKeys { get { return null; } }
    public virtual string[] GetSearchComparers(int index) { return null; }

    public virtual string OpenFileFilter { get { return "All files|*.*"; } }
    public virtual string SaveFileFilter { get { return "All files|*.*"; } }

    public bool Dirty { get { return _dirty; } }

    public virtual bool LoadFile(string path) { return false; }
    public virtual bool SaveFile(string path) { return false; }
    public virtual void Unload() { }
    public virtual void Reload() { }

    public virtual bool Search(int searchKeyIndex, int searchDirection, string comparer, string value) { return false; }

    protected bool _dirty = false;
  }

  public class UIBEditorControl : EditorControl
  {
    protected DataGridView _dgv;
    protected DataGridViewColumn[] _columns = new DataGridViewColumn[0];
    protected Registry<DataGridViewColumn, string[]> _comparers = new Registry<DataGridViewColumn, string[]>();

    public override bool SupportSearch { get { object[] keys = SearchKeys; return keys?.Length > 0; } }
    public override object[] SearchKeys { get { return _columns; } }
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
      if (_dgv == null || searchKeyIndex < 0 || searchKeyIndex >= _dgv.Columns.Count)
      {
        return false;
      }
      return Search(_dgv.Columns[searchKeyIndex], searchDirection, comparer, value); 
    }
    protected virtual bool Search(DataGridViewColumn searchKeyColumn, int searchDirection, string comparer, string value) { return false; }
  }
}
