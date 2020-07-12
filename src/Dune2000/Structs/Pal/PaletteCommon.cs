using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  public class PaletteCommon : IPalette, IEquatable<PaletteCommon>
  {
    private readonly Color[] _raw = new Color[256];
    public Color[] Data
    {
      get
      {
        Color[] ret = new Color[256];
        for (int i = 0; i < 256; i++)
        {
          ret[i] = _raw[i];
        }
        return ret;
      }
      set
      {
        if (value.Length > 256) { throw new InvalidDataException("Palette only accepts an array of up to 256 elements!"); }
        for (int i = 0; i < value.Length; i++)
        {
          _raw[i] = value[i];
        }

        for (int i = value.Length; i < 256; i++)
        {
          _raw[i] = Color.Black;
        }
      }
    }

    public Color Get(int index)
    {
      return _raw[index];
    }

    public void Set(int index, Color color)
    {
      _raw[index] = color;
    }

    public bool Equals(PaletteCommon other)
    {
      for (int i = 0; i < 256; i++)
      {
        if (_raw[i] != other._raw[i])
          return false;
      }
      return true;
    }

    public void FromBitmap(Bitmap bitmap)
    {
      if (bitmap.Height * bitmap.Width > 256) { throw new InvalidDataException("Palette only accepts an array of 256 elements!"); }

      int i = 0;
      for (int y = 0; y < bitmap.Height; y++)
        for (int x = 0; x < bitmap.Width; x++)
        {
          _raw[i] = bitmap.GetPixel(x, y);
          i++;
        }

      while (i < 256)
      {
        _raw[i] = Color.Black;
        i++;
      }
    }

    public Bitmap ToBitmap()
    {
      Bitmap bitmap = new Bitmap(16, 16);
      int i = 0;
      for (int y = 0; y < bitmap.Height; y++)
        for (int x = 0; x < bitmap.Width; x++)
        {
          bitmap.SetPixel(x, y, _raw[i]);
          i++;
        }

      return bitmap;
    }

    public Color[] GetAllColors()
    {
      Color[] ret = new Color[256];
      for (int i = 0; i < 256; i++)
      {
        ret[i] = Get(i);
      }
      return ret;
    }

    public int GetClosestIndexFromColor(Color color, out int difference)
    {
      Color[] clist = GetAllColors();

      int closest = -1;
      difference = int.MaxValue;
      for (int i = 0; i < clist.Length; i++)
      {
        int dR = color.R - clist[i].R;
        int dG = color.G - clist[i].G;
        int dB = color.B - clist[i].B;
        int d = dR * dR + dG * dG + dB * dB;
        if (difference > d)
        {
          difference = d;
          closest = i;
        }
      }
      return closest;
    }

    public void CopyTo(ref IPalette target)
    {
      for (int i = 0; i < 256; i++)
      {
        target.Set(i, Get(i));
      }
    }

    public bool Contains(Color color)
    {
      return IndexOf(color) != -1;
    }

    public int IndexOf(Color color)
    {
      for (int i = 0; i < 256; i++)
      {
        if (Get(i) == color)
          return i;
      }
      return -1;
    }

    public int Count(Color color)
    {
      int ret = 0;
      for (int i = 0; i < 256; i++)
      {
        if (Get(i) == color)
          ret++;
      }
      return ret;
    }
  }
}
