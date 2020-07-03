
namespace Dune2000.Enums
{
	/// <summary>
	/// The event type (also known as the Trigger Action type in C&C / Red Alert games)
	/// </summary>
	public enum EventType : byte
	{
		// Names taken from Dune2000.exe, starting from 0x004E1870
		// Use the same enum strings as declared by the game, more descriptive interpretations in comments below

		DEPLOY = 0,																// REINFORCE_BY_CARRYALL
		REINFORCE = 1,								            // REINFORCE_BY_STARPORT
		ALLEGIANCE = 2,														// CHANGE_DIPLOMACY
		LEAVE = 3,
		BESERK = 4,																// FIRE_SALE
		PLAYSOUND = 5, 
		SETBUILDRATE = 6,                         // SET_AI_BUILD_INTERVAL
		SETATTACKBUILDINGRATE = 7,								// SET_AI_ATTACK_INTERVAL
		SETCASH = 8,                              // SET_CREDITS
		SETTECH = 9,                              // SET_TECHLEVEL
		WIN = 10,                                 // PLAYER_WIN
		LOSE = 11,                                // PLAYER_LOSE
		BLOXFILE = 12,                            // In intermediate files, the executable reparses them as Event 20. Likely a scrapped mechanic
		ATTRIBFILE = 13,                          // In intermediate files, the executable reparses them as Event 20. Likely a scrapped mechanic
		REVEAL = 14,                              // REVEAL_AROUND_POINT
		SHOWTIMER = 15,                           // TIMER_START
		HIDETIMER = 16,                           // TIMER_STOP
		SHOWMESSAGE = 17,
		ADDUNITS = 18,                            // REINFORCE_BY_SPAWN
		SETFLAG = 19, 
		UNUSED_20 = 20,                           // (in the executable it is blank)

		// Fan-patch additions
		PLAY_MUSIC = 21,                          // Added by fan-patched v1.06
	}

	public static class EventTypeExt
	{
		public static bool IsReinforcement(this EventType value)
    {
			return value == EventType.DEPLOY
				  || value == EventType.REINFORCE
					|| value == EventType.ADDUNITS;
		}

		public static bool RequiresPosition(this EventType value)
		{
			return value == EventType.DEPLOY
					|| value == EventType.ADDUNITS
					|| value == EventType.REVEAL;
		}

		public static bool RequiresHouse(this EventType value)
		{
			return value.IsReinforcement()
					|| value == EventType.ALLEGIANCE
					|| value == EventType.LEAVE
					|| value == EventType.BESERK
					|| value == EventType.SETBUILDRATE
					|| value == EventType.SETATTACKBUILDINGRATE
					|| value == EventType.SETCASH
					|| value == EventType.SETTECH;
		}

		public static bool RequiresValue(this EventType value)
		{
			return value == EventType.PLAYSOUND // Sound ID
					|| value == EventType.SETBUILDRATE // Build Interval
					|| value == EventType.SETATTACKBUILDINGRATE // Attack Interval
					|| value == EventType.SETCASH // Credits
					|| value == EventType.SETTECH // Tech Level
					|| value == EventType.SETFLAG // FlagTrue
					|| value == EventType.SHOWMESSAGE; // MessageUnknown;
		}
	}
}
