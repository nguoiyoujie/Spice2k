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
  }
}
