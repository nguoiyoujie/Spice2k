using Dune2000.Structs.Pal;
using Dune2000.Structs.R16;
using Primrose.FileFormats.Common;
using Primrose.Primitives.Extensions;
using System;
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
          // Commented code is used to simulate combination of ResourceFile and palette for a lazy generation of bitmap files

          //int c = 0;
          //Directory.CreateDirectory(@"./dataR16/");
          //Palette_24Bit_64 basePalette = new Palette_24Bit_64();
          //using (FileStream fs2 = new FileStream(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\bin\PALETTE.BIN", FileMode.Open))
          //{
          //  using (BinaryReader reader2 = new BinaryReader(fs2))
          //  {
          //    basePalette.Read(reader2);
          //  }
          //}

          while (fs.Position < fs.Length)
          {
            long p = fs.Position;
            //Console.WriteLine("Resource {0:0000} at location {1:X8}".F(c, p));
            ResourceElement rex = new ResourceElement();
            rex.Read(reader, ref currentPalette);
            //rex.GetBitmap(ref basePalette, false, true).Save(@"./dataR16/test_{0:0000}_{1:X8}.png".F(c, p));
            //c++;
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
