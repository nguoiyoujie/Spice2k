using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_HasCasualitiesModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public float? Ratio;
    public uint? Minimum;
    public House? House;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Ratio == null || Minimum == null)
        if (existing.Condition != ConditionType.CASUALTIES)
          throw new InvalidOperationException("The original condition ({0}) was not a casuality condition. The minimum loss and ratio must be specified.".F(existing.Condition));

      if (House == null)
        if (!existing.Condition.RequiresHouse())
          throw new InvalidOperationException("The original condition ({0}) did not have a house defined. A house must be specified.".F(existing.Condition));
    }

    public override void Write(ref MisCondition condition)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisCondition old = condition;

      condition = new MisCondition
      {
        Condition = ConditionType.UNITEXISTS,
        House = House ?? old.House,
        Value = Minimum ?? old.Value,
        Ratio = Ratio ?? old.Ratio
      };
    }
  }

}
