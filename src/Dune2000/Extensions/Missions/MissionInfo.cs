using Dune2000.FileFormats.INI;
using Dune2000.Enums;

namespace Dune2000.Extensions.Missions
{
  public readonly struct MissionInfo
  {
    public readonly string Name;
    public readonly House House;
    public readonly int MissionNumber;

    public MissionInfo(string name, House house, int missionNumber)
    {
      Name = name;
      House = house;
      MissionNumber = missionNumber;
    }
  }

  public static class MapRulesFileExt
  {
    public static MissionInfo RetrieveInfo(this MapRulesFile rules)
    {
      return new MissionInfo
      (
        rules.Basic.Name,
        (House)rules.Basic.SideId,
        rules.Basic.MissionNumber
      );
    }
  }
}
