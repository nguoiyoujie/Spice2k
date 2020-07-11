namespace Dune2000.Editor.UI.Editors
{
  public interface IEditorControl
  {
    bool SupportSearch { get; }
    string[] SearchKeys { get; }
    string[] GetSearchComparers(int index);

    string OpenFileFilter { get; }
    string SaveFileFilter { get; }

    bool LoadFile(string path);
    bool SaveFile(string path);
    void Unload();
    void Reload();

    bool Dirty { get; }
    string OpenFilePath { get; set; }
    string SaveFilePath { get; set; }
    string CurrFilePath { get; }

    bool Search(int searchKeyIndex, int searchDirection, string comparer, string value);

    UpdateDelegate<bool> DirtyChanged { get; set; }
  }
}
