using Dune2000.Enums;
using Dune2000.Structs.Mis;

namespace Dune2000.Extensions.Modifiers
{
  public class Mis_FlagModEntry : MisConditionModEntry
  {
    public override void Write(ref MisCondition condition)
    {
      // Make copy (could submit it to a undo/redo state machine for undo measure...)
      //MisCondition old = condition;

      condition = new MisCondition
      {
        Condition = ConditionType.FLAG,
      };
    }
  }

}
