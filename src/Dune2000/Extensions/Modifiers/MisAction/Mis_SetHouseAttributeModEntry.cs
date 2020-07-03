using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_SetHouseAttributeModEntry : MisActionModEntry
  {
    public AttributeType Type = AttributeType.TECHLEVEL;

    public enum AttributeType { TECHLEVEL, BUILD_INTERVAL, ATTACK_INTERVAL, CREDITS }

    public static class AttributeTypeExt
    {
      public static AttributeType FromActionType(EventType type)
      {
        switch (type)
        {
          case EventType.SETATTACKBUILDINGRATE:
            return AttributeType.ATTACK_INTERVAL;

          case EventType.SETBUILDRATE:
            return AttributeType.BUILD_INTERVAL;

          case EventType.SETCASH:
            return AttributeType.CREDITS;

          case EventType.SETTECH:
            return AttributeType.TECHLEVEL;

          default:
            throw new InvalidOperationException("Incompatible action type!");
        }
      }

      public static EventType ToActionType(AttributeType type)
      {
        switch (type)
        {
          default:
          case AttributeType.TECHLEVEL:
            return EventType.SETTECH;

          case AttributeType.BUILD_INTERVAL:
            return EventType.SETBUILDRATE;

          case AttributeType.ATTACK_INTERVAL:
            return EventType.SETATTACKBUILDINGRATE;

          case AttributeType.CREDITS:
            return EventType.SETCASH;
        }
      }
    }

    // modifiers: a null value indicates to use the existing value
    public uint? Value; 
    public House? House;

    public override void CheckCompatibility(ref MisAction existing)
    {
      if (Value == null)
        if (!existing.Action.RequiresValue())
          throw new InvalidOperationException("The original action ({0}) did not have a position defined. A position must be specified.".F(existing.Action));

      if (House == null)
        if (!existing.Action.RequiresHouse())
          throw new InvalidOperationException("The original action ({0}) did not have a house defined. A house must be specified.".F(existing.Action));
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = AttributeTypeExt.ToActionType(Type),
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        House = House ?? old.House,
        Value = Value ?? old.Value
      };
    }
  }

}
