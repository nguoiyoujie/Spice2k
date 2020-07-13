using Dune2000.Structs.Pal;
using Primrose.FileFormats.Common;
using System.IO;

namespace Dune2000.FileFormats.Mis
{
  public class PaletteFile : IFile
  {
    public Palette_18Bit Palette = new Palette_18Bit();

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
  }
}
