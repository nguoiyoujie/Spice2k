
namespace Dune2000.Enums
{
	/// <summary>
	/// House Identities
	/// </summary>
	public enum House : byte
	{
		// Names taken from Dune2000.exe, starting from 0x004E15E0

		ATREIDES = 0,
		HARKONNEN = 1,
		ORDOS = 2,
		EMPEROR = 3,
		FREMEN = 4,
		SMUGGLER = 5,
		MERCENARY = 6,
		OTHER = 7					// Outside of the executable it is known as Sandworm due to the house being reserved for the Sandworm unit
	}
}
