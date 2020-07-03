using Dune2000.FileFormats.Map;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public abstract class MapModEntry : ModEntry<MapFile>
  {
    public Registry<uint2, ushort> Changes = new Registry<uint2, ushort>();

    public override void Apply(ref MapFile target)
    {
      CheckValueIntegrity(ref target);
      Write(ref target);
    }

    public virtual void CheckValueIntegrity(ref MapFile target)
    {
      foreach (uint2 pos in Changes.GetKeys())
      {
        if (pos.x != pos.x.Clamp(0u, target.Width - 1u))
          throw new InvalidOperationException("The target location ({0}) of the modification is not within the width ({1}) of the map!".F(pos, target.Width));

        if (pos.y != pos.y.Clamp(0u, target.Height - 1u))
          throw new InvalidOperationException("The target location ({0}) of the modification is not within the height ({1}) of the map!".F(pos, target.Height));
      }
    }

    public abstract void Write(ref MapFile target);
  }
}
