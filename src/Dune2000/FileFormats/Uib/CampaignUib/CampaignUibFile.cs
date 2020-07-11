using Dune2000.Enums;
using Dune2000.Structs.Uib;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.FileFormats.Uib
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 7800, Pack = 1)]
  public struct CampaignUibFile
  {
    public const int MAX_PLAYABLEHOUSES = 3;
    public const int MAX_MISSIONS = 9;

    #region Layout // Do not modify unless unless you know what you are doing
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PLAYABLEHOUSES)]
    public CampaignHouseData[] Houses;
    #endregion

    public void ReadFromFile(string filePath)
    {
      int count = Marshal.SizeOf(typeof(CampaignUibFile));
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          byte[] readBuffer = reader.ReadBytes(count);
          GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
          this = (CampaignUibFile)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CampaignUibFile));
          handle.Free();
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      int count = Marshal.SizeOf(typeof(CampaignUibFile));
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          byte[] writeBuffer = new byte[count];
          GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
          Marshal.StructureToPtr(this, handle.AddrOfPinnedObject(), true);
          writer.Write(writeBuffer, 0, writeBuffer.Length);
          handle.Free();
        }
      }
    }

    public CampaignUibFile Clone()
    {
      CampaignUibFile clone = new CampaignUibFile();
      clone.Houses = new CampaignHouseData[MAX_PLAYABLEHOUSES];
      for (int i = 0; i < MAX_PLAYABLEHOUSES; i++)
      {
        clone.Houses[i].Missions = (CampaignMissionData[])(Houses[i].Missions.Clone());
      }
      return clone;
    }

    public void GetRegionOwnership(ref House[] regionOwners, House playerHouse, int scenario, AnimStage stage)
    {
      for (int i = 0; i < regionOwners.Length; i++)
      {
        regionOwners[i] = (House)0xFF;
      }

      for (int scen = 0; scen < scenario; scen++)
      {
        CampaignMissionData data = Houses[(int)playerHouse].Missions[scen];

        House[] animOrder = new House[] {
            data.RegionAnim_House1,
            data.RegionAnim_House2,
            data.RegionAnim_House3
          };

        for (int h = 0; h < animOrder.Length; h++)
        {
          if (scen < scenario - 1 || (int)stage > h)
          {
            House ihouse = animOrder[h];
            if (playerHouse == ihouse)
            {
              if (data.RegionID1 > 0 && data.RegionID1 <= regionOwners.Length) { regionOwners[data.RegionID1 - 1] = ihouse; }
              if (data.RegionID2 > 0 && data.RegionID2 <= regionOwners.Length) { regionOwners[data.RegionID2 - 1] = ihouse; }
            }
            switch (ihouse)
            {
              case House.ATREIDES:
                foreach (int r in data.RegionsAwardedToAtreides)
                {
                  if (r > 0 && r <= regionOwners.Length) { regionOwners[r - 1] = ihouse; }
                }
                break;

              case House.HARKONNEN:
                foreach (int r in data.RegionsAwardedToHarkonnen)
                {
                  if (r > 0 && r <= regionOwners.Length) { regionOwners[r - 1] = ihouse; }
                }
                break;

              case House.ORDOS:
                foreach (int r in data.RegionsAwardedToOrdos)
                {
                  if (r > 0 && r <= regionOwners.Length) { regionOwners[r - 1] = ihouse; }
                }
                break;
            }
          }
        }
      }
    }
  }
}
