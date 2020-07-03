using System.Drawing;
using System.IO;

namespace Dune2000.FileFormats.Uib
{
  public class ColourUibFile : UibFileBase<Color>
  {
    protected override Color ReadValue(BinaryReader reader)
    {
      byte b = reader.ReadByte();
      byte g = reader.ReadByte();
      byte r = reader.ReadByte();
      reader.ReadByte();
      return Color.FromArgb(r, g, b);
    }

    protected override void WriteValue(BinaryWriter writer, Color value)
    {
      writer.Write(value.B);
      writer.Write(value.G);
      writer.Write(value.R);
      writer.Write('\0');
    }
  }
}
