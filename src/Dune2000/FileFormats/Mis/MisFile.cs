using Dune2000.Enums;
using Dune2000.Structs.Mis;
using Primrose.FileFormats.Common;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.FileFormats.Mis
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 68066, Pack = 1)]
  public struct MisFile : IFile
  {
    public const int MAX_HOUSES = 8;
    public const int MAX_ACTIONS = 64;
    public const int MAX_CONDITIONS = 48;
    public const int MAX_TILESET_STRLEN = 200;
    public const int MAX_TILEATR_STRLEN = 200;

    #region Layout // Do not modify unless unless you know what you are doing
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOUSES)]
    public byte[] TechLevel;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOUSES)]
    public int[] Credits;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] Unknown1;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOUSES)]
    public House[] PlayAsHouse;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOUSES)]
    public MisAI[] AI;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOUSES)]
    public MisDiplomacy[] Diplomacy;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ACTIONS)]
    public MisAction[] Actions;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CONDITIONS)]
    public MisCondition[] Conditions;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TILESET_STRLEN)]
    public string Tileset;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TILEATR_STRLEN)]
    public string TileAttribute;

    public byte ActionCount;

    public byte ConditionCount;

    public int MissionTimerTicks;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 692)]
    public byte[] Unknown2;
    #endregion

    public void ReadFromFile(string filePath)
    {
      int count = Marshal.SizeOf(typeof(MisFile));
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          byte[] readBuffer = reader.ReadBytes(count);
          GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
          this = (MisFile)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MisFile));
          handle.Free();
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      int count = Marshal.SizeOf(typeof(MisFile));
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
