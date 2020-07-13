using Dune2000.Structs.Pal;
using Dune2000.Structs.R16;
using Primrose.FileFormats.Common;
using System.Collections.Generic;
using System.IO;

namespace Dune2000.FileFormats.R16
{
  public class ResourceFile : IFile
  {
    public readonly List<ResourceElement> Resources = new List<ResourceElement>();

    public void ReadFromFile(string filePath)
    {
      Resources.Clear();
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          Palette_15Bit currentPalette = new Palette_15Bit();
          while (fs.Position < fs.Length)
          {
            long p = fs.Position;
            ResourceElement rex = new ResourceElement();
            rex.Read(reader, ref currentPalette);
            Resources.Add(rex);
          }
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        Palette_15Bit currentPalette = new Palette_15Bit();
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          foreach (ResourceElement rex in Resources)
          {
            rex.Write(writer, ref currentPalette);
          }
        }
      }
    }
  }
}
