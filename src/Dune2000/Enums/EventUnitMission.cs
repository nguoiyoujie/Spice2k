
namespace Dune2000.Enums
{
	/// <summary>
	/// Unit Missions
	/// </summary>
	public enum EventUnitMission : byte
	{
		// Names taken from Dune2000.exe, starting from 0x004E14E0

		GUARD = 0,			  // Stay at location
		ATTACK = 1,       // Similar to Hunt mode in other C&C games
		RETREAT = 2,      // Return to base location
		STAY = 3,         // ?
	}
}
