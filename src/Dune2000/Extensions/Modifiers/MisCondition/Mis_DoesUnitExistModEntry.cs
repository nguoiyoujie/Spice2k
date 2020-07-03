using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_DoesUnitExistModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public Unit? Unit;
    public House? House;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Unit == null)
        if (existing.Condition != ConditionType.UNITEXISTS)
          throw new InvalidOperationException("The original condition ({0}) was not a unit exist condition. The unit must be specified.".F(existing.Condition));

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
        Unit = Unit ?? old.Unit,
      };
    }
  }

}
