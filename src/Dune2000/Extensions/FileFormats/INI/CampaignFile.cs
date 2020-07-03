using Dune2000.Enums;
using Dune2000.Extensions.Missions;
using Primrose.FileFormat.INI;

namespace Dune2000.Extensions.FileFormats.INI
{
  public class CampaignFile : INIFile
  {
    // Internal campaign file format for the launcher

    [INIEmbedObject(Section = "Images")]
    public CampaignImageInfo Images;

    [INISubSectionKeyList(Section = "Stages", ValueSource = ValueSource.VALUE_OR_KEY)]
    public CampaignStageInfo[] Stages;

    public CampaignStageInfo GetStage(MissionSet set)
    {
      for (int i = 0; i < Stages.Length; i++)
        for (int m = 0; m < Stages[i].Missions.Length; m++)
          if (Stages[i].Missions[m].MissionID == set.Identifier.ID)
            return Stages[i];

      return default;
    }
  }

  public struct CampaignStageInfo
  {
    [INIValue]
    public string Name;

    [INISubSectionList(Required = true)]
    public CampaignMissionInfo[] Missions;

    [INIValue]
    public short[] CampaignColorMap;

    [INIValue]
    public string[] UnitDescription;
  }

  public struct CampaignMissionInfo
  {
    [INIValue(Required = true)]
    public short RegionID;

    [INIValue(Required = true)]
    public string MissionID;

    [INIValue(Required = true)]
    public House House;

    [INIValue]
    public string[] UnitDescription;
  }

  public struct CampaignImageInfo
  {
    [INIValue]
    public string Background;

    [INIValue]
    public string Mask;

    [INIKeyList(Section = "ImageLayers", ValueSource = ValueSource.VALUE_OR_KEY)]
    public string[] Layers;
  }
}
