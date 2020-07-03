using Primrose.FileFormats.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dune2000.FileFormats.Uib
{
  public abstract class UibFileBase<T> : IFile
  {
    public readonly List<UibEntry<T>> Entries = new List<UibEntry<T>>();

    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          uint count = reader.ReadUInt32();
          for (uint i = 0; i < count; i++)
          {
            ushort len = reader.ReadUInt16();
            string key = Encoding.Default.GetString(reader.ReadBytes(len)).Trim('\0');

            T value = ReadValue(reader);

            Entries.Add(new UibEntry<T>(key, value));
          }
        }
      }
    }

    protected abstract T ReadValue(BinaryReader reader);
    protected abstract void WriteValue(BinaryWriter writer, T value);

    public void WriteToFile(string destinationPath)
    {
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          writer.Write((uint)Entries.Count);
          foreach (UibEntry<T> entry in Entries)
          {
            string key = entry.Key ?? "";

            // add 1 to length to include the NUL terminator
            writer.Write((ushort)(key.Length + 1));
            writer.Write(Encoding.Default.GetBytes(key));
            writer.Write('\0');

            WriteValue(writer, entry.Value);
          }
        }
      }
    }

    public T GetFirst(string key)
    {
      if (key == null) { return default; }
      foreach (UibEntry<T> entry in Entries)
      {
        if (entry.Key == key)
          return entry.Value;
      }
      return default;
    }
  }
}
