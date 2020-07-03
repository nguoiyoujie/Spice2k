using Dune2000.Enums;
using Dune2000.Structs.Uib;
using System.IO;
using System.Text;

namespace Dune2000.FileFormats.Uib
{
  public class MenusUibFile : UibFileBase<MenusUibData>
  {
    protected override MenusUibData ReadValue(BinaryReader reader)
    {
      ushort len = reader.ReadUInt16();
      string menu = Encoding.Default.GetString(reader.ReadBytes(len)).Trim('\0');
      int fadeIn = reader.ReadInt32();
      int fadeOut = reader.ReadInt32();

      return new MenusUibData(menu, (FadeAction)fadeIn, (FadeAction)fadeOut);
    }

    protected override void WriteValue(BinaryWriter writer, MenusUibData value)
    {
      string val = value.Menu ?? "";
      int fadeIn = (int)value.FadeIn;
      int fadeOut = (int)value.FadeOut;
      writer.Write((ushort)(val.Length + 1));
      writer.Write(Encoding.Default.GetBytes(val));
      writer.Write('\0');
      writer.Write(fadeIn);
      writer.Write(fadeOut);
    }
  }
}
