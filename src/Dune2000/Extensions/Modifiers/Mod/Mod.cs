using Dune2000.FileFormats.Map;
using Dune2000.FileFormats.Mis;
using Primrose.Primitives.Factories;

namespace Dune2000.Extensions.Modifiers
{
  /// <summary>
  /// Experimental mission modifier file that makes modifications to .map and .mis files
  /// </summary>
  public class Mod
  {
    public Registry<ModEntry<MapFile>> MapMods = new Registry<ModEntry<MapFile>>();
    public Registry<ModEntry<MisFile>> MisMods = new Registry<ModEntry<MisFile>>();

    public void Apply(ref MapFile mapFile, ref MisFile misFile)
    {
      foreach (ModEntry<MapFile> entry in MapMods.GetValues())
        entry.Apply(ref mapFile);

      foreach (ModEntry<MisFile> entry in MisMods.GetValues())
        entry.Apply(ref misFile);
    }
  }

}
