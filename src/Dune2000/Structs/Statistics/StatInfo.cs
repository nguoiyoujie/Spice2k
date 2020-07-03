using Dune2000.Enums;
using Primrose.Primitives.Factories;

namespace Dune2000.Structs.Statistics
{
  public class Stats
  {
    public string PlayerAccountName = "";

    public int Time;

    public bool SuddenDisconnect;

    public string EndStatus = "";

    public bool TournamentGame;

    public int GameId;

    public string GameDuration = "";

    public string MapName = "";

    public int GameTicks;

    public int PlayerCount;

    public int AIPlayerCount;
    
    public int Worms = -1;

    public int StartingCredits;

    public bool Crates;

    public int TechLevel = -1;

    public int UnitCount;

    public Registry<House, HouseStats> Houses = new Registry<House, HouseStats>();

    public Stats()
    {
      Houses.Put(House.ATREIDES, new HouseStats());
      Houses.Put(House.HARKONNEN, new HouseStats());
      Houses.Put(House.ORDOS, new HouseStats());
      Houses.Put(House.EMPEROR, new HouseStats());
      Houses.Put(House.FREMEN, new HouseStats());
      Houses.Put(House.SMUGGLER, new HouseStats());
      Houses.Put(House.MERCENARY, new HouseStats());
      Houses.Put(House.OTHER, new HouseStats());
    }
  }
}
