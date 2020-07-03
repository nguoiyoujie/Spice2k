using System.IO;
using System.Text;

namespace Dune2000.FileFormats.Uib
{
  public class TextUibFile : UibFileBase<string>
  {
    protected override string ReadValue(BinaryReader reader)
    {
      ushort len = reader.ReadUInt16();
      return Encoding.Default.GetString(reader.ReadBytes(len)).Trim('\0');
    }

    protected override void WriteValue(BinaryWriter writer, string value)
    {
      string val = value ?? "";
      writer.Write((ushort)(val.Length + 1));
      writer.Write(Encoding.Default.GetBytes(val));
      writer.Write('\0');
    }
  }
}
