using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_MissionMessageModEntry : MisActionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public short? MessageID;
    public uint MessageUnknown = 0;

    public override void CheckCompatibility(ref MisAction existing)
    {
      if (MessageID == null)
        if (existing.Action != EventType.SHOWMESSAGE)
          throw new InvalidOperationException("The original action ({0}) was not a message action. The message ID must be specified.".F(existing.Action));
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.SHOWMESSAGE,
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        MessageID = MessageID ?? old.MessageID,
        Value = MessageUnknown
      };
    }
  }

}
