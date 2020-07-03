
namespace Dune2000.Enums
{
	/// <summary>
	/// Defines unit instances identified by the v1.06 patch of the game.
	/// </summary>
	public enum UnitType : byte
	{
		// Entries are defined in Templates.bin, which can lend to user modification.
		// This may determine the order of objects in the units tab.
		// It is not known if the underlying behavior of each entry is hardcoded by the game excutable.
		// At some point this should be moved to a configurable file to be parsed.

		LIGHT_INFANTRY = 0,
		TROOPER = 1,
		ENGINEER = 2,
		THUMPER = 3,
		SARDUKAR = 4,
		TRIKE = 5,
		RAIDER = 6,
		QUAD = 7,
		HARVESTER = 8,
		COMBAT_TANK = 9,
		MCV = 10,
		MISSILE_TANK = 11,
		DEVIATOR = 12,
		SEIGE_TANK = 13,
		SONIC_TANK = 14,
		DEVASTATOR = 15,
		CARRYALL = 16,
		ORNITHOPTER = 17,
		STEALTH_FREMEN = 18,
		FREMEN = 19,
		SABOTEUR = 20,
		DEATH_HAND_MISSLE = 21,
		SANDWORM_SPAWN = 22, // Glitchy, invisible, travels on sand, melees, can kill infantry, performs almost no damage to vehicles, only spawns worms on side 7, and moves with the worm. If given an order while worm is active, the worm disappears. Perhaps the sleeper has not yet awakened.
		FRIGATE = 23,
		GRENADIER = 24,
		STEALTH_RAIDER = 25,
		SARDAUKAR_MP = 26
	}
}
