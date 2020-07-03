using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_DoesBuildingExistModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public Building? Building;
    public House? House;

    public override void CheckCompatibility(ref MisCondition existing)
    {
      if (Building == null)
      {
        if (existing.Condition != ConditionType.BUILDINGEXISTS)
          throw new InvalidOperationException("The original condition ({0}) was not a building exist condition. The building must be specified.".F(existing.Condition));
      }

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
        Condition = ConditionType.BUILDINGEXISTS,
        House = House ?? old.House,
        Building = Building ?? old.Building,
      };
    }
  }

}
