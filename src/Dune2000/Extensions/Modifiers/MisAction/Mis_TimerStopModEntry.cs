using Dune2000.Enums;
using Dune2000.Structs.Mis;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_TimerStopModEntry : MisActionModEntry
  {
    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.HIDETIMER,
          Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse
      };
    }
  }

}
