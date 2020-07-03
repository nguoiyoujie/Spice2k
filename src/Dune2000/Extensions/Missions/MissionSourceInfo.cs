namespace Dune2000.Extensions.Missions
{
  public readonly struct MissionSourceInfo
  {
    public readonly string Map;
    public readonly string Mis;
    public readonly string Rules;
    public readonly string Mod;

    public MissionSourceInfo(string map, string mis, string rules, string mod)
    {
      Map = map;
      Mis = mis;
      Rules = rules;
      Mod = mod;
    }
  }
}
