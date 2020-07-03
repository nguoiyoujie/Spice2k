using System;

namespace Dune2000.Enums
{
	/// <summary>
	/// A set of bit-flags determining the type of tiledata
	/// </summary>
	[Flags]
  public enum TileDataType : byte
	{
		UNIT = 0x00,
		UNKNOWN_1 = 0x01,
		UNKNOWN_2 = 0x02,
		UNKNOWN_3 = 0x04,
		UNKNOWN_4 = 0x08,
		UNKNOWN_5 = 0x10,
		UNKNOWN_6 = 0x20,
		SPICE = 0x40, //??
		STRUCTURE = 0x80
	}
}
