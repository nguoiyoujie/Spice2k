using Dune2000.Structs.Pal;
using System.Collections.Generic;
using System.Drawing;

namespace Dune2000.Util.Palette
{
  public static class PaletteUtil
  {
    private readonly static byte[] UniqueIndices = new byte[] { 0,1,240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255 };

    public static bool HasNonUniqueSpecialIndices(this IPalette palette, out byte[] affected)
    {
      List<byte> clist = new List<byte>();
      foreach (byte b in UniqueIndices)
      {
        Color c = palette.Get(b);
        if (palette.Count(c) > 1) // include self
        {
          clist.Add(b);
        }
      }
      affected = clist.ToArray();
      return affected.Length > 0;
    }

    public static bool MakeSpecialIndicesUnique(this IPalette palette, out byte[] changed)
    {
      List<byte> clist = new List<byte>();
      foreach (byte b in UniqueIndices)
      {
        Color c = palette.Get(b);
        if (palette.Count(c) > 1) // include self
        {
          int argb = c.ToArgb();
          argb++;
          palette.Set(b, Color.FromArgb(255, Color.FromArgb(argb)));
          c = palette.Get(b);
          while (palette.Count(c) > 1) // include self
          {
            argb++;
            palette.Set(b, Color.FromArgb(255, Color.FromArgb(argb)));
            c = palette.Get(b); // use the get function, since we have 15-bit and 18-bit colour that could produce the same results with different RGB values.
          }
          clist.Add(b);
        }
      }
      changed = clist.ToArray();
      return changed.Length > 0;
    }
  }
}
