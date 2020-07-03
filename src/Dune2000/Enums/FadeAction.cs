namespace Dune2000.Enums
{
  /// <summary>
  /// Actions to be taken when a menu performs a fading transition
  /// </summary>
  public enum FadeAction
  {
    // Referenced when loading the menus.uib file into memory, and nowhere else.
    // Used to determine the fade transition between menus.
    // Names taken from Dune2000.exe, starting from 0x004E8178, with some edits per below comment:
    // The game uses 'FADE' for both 0 and 1, so more descriptive names are given in this enum

    FADE_FROMBLACK = 0,
    FADE_TOBLACK = 1,
    TWEEN = 2,
    SKIP = 3
  }
}
