using Dune2000.Enums;
using Primrose.Primitives.Factories;

namespace Dune2000.Structs.Statistics
{
  public class HouseStats
  {
    public string Name;

    public string Side;

    public int ColorIndex;

    public int Handicap;

    public int FinishingPlace;

    public int SpiceHarvested;

    public int BuildingsOwned;

    public int BuildingsLost;

    public int BuildingsDestroyed;

    public int UnitsOwned;

    public int UnitsLost;

    public int UnitsKilled;

    public int Credits;

    public Registry<Unit, int> UnitsTable = new Registry<Unit, int>();

    public Registry<Building, int> BuildingsTable = new Registry<Building, int>();
  }
}
