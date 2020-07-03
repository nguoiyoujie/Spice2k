using Dune2000.Enums;
using Dune2000.Structs.Mis;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_TriggerMissionStateModEntry : MisActionModEntry
  {
    public MissionState State = MissionState.LOSE;

    public enum MissionState { LOSE, WIN }

    public static class MissionStateExt
    {
      public static MissionState FromActionType(EventType type)
      {
        switch (type)
        {
          case EventType.LOSE:
            return MissionState.LOSE;

          case EventType.WIN:
            return MissionState.WIN;

          default:
            throw new InvalidOperationException("Incompatible action type!");
        }
      }

      public static EventType ToActionType(MissionState type)
      {
        switch (type)
        {
          default:
          case MissionState.LOSE:
            return EventType.LOSE;

          case MissionState.WIN:
            return EventType.WIN;
        }
      }
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = MissionStateExt.ToActionType(State),
         Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
      };
    }
  }
}
