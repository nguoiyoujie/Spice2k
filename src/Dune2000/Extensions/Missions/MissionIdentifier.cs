using System.IO;

namespace Dune2000.Extensions.Missions
{
  public enum MissionType
  {
    INVALID,
    MAIN_ATREIDES_CAMPAIGN,
    MAIN_HARKONNEN_CAMPAIGN,
    MAIN_ORDOS_CAMPAIGN,
    CUSTOM_CAMPAIGN
  }

  public readonly struct MissionIdentifier
  {
    public readonly string ID;
    public readonly MissionType Type;

    public MissionIdentifier(string id, MissionType type)
    {
      ID = id;
      Type = type;
    }
  }

  public static class MissionIdentifierExt
  {
    public static MissionIdentifier Identify(this MissionSourceInfo src)
    {
      string map = src.Map;
      string id = Path.GetFileNameWithoutExtension(map);

      if (string.IsNullOrWhiteSpace(map)) { return new MissionIdentifier(id, MissionType.INVALID); } 
      if (IsAtrediesMain(id)) { return new MissionIdentifier(id, MissionType.MAIN_ATREIDES_CAMPAIGN); }
      if (IsHarkonnenMain(id)) { return new MissionIdentifier(id, MissionType.MAIN_HARKONNEN_CAMPAIGN); }
      if (IsOrdosMain(id)) { return new MissionIdentifier(id, MissionType.MAIN_ORDOS_CAMPAIGN); }

      return new MissionIdentifier(id, MissionType.CUSTOM_CAMPAIGN);
    }

    private static bool IsAtrediesMain(string id) { return id != null && IsHouseMain(id.ToUpper(), 'A'); }
    private static bool IsHarkonnenMain(string id) { return id != null && IsHouseMain(id.ToUpper(), 'H'); }
    private static bool IsOrdosMain(string id) { return id != null && IsHouseMain(id.ToUpper(), 'O'); }

    private static bool IsHouseMain(string idLowerCase, char houseLetter)
    {
      return idLowerCase.Length == 4
          && (idLowerCase[0] == houseLetter)
          && (idLowerCase[1] >= '1' && idLowerCase[1] <= '9')
          && (idLowerCase[2] == 'V')
          && (idLowerCase[3] == '1' || idLowerCase[3] == '2')
          ;
    }
  }
}
