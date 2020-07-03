using Primrose.FileFormats.Common;
using System.IO;

namespace Dune2000.FileFormats.Map
{
  public class MapFile : IFile
  {
    public ushort Width;
    public ushort Height;

    public ushort[,] TileIndex;
    public ushort[,] ObjectIndex;

    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          Width = reader.ReadUInt16();
          Height = reader.ReadUInt16();
          TileIndex = new ushort[Width, Height];
          ObjectIndex = new ushort[Width, Height];
          for (int i = 0; i < Height; i++)
          {
            for (int j = 0; j < Width; j++)
            {
              TileIndex[j, i] = reader.ReadUInt16();
              ObjectIndex[j, i] = reader.ReadUInt16();
            }
          }
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          writer.Write(Width);
          writer.Write(Height);
          for (int i = 0; i < Height; i++)
          {
            for (int j = 0; j < Width; j++)
            {
              writer.Write(TileIndex[j, i]);
              writer.Write(ObjectIndex[j, i]);
            }
          }
        }
      }
    }
  }
}
