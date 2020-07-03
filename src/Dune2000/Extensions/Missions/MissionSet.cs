using Dune2000.Enums;

namespace Dune2000.Extensions.Missions
{
  public struct MissionSet
  {
    public readonly MissionIdentifier Identifier;
    public readonly MissionInfo Info;
    public readonly MissionSourceInfo Source;
    public Difficulty Difficulty;

    public MissionSet(MissionInfo misInfo, MissionSourceInfo srcInfo)
    {
      Info = misInfo;
      Source = srcInfo;
      Identifier = srcInfo.Identify();
      Difficulty = default;
    }
  }
}
