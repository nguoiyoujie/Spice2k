namespace Dune2000.FileFormats.Uib
{
  public readonly struct UibEntry<T>
  {
    public readonly string Key;
    public readonly T Value;

    public UibEntry(string key, T value)
    {
      Key = key;
      Value = value;
    }
  }
}
