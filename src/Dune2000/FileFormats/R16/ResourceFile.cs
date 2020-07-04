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
          ResPalette currentPalette = new ResPalette();
          int c = 0;
          while (fs.Position < fs.Length)
          {
            long p = fs.Position;
            Console.WriteLine("Resource {0:0000} at location {1:X8}".F(c, p));
            ResourceElement rex = new ResourceElement();
            rex.Read(reader, ref currentPalette);
            rex.Draw(false, true).Save(@"./dataR16/test_{0:0000}_{1:X8}.png".F(c, p));
            c++;
            Resources.Add(rex); 
          }
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        ResPalette currentPalette = new ResPalette();
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
