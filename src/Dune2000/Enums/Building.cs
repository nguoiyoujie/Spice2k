
namespace Dune2000.Enums
{
	/// <summary>
	/// Defines building instances identified by the v1.06 patch of the game.
	/// </summary>
	public enum Building : byte
	{
		// Entries are defined in Templates.bin, which can lend to user modification.
		// At some point this should be moved to a configurable file to be parsed.
		// Names are not made exact to Templates.bin in favor for a more convenient format (XXXX_H)

		// Construction Yards (I = Imperial)
		CONY_A = 0,
		CONY_H = 1,
		CONY_O = 2,
		CONY_I = 3,

		// Concrete
		CONC_A = 4,
		CONC_H = 5,
		CONC_O = 6,

		// Test Concrete
		CONT_A = 7,
		CONT_H = 8,
		CONT_O = 9,

		// Wind Trap
		WIND_A = 10,
		WIND_H = 11,
		WIND_O = 12,

		// Barracks
		BARR_A = 13,
		BARR_H = 14,
		BARR_O = 15,

		// Fremen Sietch
		STCH_F = 16,

		// Wall
		WALL_A = 17,
		WALL_H = 18,
		WALL_O = 19,

		// Refinery
		REFN_A = 20,
		REFN_H = 21,
		REFN_O = 22,

		// Gun Turret
		GUNT_A = 23,
		GUNT_H = 24,
		GUNT_O = 25,

		// Outpost
		OUTP_A = 26,
		OUTP_H = 27,
		OUTP_O = 28,

		// Rocket Turret
		ROCK_A = 29,
		ROCK_H = 30,
		ROCK_O = 31,

		// High Tech Factory
		TECH_A = 32,
		TECH_H = 33,
		TECH_O = 34,

		// Light Factory
		LFAC_A = 35,
		LFAC_H = 36,
		LFAC_O = 37,

		// Silo
		SILO_A = 38,
		SILO_H = 39,
		SILO_O = 40,

		// Heavy Factory (I = Imperial, M = Mercenary)
		HFAC_A = 41,
		HFAC_H = 42,
		HFAC_O = 43,
		HFAC_M = 44,
		HFAC_I = 45,

		// Star Port (S = Smugglers)
		PORT_A = 46,
		PORT_H = 47,
		PORT_O = 48,
		PORT_S = 49,

		// Repair Pad
		RPAD_A = 50,
		RPAD_H = 51,
		RPAD_O = 52,

		// Research Centre
		RCEN_A = 53,
		RCEN_H = 54,
		RCEN_O = 55,

		// Palace (I = Imperial)
		PLCE_A = 56,
		PLCE_H = 57,
		PLCE_O = 58,
		PLCE_I = 59,

		// Special Outpost
		OUTS_H = 60,
		OUTS_O = 61
	}
}
