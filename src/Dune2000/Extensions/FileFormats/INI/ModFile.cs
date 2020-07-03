using Dune2000.Extensions.Modifiers;
using Primrose.FileFormat.INI;

namespace Dune2000.Extensions.FileFormats.INI
{
  public class ModFile : INIFile
  {
    // Experimental mission modifier file that makes modifications to .map and .mis files
    // Theoretically allows the launcher to make minor adjustments to missions before launching them.

    [INISubSectionKeyList(Section = "MapTileMods")]
    public MapModInfo[] MapTileMods;

    [INISubSectionKeyList(Section = "MapObjectMods")]
    public MapModInfo[] MapObjectMods;

    [INISubSectionKeyList(Section = "MissionConditionMods")]
    public MisConditionModInfo[] MisConditionMods;

    [INISubSectionKeyList(Section = "MissionActionMods")]
    public MisActionModInfo[] MisActionMods;


    public ModFile()
    {
    }

    public ModFile(MapModInfo[] mapTileMods, MapModInfo[] mapObjectMods, MisConditionModInfo[] misConditionMods, MisActionModInfo[] misActionMods)
    {
      MapTileMods = mapTileMods;
      MapObjectMods = mapObjectMods;
      MisConditionMods = misConditionMods;
      MisActionMods = misActionMods;
    }

    public Mod CreateMod()
    {
      Mod mod = new Mod();

      foreach (MapModInfo m in MapTileMods) { mod.MapMods.Add(m.Name, m.CreateEntry(true)); }
      foreach (MapModInfo m in MapObjectMods) { mod.MapMods.Add(m.Name, m.CreateEntry(false)); }
      foreach (MisActionModInfo m in MisActionMods) { mod.MisMods.Add(m.Name, m.CreateEntry()); }
      foreach (MisConditionModInfo m in MisConditionMods) { mod.MisMods.Add(m.Name, m.CreateEntry()); }

      return mod;
    }
  }
}
