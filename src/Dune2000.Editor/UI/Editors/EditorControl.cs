using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors
{
  public class EditorControl : UserControl, IEditorControl
  {
    public virtual bool SupportSearch { get { return false; } }
    public virtual string[] SearchKeys { get { return null; } }
    public virtual string[] GetSearchComparers(int index) { return null; }

    public virtual string OpenFileFilter { get { return "All files|*.*"; } }
    public virtual string SaveFileFilter { get { return "All files|*.*"; } }

    public bool Dirty { get { return _dirty; } }
    public string OpenFilePath { get; set; }
    public string SaveFilePath { get; set; }
    public string CurrFilePath { get { return _path; } }

    public virtual bool LoadFile(string path) { return false; }
    public virtual bool SaveFile(string path) { return false; }
    public virtual void Unload() { }
    public virtual void Reload() { }

    public virtual bool Search(int searchKeyIndex, int searchDirection, string comparer, string value) { return false; }

    public UpdateDelegate<bool> DirtyChanged { get; set; }

    private bool __dirty = false;
    protected bool _dirty { get { return __dirty; } set { if (__dirty != value) { __dirty = value; DirtyChanged?.Invoke(__dirty); } } }
    protected string _path = "";

    protected override CreateParams CreateParams
    {
      get
      {
        var parms = base.CreateParams;
        parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
        return parms;
      }
    }
  }
}
