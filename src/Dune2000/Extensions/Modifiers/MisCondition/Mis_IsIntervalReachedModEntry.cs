using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_IsIntervalReachedModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public uint? InitialDelay;
    public uint? Time;
    public uint? RunCount;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (InitialDelay == null || RunCount == null)
        if (existing.Condition != ConditionType.INTERVAL)
          throw new InvalidOperationException("The original condition ({0}) was not an interval condition. The initial delay and run count must be specified.".F(existing.Condition));

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
        InitialDelay = InitialDelay ?? old.InitialDelay,
        Time = Time ?? old.Time,
        Value = RunCount ?? old.Value
      };
    }
  }

}
