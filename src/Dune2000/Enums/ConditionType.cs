
namespace Dune2000.Enums
{
	/// <summary>
	/// The condition type (also known as the Trigger Event type in C&C / Red Alert games)
	/// </summary>
	public enum ConditionType : byte
	{
		// Names taken from Dune2000.exe, starting from 0x004E1730

		BUILDINGEXISTS = 0,       // does House have this Building?
		UNITEXISTS = 1,           // does House have this Unit?
		INTERVAL = 2,
		TIMER = 3,
		CASUALTIES = 4,
		BASEDESTROYED = 5,				// NO_BUILDINGS_LEFT
		UNITSRESTROYED = 6,				// NO_UNITS_LEFT
		REVEALED = 7,							// TILE_REVEALED
		HARVESTED = 8,            // CREDITS
		FLAG = 9
	}

	public static class ConditionTypeEnumExt
	{
		public static bool RequiresTime(this ConditionType value)
		{
			return value == ConditionType.INTERVAL
					|| value == ConditionType.TIMER;
		}

		public static bool RequiresPosition(this ConditionType value)
		{
			return value == ConditionType.REVEALED;
		}

		public static bool RequiresHouse(this ConditionType value)
		{
			return value == ConditionType.BUILDINGEXISTS
					|| value == ConditionType.UNITEXISTS
					|| value == ConditionType.CASUALTIES
					|| value == ConditionType.BASEDESTROYED
					|| value == ConditionType.UNITSRESTROYED;
		}

		public static bool RequiresValue(this ConditionType value)
		{
			return value == ConditionType.INTERVAL  // Activation Count
					|| value == ConditionType.CASUALTIES // Threshold
					|| value == ConditionType.BASEDESTROYED // Unknown
					|| value == ConditionType.UNITSRESTROYED // Unknown
					|| value == ConditionType.REVEALED // Activation Count?
					|| value == ConditionType.HARVESTED; // Credits;
		}
	}
}
