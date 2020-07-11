
namespace Dune2000.Enums
{
  /// <summary>
  /// The animation stage of the campaign map
  /// </summary>
  public enum AnimStage
  {
    // Referenced when using the campaign.uib file to display the campaign map.
    // Used to determine what regions to show during animation transitions between menus.

    BEFORE_ANIM = 0,
    AFTER_SFX1 = 1,
    AFTER_SFX2 = 2,
    AFTER_SFX3 = 3,
  }
}
