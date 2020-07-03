using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_HouseActionModEntry : MisActionModEntry
  {
    public ActionType Type = ActionType.FIRE_SALE;

    public enum ActionType { FIRE_SALE, LEAVE }

    public static class ActionExt
    {
      public static ActionType FromActionType(EventType type)
      {
        switch (type)
        {
          case EventType.BESERK:
            return ActionType.FIRE_SALE;

          case EventType.LEAVE:
            return ActionType.LEAVE;

          default:
            throw new InvalidOperationException("Incompatible action type!");
        }
      }

      public static EventType ToActionType(ActionType type)
      {
        switch (type)
        {
          default:
          case ActionType.FIRE_SALE:
            return EventType.BESERK;

          case ActionType.LEAVE:
            return EventType.LEAVE;
        }
      }
    }

    // modifiers: a null value indicates to use the existing value
    public House? House;

    public override void CheckCompatibility(ref MisAction existing)
    {
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
        Action = ActionExt.ToActionType(Type),
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        House = House ?? old.House
      };
    }
  }

}
