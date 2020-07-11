using Primrose.Primitives.ValueTypes;

namespace Dune2000.Editor.UI.Structs
{
  public struct PixelInfo<T>
  {
    public readonly int2 Position;
    public readonly T ColorInfo;

    public PixelInfo(int2 position, T color)
    {
      Position = position;
      ColorInfo = color;
    }
  }
}
