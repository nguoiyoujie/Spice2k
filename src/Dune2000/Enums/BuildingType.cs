
namespace Dune2000.Enums
{
	/// <summary>
	/// Defines building type instances identified by the v1.06 patch of the game.
	/// </summary>
	public enum BuildingType : byte
	{
		// Entries are defined in Templates.bin, which can lend to user modification.
		// This may determine the order of objects in the structures tab.
		// It is not known if the underlying behavior of each entry is hardcoded by the game excutable.
		// At some point this should be moved to a configurable file to be parsed.

		CONSTRUCTION_YARD = 0,
		CONCRETE_SM = 1, // Executable makes a check for concrete and crashes if pre-placed in map file!
		CONCRETE_LG = 2, // Executable makes a check for concrete and crashes if pre-placed in map file!
		WIND_TRAP = 3,
		BARRACKS = 4,
		SIETCH = 5,
		WALL = 6,
		REFINERY = 7,
		GUN_TURRET = 8,
		OUTPOST = 9,
		ROCKET_TURRET = 10,
		ATREDIES_HIGH_TECH_FACTORY = 11,
		HIGH_TECH_FACTORY = 12,
		LIGHT_FACTORY = 13,
		SILO = 14,
		HEAVY_FACTORY = 15,
		STARPORT = 16,
		REPAIR_PAD = 17,
		RESEARCH_CENTRE = 18,
		ATREIDES_PALACE = 19,
		HARKONNEN_PALACE = 20,
		ORDOS_PALACE = 21,
		IMPERIAL_PALACE = 22,
		MODIFIED_OUTPOST = 23
	}
}
