using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.Primitives.Extensions;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_HouseDiplomacyModEntry : MisActionModEntry
  {
    // modifiers: a null value indicates to use the existing value
    public House? House;
    public House? TargetHouse;
    public Allegiance? DiplomaticState;

    public override void CheckCompatibility(ref MisAction existing)
    {
      if (House == null)
        if (!existing.Action.RequiresHouse())
          throw new InvalidOperationException("The original action ({0}) did not have a house defined. A house must be specified.".F(existing.Action));

      if (TargetHouse == null || DiplomaticState == null)
        if (existing.Action != EventType.ALLEGIANCE)
          throw new InvalidOperationException("The original action ({0}) was not a diplomacy action. The target house and diplomatic state must be specified.".F(existing.Action));
    }

    public override void Write(ref MisAction action)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      MisAction old = action;

      action = new MisAction
      {
        Action = EventType.ALLEGIANCE,
        Conditions = old.Conditions,
        ConditionFireIfFalse = old.ConditionFireIfFalse,
        House = House ?? old.House,
        TargetHouse = TargetHouse ?? old.TargetHouse,
        Allegiance = DiplomaticState ?? old.Allegiance
      };
    }
  }

}
