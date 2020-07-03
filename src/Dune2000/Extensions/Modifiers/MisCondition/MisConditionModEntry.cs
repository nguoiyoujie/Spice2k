using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public abstract class MisConditionModEntry : ModEntry<MisFile>
  {
    public int Index = -1;

    public override void Apply(ref MisFile target)
    {
      CheckValueIntegrity(ref target);
      CheckCompatibility(ref target.Conditions[Index]);
      Write(ref target.Conditions[Index]);
    }

    public virtual void CheckValueIntegrity(ref MisFile target)
    {
      if (Index != Index.Clamp(0, MisFile.MAX_CONDITIONS))
        throw new InvalidOperationException("Invalid condition index ({0}): Only mission indexes up to {1} is supported.".F(Index, MisFile.MAX_CONDITIONS));

      if (Index != Index.Clamp(0, target.ConditionCount))
        throw new InvalidOperationException("Invalid condition index ({0}): The mission has set its number of conditions to {1}.".F(Index, target.ConditionCount));
    }

    public virtual void CheckCompatibility(ref MisCondition existing) { }

    public abstract void Write(ref MisCondition action);
  }
}
