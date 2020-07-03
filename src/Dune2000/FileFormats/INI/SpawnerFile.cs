using Primrose.FileFormat.INI;

namespace Dune2000.FileFormats.INI
{
  public class SpawnerFile : INIFile
  {
    public const string Settings = "Settings";

    [INIValue(Section = Settings)]
    public string Scenario;

    [INIValue(Section = Settings)]
    public int MySideID;

    [INIValue(Section = Settings)]
    public int MissionNumber;

    [INIValue(Section = Settings)]
    public int DifficultyLevel;

    [INIValue(Section = Settings)]
    public int Seed;

    [INIValue(Section = Settings)]
    public string TextUib;
  }
}
