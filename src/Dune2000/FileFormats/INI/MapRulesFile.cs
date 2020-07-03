using Primrose.FileFormat.INI;
using System.Collections.Generic;
using System.IO;

namespace Dune2000.FileFormats.INI
{
  // for writing Yes / No instead of True / False
  public enum YesNo { No, Yes }

  public class MapRulesFile : INIFile
  {
    [INIEmbedObject(Section = "Basic")]
    public RulesInfo Basic = new RulesInfo();

    public AdditionalBriefingInfo[] AdditionalBriefings;

    [INIEmbedObject(Section = "Vars")]
    public Variables Vars = new Variables();

    // Some files are missing the integer keys, and still load
    //[INIRegistry(Section = "Text")]
    //public Registry<int, string> Text = new Registry<int, string>();


    public class RulesInfo
    {
      [INIValue]
      public string Name;

      [INIValue]
      public string Author;

      [INIValue]
      public int SideId;

      [INIValue]
      public int MissionNumber;

      [INIValue]
      public string TextUibBriefingKey;

      [INIValue]
      public string Briefing;

      [INIValue]
      public string BriefingCaption;

      [INIValue]
      public string BriefingImage;
    }

    public struct AdditionalBriefingInfo
    {
      public string TextUibBriefingKey;
      public string Briefing;
      public string BriefingCaption;
      public string BriefingImage;
    }

    public class Variables
    {
      public const int DEFAULT_harvestUnloadDelay = 60;
      public const int DEFAULT_harvestBlobValue = 100;
      public const int DEFAULT_harvestLoadSpiceDelay = 60;
      public const int DEFAULT_starportUpdateDelay = 1500;
      public const int DEFAULT_starportStockIncreaseDelay = 1500;
      public const int DEFAULT_starportStockIncreaseProb = 10;
      public const int DEFAULT_starportCostVariationPercent = 25;
      public const int DEFAULT_starportFrigateDelay = 1500;
      public const int DEFAULT_refineryExplosionOffsetX = 62;
      public const int DEFAULT_refineryExplosionOffsetY = -79;
      public const int DEFAULT_HarvesterDriveDistance = 64;
      public const int DEFAULT_RepairDriveDistance = 64;
      public const int DEFAULT_BuildingRepairValue = 12;
      public const int DEFAULT_UnitRepairValue = 8;
      public const int DEFAULT_SinglePlayerDelay = 2;
      public const int DEFAULT_NumberOfFremen = 2;
      public const int DEFAULT_SandWormAppetite = 3;
      public const int DEFAULT_SandWormInitialSleep = 50;
      public const int DEFAULT_SandWormFedSleep = 40;
      public const int DEFAULT_SandWormShotSleep = 90;
      public const int DEFAULT_NumberOfCrates = 1;
      public const YesNo DEFAULT_CratesPerPlayer = YesNo.No;
      public const int DEFAULT_DevastatorExplodeDelay = 100;
      public const int DEFAULT_IgnoreDistance = 2;
      public const int DEFAULT_CrateCash = 1000;
      public const YesNo DEFAULT_ShowWarnings = YesNo.Yes;
      public const int DEFAULT_DeathHandAccuracy = 3;
      public const YesNo DEFAULT_InfiniteSpice = YesNo.No;


      [INIValue(NoWriteValue = DEFAULT_harvestUnloadDelay)]
      public int harvestUnloadDelay = DEFAULT_harvestUnloadDelay;

      [INIValue(NoWriteValue = DEFAULT_harvestBlobValue)]
      public int harvestBlobValue = DEFAULT_harvestBlobValue;

      [INIValue(NoWriteValue = DEFAULT_harvestLoadSpiceDelay)]
      public int harvestLoadSpiceDelay = DEFAULT_harvestLoadSpiceDelay;

      [INIValue(NoWriteValue = DEFAULT_starportUpdateDelay)]
      public int starportUpdateDelay = DEFAULT_starportUpdateDelay;

      [INIValue(NoWriteValue = DEFAULT_starportStockIncreaseDelay)]
      public int starportStockIncreaseDelay = DEFAULT_starportStockIncreaseDelay;

      [INIValue(NoWriteValue = DEFAULT_starportStockIncreaseProb)]
      public int starportStockIncreaseProb = DEFAULT_starportStockIncreaseProb;

      [INIValue(NoWriteValue = DEFAULT_starportCostVariationPercent)]
      public int starportCostVariationPercent = DEFAULT_starportCostVariationPercent;

      [INIValue(NoWriteValue = DEFAULT_starportFrigateDelay)]
      public int starportFrigateDelay = DEFAULT_starportFrigateDelay;

      [INIValue(NoWriteValue = DEFAULT_refineryExplosionOffsetX)]
      public int refineryExplosionOffsetX = DEFAULT_refineryExplosionOffsetX;

      [INIValue(NoWriteValue = DEFAULT_refineryExplosionOffsetY)]
      public int refineryExplosionOffsetY = DEFAULT_refineryExplosionOffsetY;

      [INIValue(NoWriteValue = DEFAULT_HarvesterDriveDistance)]
      public int HarvesterDriveDistance = DEFAULT_HarvesterDriveDistance;

      [INIValue(NoWriteValue = DEFAULT_RepairDriveDistance)]
      public int RepairDriveDistance = DEFAULT_RepairDriveDistance;

      [INIValue(NoWriteValue = DEFAULT_BuildingRepairValue)]
      public int BuildingRepairValue = DEFAULT_BuildingRepairValue;

      [INIValue(NoWriteValue = DEFAULT_UnitRepairValue)]
      public int UnitRepairValue = DEFAULT_UnitRepairValue;

      [INIValue(NoWriteValue = DEFAULT_SinglePlayerDelay)]
      public int SinglePlayerDelay = DEFAULT_SinglePlayerDelay;

      [INIValue(NoWriteValue = DEFAULT_NumberOfFremen)]
      public int NumberOfFremen = DEFAULT_NumberOfFremen;

      [INIValue(NoWriteValue = DEFAULT_SandWormAppetite)]
      public int SandWormAppetite = DEFAULT_SandWormAppetite;

      [INIValue(NoWriteValue = DEFAULT_SandWormInitialSleep)]
      public int SandWormInitialSleep = DEFAULT_SandWormInitialSleep;

      [INIValue(NoWriteValue = DEFAULT_SandWormFedSleep)]
      public int SandWormFedSleep = DEFAULT_SandWormFedSleep;

      [INIValue(NoWriteValue = DEFAULT_SandWormShotSleep)]
      public int SandWormShotSleep = DEFAULT_SandWormShotSleep;

      [INIValue(NoWriteValue = DEFAULT_NumberOfCrates)]
      public int NumberOfCrates = DEFAULT_NumberOfCrates;

      [INIValue(NoWriteValue = DEFAULT_CratesPerPlayer)]
      public YesNo CratesPerPlayer = DEFAULT_CratesPerPlayer;

      [INIValue(NoWriteValue = DEFAULT_DevastatorExplodeDelay)]
      public int DevastatorExplodeDelay = DEFAULT_DevastatorExplodeDelay;

      [INIValue(NoWriteValue = DEFAULT_IgnoreDistance)]
      public int IgnoreDistance = DEFAULT_IgnoreDistance;

      [INIValue(NoWriteValue = DEFAULT_CrateCash)]
      public int CrateCash = DEFAULT_CrateCash;

      [INIValue(NoWriteValue = DEFAULT_ShowWarnings)]
      public YesNo ShowWarnings = DEFAULT_ShowWarnings;

      [INIValue(NoWriteValue = DEFAULT_DeathHandAccuracy)]
      public int DeathHandAccuracy = DEFAULT_DeathHandAccuracy;

      [INIValue(NoWriteValue = DEFAULT_InfiniteSpice)]
      public YesNo InfiniteSpice = DEFAULT_InfiniteSpice;
    }

    protected override void Read(StreamReader sr)
    {
      base.Read(sr);
      List<AdditionalBriefingInfo> list = new List<AdditionalBriefingInfo>();
      string section = "AdditionalBriefings";
      string briefing = "Briefing";
      string briefingCaption = "BriefingCaption";
      string briefingKey = "TextUibBriefingKey";
      string briefingImage = "BriefingImage";

      int index = 1;
      while (HasKey(section, briefing + index) || HasKey(section, briefingKey + index))
      {
        AdditionalBriefingInfo info = new AdditionalBriefingInfo
        {
          Briefing = GetString(section, briefing + index, null),
          BriefingCaption = GetString(section, briefingCaption + index, null),
          TextUibBriefingKey = GetString(section, briefingKey + index, null),
          BriefingImage = GetString(section, briefingImage + index, null)
        };

        list.Add(info);
        index++;
      }

      AdditionalBriefings = list.ToArray();
    }
  }
}
