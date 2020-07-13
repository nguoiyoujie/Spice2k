using System.Drawing;
using System.IO;

namespace Dune2000.Structs.Pal
{
  public interface IPalette
  {
    Color Get(int index);
    void Set(int index, Color color);
    void FromBitmap(Bitmap bitmap);
    Bitmap ToBitmap();
    bool Contains(Color color);
    int Count(Color color);
    int IndexOf(Color color);
    void Import(IPalette source);
    int GetClosestIndexFromColor(Color color, out int difference);
  }
}
