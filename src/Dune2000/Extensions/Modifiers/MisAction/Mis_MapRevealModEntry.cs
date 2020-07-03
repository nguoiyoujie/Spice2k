using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_MapRevealModEntry : MisActionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public uint2? Position;
    public byte? Radius;

    public override void CheckCompatibility(ref MisAction existing)
    {
      if (Position == null)
        if (!existing.Action.RequiresPosition())
          throw new InvalidOperationException("The original action ({0}) did not have a position defined. A position must be specified.".F(existing.Action));

      if (Radius == null)
        if (existing.Action != EventType.REVEAL)
          throw new InvalidOperationException("The original action ({0}) was not a map reveal action. The reveal radius must be specified.".F(existing.Action));
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.REVEAL,
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        Position = Position ?? old.Position,
        RevealMapRadius = Radius ?? old.RevealMapRadius
      };
    }
  }

}
