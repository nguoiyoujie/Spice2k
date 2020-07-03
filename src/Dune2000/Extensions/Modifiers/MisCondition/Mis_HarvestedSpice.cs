using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_HarvestedSpice : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public uint? Value;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Value == null)
        if (!existing.Condition.RequiresValue())
          throw new InvalidOperationException("The original condition ({0}) did not have a value defined. A value must be specified.".F(existing.Condition));
    }

    public override void Write(ref MisCondition condition)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisCondition old = condition;

      condition = new MisCondition
      {
        Condition = ConditionType.HARVESTED,
        Value = Value ?? old.Value,
      };
    }
  }

}
