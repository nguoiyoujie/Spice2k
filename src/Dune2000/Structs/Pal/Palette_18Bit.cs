using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 18-bit color (18-bit Color: https://en.wikipedia.org/wiki/Color_depth#18-bit))
  /// This version places RGB values into three bytes, with only 6 bits used per color byte (XXRRRRRRXXGGGGGGXXBBBBBB).
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Size = 0x300)]
  public unsafe struct Palette_18Bit : IPalette, IEquatable<Palette_18Bit>
  {
    private fixed byte _raw[0x300];
    public byte[] Data
    {
      get
      {
        byte[] ret = new byte[0x300];
        for (int i = 0; i < 0x300; i++)
        {
          ret[i] = _raw[i];
        }
        return ret;
      }
      set
      {
        if (value.Length != 0x300) { throw new InvalidDataException("Palette only accepts an array of 768 bytes!"); }
        for (int i = 0; i < 0x300; i++)
        {
          _raw[i] = value[i];
        }
      }
    }

    public void Read(BinaryReader reader)
    {
      int count = Marshal.SizeOf(typeof(Palette_18Bit));
      byte[] readBuffer = reader.ReadBytes(count);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (Palette_18Bit)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Palette_18Bit));
      handle.Free();
    }

    public void Write(BinaryWriter writer)
    {
      int count = Marshal.SizeOf(typeof(Palette_18Bit));
      byte[] writeBuffer = new byte[count];
      GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
      Marshal.StructureToPtr(this, handle.AddrOfPinnedObject(), true);
      writer.Write(writeBuffer, 0, writeBuffer.Length);
      handle.Free();
    }

    public Color Get(int index)
    {
      int id = index * 3;
      // 256 / 64 = 4
      int r = (_raw[id] * 4) & 0xFF;
      int g = (_raw[id + 1] * 4) & 0xFF;
      int b = (_raw[id + 2] * 4) & 0xFF;

      return Color.FromArgb(r, g, b);
    }

    public void Set(int index, Color color)
    {
      int id = index * 3;
      // 256 / 64 = 4
      _raw[id] = (byte)(color.R / 4);
      _raw[id + 1] = (byte)(color.G / 4);
      _raw[id + 2] = (byte)(color.B / 4);
    }

    public bool Equals(Palette_18Bit other)
    {
      int count = Marshal.SizeOf(typeof(Palette_18Bit));
      for (int i = 0; i < count; i++)
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
          Set(i, bitmap.GetPixel(x, y));
          i++;
        }

      while (i < 256)
      {
        _raw[i] = 0;
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
          bitmap.SetPixel(x, y, Get(i));
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
