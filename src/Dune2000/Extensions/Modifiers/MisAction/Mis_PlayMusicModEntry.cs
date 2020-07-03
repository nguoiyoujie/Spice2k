using Dune2000.Enums;
using Dune2000.Structs.Mis;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_PlayMusicModEntry : MisActionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public string Music;

    public override void CheckCompatibility(ref MisAction existing)
    {
      // If the only parameter is empty, something is wrong
      if (Music == null)
        throw new InvalidOperationException("The music name must be specified.");
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.PLAY_MUSIC,
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        Music = Music
      };
    }
  }

}
