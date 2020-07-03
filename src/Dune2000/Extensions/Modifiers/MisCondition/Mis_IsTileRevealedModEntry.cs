using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_IsTileRevealedModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public uint2? Position;
    public uint Unknown = 1;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Position == null)
        if (!existing.Condition.RequiresPosition())
          throw new InvalidOperationException("The original condition ({0}) did not have a position defined. A position must be specified.".F(existing.Condition));
    }

    public override void Write(ref MisCondition condition)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisCondition old = condition;

      condition = new MisCondition
      {
        Condition = ConditionType.REVEALED,
        Position = Position ?? old.Position,
        Value = Unknown,
      };
    }
  }

}
