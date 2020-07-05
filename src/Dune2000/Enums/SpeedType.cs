
namespace Dune2000.Enums
{
	/// <summary>
	/// Defines speed types identified by the v1.06 patch of the game.
	/// </summary>
	public enum SpeedType : byte
	{
		// Entries are defined in Speed.bin, which can lend to user modification.
		// It is not known if the underlying behavior of each entry is hardcoded by the game excutable.
		// At some point this should be moved to a configurable file to be parsed.

		INFANTRY = 0,
		TRACKED = 1,
		WHEELED = 2,
		FLYING = 3
	}
}
