using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public abstract class MisActionModEntry : ModEntry<MisFile>
  {
    public int Index = -1;

    public override void Apply(ref MisFile target)
    {
      CheckValueIntegrity(ref target);
      CheckCompatibility(ref target.Actions[Index]);
      Write(ref target.Actions[Index]);
    }

    public virtual void CheckValueIntegrity(ref MisFile target)
    {
      if (Index != Index.Clamp(0, MisFile.MAX_ACTIONS))
        throw new InvalidOperationException("Invalid action index ({0}): Only mission indexes up to {1} is supported.".F(Index, MisFile.MAX_ACTIONS));

      if (Index != Index.Clamp(0, target.ActionCount))
        throw new InvalidOperationException("Invalid action index ({0}): The mission has set its number of actions to {1}.".F(Index, target.ActionCount));
    }

    public virtual void CheckCompatibility(ref MisAction existing) { }

    public abstract void Write(ref MisAction action);
  }
}
