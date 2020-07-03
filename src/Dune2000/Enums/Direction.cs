namespace Dune2000.Enums
{
  /// <summary>
  /// Direction, in 8 directions
  /// </summary>
  public enum Direction
  {
    // Names taken from Dune2000.exe, starting from 0x004E82CC
    // Referenced when loading the campaign.uib file into memory, and nowhere else.
    // It is not known what these do.

    NORTH = 0,
    NORTH_EAST = 1,
    EAST = 2,
    SOUTH_EAST = 3,
    SOUTH = 4,
    SOUTH_WEST = 5,
    WEST = 6,
    NORTH_WEST = 7
  }
}
