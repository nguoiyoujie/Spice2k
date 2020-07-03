using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_IsTimerReachedModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public Compare? Compare;
    public uint? Time;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Compare == null)
        if (existing.Condition != ConditionType.TIMER)
          throw new InvalidOperationException("The original condition ({0}) was not a timer condition. The comparer must be specified.".F(existing.Condition));

      if (Time == null)
        if (!existing.Condition.RequiresTime())
          throw new InvalidOperationException("The original condition ({0}) did not have a time defined. A time must be specified.".F(existing.Condition));
    }

    public override void Write(ref MisCondition condition)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisCondition old = condition;

      condition = new MisCondition
      {
        Condition = ConditionType.TIMER,
        Compare = Compare ?? old.Compare,
        Time = Time ?? old.Time
      };
    }
  }

}
