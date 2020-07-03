using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_SetFlagModEntry : MisActionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public byte? Flag;
    public bool? Enable;

    public override void CheckCompatibility(ref MisAction existing)
    {
      // If the only parameter is empty, something is wrong
      if (Flag == null || Enable == null)
        if (existing.Action != EventType.SETFLAG)
          throw new InvalidOperationException("The original action ({0}) was not a flag action. The flag and enable must be specified.".F(existing.Action));
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.SETFLAG,
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        Flag = Flag ?? old.Flag,
        Enable = Enable ?? old.Enable
      };
    }
  }

}
