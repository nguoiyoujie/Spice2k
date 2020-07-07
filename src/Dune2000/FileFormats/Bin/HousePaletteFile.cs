using Dune2000.Enums;
using Dune2000.Structs.Pal;
using Primrose.FileFormats.Common;
using System.IO;

namespace Dune2000.FileFormats.Mis
{
  // also known as Colour.bin
  // stores 16 colors each of the 8 (or more) houses
  // Has the property to replace the last 16 entries of the normal palette (240-255)
  public struct HousePaletteFile : IFile
  {
    public Palette_15Bit Palette;

    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          Palette.Read(reader);
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          Palette.Write(writer);
        }
      }
    }

    public IPalette Merge(IPalette destPalette, int houseIndex)
    {
      // invalid
      if (houseIndex < 0) { return destPalette; }

      // make a copy
      IPalette result = destPalette;
      int houseOffset = houseIndex * 16;
      for (int i = 0; i < 16; i++)
      {
        result.Set(240 + i, Palette.Get(houseOffset + i));
      }
      return result;
    }
  }
}
