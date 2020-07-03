using Dune2000.FileFormats.Map;
using Primrose.FileFormat.INI;
using Primrose.Primitives.Factories;
using Primrose.Primitives.ValueTypes;

namespace Dune2000.Extensions.Modifiers
{
  public struct MapModInfo
  {
    [INIHeader]
    public string Name;

    [INIRegistry(Required = true)]
    public Registry<uint2, ushort> Changes;

    public ModEntry<MapFile> CreateEntry(bool tile)
    {
      if (tile)
      {
        Map_TileReplacementModEntry tilrpl = new Map_TileReplacementModEntry
        {
          Changes = Changes
        };
        return tilrpl;
      }
      else
      {
        Map_ObjectReplacementModEntry objrpl = new Map_ObjectReplacementModEntry
        {
          Changes = Changes
        };
        return objrpl;
      }
    }
  }
}
