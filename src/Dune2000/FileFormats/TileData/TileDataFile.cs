using Dune2000.Structs.TileData;
using Primrose.FileFormats.Common;
using System.IO;

namespace Dune2000.FileFormats.TileData
{
  public class TileDataFile : IFile
  {
    private TileDataElement[] data;

    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        data = new TileDataElement[fs.Length / 4];
        using (BinaryReader reader = new BinaryReader(fs))
        {
          for (int i = 0; i < data.Length; i++)
          {
            data[i].Raw = reader.ReadInt32();
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
          foreach (TileDataElement e in data)
          {
            writer.Write(e.Raw);
          }
        }
      }
    }

    public int Count { get { return data.Length; } }

    public TileDataElement this[int index]
    {
      get { return data[index]; }
      set { data[index] = value; }
    }
  }
}
