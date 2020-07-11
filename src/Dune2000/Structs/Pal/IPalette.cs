using System.Drawing;
using System.IO;

namespace Dune2000.Structs.Pal
{
  public interface IPalette
  {
    void Read(BinaryReader reader);
    void Write(BinaryWriter writer);
    Color Get(int index);
    void Set(int index, Color color);
    void FromBitmap(Bitmap bitmap);
    Bitmap ToBitmap();
    int GetClosestIndexFromColor(Color color, out int difference);
  }
}
