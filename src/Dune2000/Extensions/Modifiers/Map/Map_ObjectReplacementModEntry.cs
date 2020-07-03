using Dune2000.FileFormats.Map;
using Primrose.Primitives.ValueTypes;

namespace Dune2000.Extensions.Modifiers
{
  public class Map_ObjectReplacementModEntry : MapModEntry
  {
    public override void Write(ref MapFile target)
    {
      foreach (uint2 pos in Changes.GetKeys())
      {
        ushort val = Changes[pos];
        target.ObjectIndex[pos.x, pos.y] = val;
      }
    }
  }
}
