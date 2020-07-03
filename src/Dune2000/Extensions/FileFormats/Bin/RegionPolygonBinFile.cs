using Dune2000.Extensions.Structs.Bin;
using Primrose.FileFormats.Common;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Extensions.FileFormats.Bin
{
  public class RegionPolygonBinFile : IFile
  {
    // The map polygon data, extracted from Dune2000.exe, starting from 0x04BE3FC (byte 0x00bd7fc)
    // Repurposed to help draw the polygon shapes of each of the 27 regions in the campaign map. 
    // This defines the clickable regions of the map, which cannot be modified by campaign.uib.

    public readonly List<RegionPolygonData> Polygons = new List<RegionPolygonData>();

    public void ReadFromFile(string filePath)
    {
      int count = Marshal.SizeOf(typeof(RegionPolygonData));
      Polygons.Clear();
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          while (fs.Position < fs.Length)
          {
            byte[] readBuffer = reader.ReadBytes(count);
            GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            RegionPolygonData data = (RegionPolygonData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(RegionPolygonData));
            handle.Free();
            Polygons.Add(data);
          }
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      int count = Marshal.SizeOf(typeof(RegionPolygonData));
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          foreach (RegionPolygonData data in Polygons)
          {
            byte[] writeBuffer = new byte[count];
            GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(data, handle.AddrOfPinnedObject(), true);
            writer.Write(writeBuffer, 0, writeBuffer.Length);
            handle.Free();
          }
        }
      }
    }
  }
}
