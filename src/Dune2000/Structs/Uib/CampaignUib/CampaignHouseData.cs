using Dune2000.FileFormats.Uib;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Uib
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 2600, Pack = 1)]
  public struct CampaignHouseData
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = CampaignUibFile.MAX_MISSIONS + 1)]
    public CampaignMissionData[] Missions;
    #endregion
  }
}
