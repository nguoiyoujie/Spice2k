
namespace Dune2000.Enums
{
	/// <summary>
	/// Defines armor types identified by the v1.06 patch of the game.
	/// </summary>
	public enum ArmourType : byte
	{
		// Entries are defined in Armour.bin, which can lend to user modification.
		// It is not known if the underlying behavior of each entry is hardcoded by the game excutable.
		// At some point this should be moved to a configurable file to be parsed.

		NONE = 0,
		WALL = 1,
		BUILDING = 2,
		WOOD = 3,
		LIGHT = 4,
		HEAVY = 5,
		CONCRETE = 6,
		INVULNERABLE = 7,
		CY = 8,
		HARVESTER = 9
	}
}
