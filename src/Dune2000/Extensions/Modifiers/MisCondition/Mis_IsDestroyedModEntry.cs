using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_IsDestroyedModEntry : MisConditionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public House? House;
    public ObjectTypeEnum State = ObjectTypeEnum.BUILDINGS;
    public uint Unknown = 0;

    public enum ObjectTypeEnum { BUILDINGS, UNITS }

    public static class ObjectTypeExt
    {
      public static ObjectTypeEnum FromConditionType(ConditionType type)
      {
        switch (type)
        {
          case ConditionType.BASEDESTROYED:
            return ObjectTypeEnum.BUILDINGS;

          case ConditionType.UNITSRESTROYED:
            return ObjectTypeEnum.UNITS;

          default:
            throw new InvalidOperationException("Incompatible condition type!");
        }
      }

      public static ConditionType ToConditionType(ObjectTypeEnum type)
      {
        switch (type)
        {
          default:
          case ObjectTypeEnum.BUILDINGS:
            return ConditionType.BASEDESTROYED;

          case ObjectTypeEnum.UNITS:
            return ConditionType.UNITSRESTROYED;
        }
      }
    }


    public override void CheckCompatibility(ref MisCondition existing)
    {
      //if (State == null)
      //  if (existing.Condition != ConditionTypeEnum.NO_BUILDINGS_LEFT && existing.Condition != ConditionTypeEnum.NO_UNITS_LEFT)
      //    throw new InvalidOperationException("The original condition ({0}) was not a no more objects condition. The object type must be specified.".F(existing.Condition));

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
        Condition = ObjectTypeExt.ToConditionType(State),
        House = House ?? old.House,
        Value = Unknown,
      };
    }
  }

}
