using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_ReinforcementActionModEntry : MisActionModEntry
  {
    public ReinforcementType Type = ReinforcementType.CARRYALL;

    public enum ReinforcementType { CARRYALL, SPAWN, STARPORT }

    public static class ReinforcementTypeExt
    {
      public static ReinforcementType FromActionType(EventType type)
      {
        switch (type)
        {
          case EventType.DEPLOY:
              return ReinforcementType.CARRYALL;

          case EventType.REINFORCE:
              return ReinforcementType.STARPORT;

          case EventType.ADDUNITS:
              return ReinforcementType.SPAWN;

          default:
            throw new InvalidOperationException("Incompatible action type!");
        }
      }

      public static EventType ToActionType(ReinforcementType type)
      {
        switch (type)
        {
          default:
          case ReinforcementType.CARRYALL:
              return EventType.DEPLOY;

          case ReinforcementType.STARPORT:
              return EventType.REINFORCE;

          case ReinforcementType.SPAWN:
              return EventType.ADDUNITS;
        }
      }
    }

    // modifiers: a null value indicates to use the existing value
    public uint2? Position; // Note: A reinforcement by STARPORT does not require Position
    public House? House;
    public Unit[] Units;
    public EventUnitMission? UnitMission;

    public override void CheckValueIntegrity(ref MisFile target)
    {
      base.CheckValueIntegrity(ref target);

      if (Units != null && Units.Length > MisAction.MAX_DATA)
        throw new InvalidOperationException("Invalid number of units ({0}): A maximum number of {1} units is supported.".F(Units.Length, MisAction.MAX_DATA));
    }

    public override void CheckCompatibility(ref MisAction existing)
    {
      if (Units == null || UnitMission == null)
        if (!existing.Action.IsReinforcement())
          throw new InvalidOperationException("The original action is incompatible ({0}) with a reinforcement action. A full modification is required.".F(existing.Action));

      if (Position == null)
        if (!existing.Action.RequiresPosition())
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
        Action = ReinforcementTypeExt.ToActionType(Type),
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        Position = Position ?? old.Position,
        House = House ?? old.House,
        NumberOfUnits = (byte)(Units ?? old.Units).Length,
        Units = Units ?? old.Units,
        UnitMission = UnitMission ?? old.UnitMission
      };
    }
  }

}
