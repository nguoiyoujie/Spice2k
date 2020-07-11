using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 15-bit color (High Color: https://en.wikipedia.org/wiki/High_color)
  /// </summary>
  [StructLayout(LayoutKind.Sequential, Size = 0x200)]
  public unsafe struct Palette_15Bit : IPalette, IEquatable<Palette_15Bit>
  {
    private fixed ushort _raw[256];
    public ushort[] Data
    {
      get
      {
        ushort[] ret = new ushort[256];
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
          _raw[i] = 0;
        }
      }
    }

    public int Read(BinaryReader reader, int maxLength)
    {
      int count = Marshal.SizeOf(typeof(Palette_15Bit));
      int len = count.Min(maxLength);
      byte[] readBuffer = new byte[count];
      reader.ReadBytes(len).CopyTo(readBuffer, 0);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (Palette_15Bit)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Palette_15Bit));
      handle.Free();
      return len;
    }

    public void Read(BinaryReader reader)
    {
      int count = Marshal.SizeOf(typeof(Palette_15Bit));
      byte[] readBuffer = reader.ReadBytes(count);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (Palette_15Bit)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Palette_15Bit));
      handle.Free();
    }

    public void Write(BinaryWriter writer)
    {
      int count = Marshal.SizeOf(typeof(Palette_15Bit));
      byte[] writeBuffer = new byte[count];
      GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
      Marshal.StructureToPtr(this, handle.AddrOfPinnedObject(), true);
      writer.Write(writeBuffer, 0, writeBuffer.Length);
      handle.Free();
    }

    public int Write(BinaryWriter writer, int maxLength)
    {
      int count = Marshal.SizeOf(typeof(Palette_15Bit));
      byte[] writeBuffer = new byte[count];
      GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
      Marshal.StructureToPtr(this, handle.AddrOfPinnedObject(), true);
      int len = writeBuffer.Length.Min(maxLength);
      writer.Write(writeBuffer, 0, len);
      handle.Free();
      return len;
    }

    public Color Get(int index)
    {
      return ConvertColor(_raw[index]);
    }

    public void Set(int index, Color color)
    {
      _raw[index] = ConvertColor(color);
    }

    // 16 bit stored as XRRRRRGGGGGBBBBB
    public static Color ConvertColor(ushort colour)
    {
      byte r = (byte)(colour >> 10 & 31);
      byte g = (byte)(colour >> 5 & 31);
      byte b = (byte)(colour & 31);
      r = Convert.ToByte(255f * r / 31f);
      g = Convert.ToByte(255f * g / 31f);
      b = Convert.ToByte(255f * b / 31f);
      return Color.FromArgb(r, g, b);
    }

    public static ushort ConvertColor(Color colour)
    {
      int r = (int)(colour.R / 255f * 31f) << 10;
      int g = (int)(colour.G / 255f * 31f) << 5;
      int b = (int)(colour.B / 255f * 31f);
      int value = r | g | b;
      return Convert.ToUInt16(value);
    }

    public bool Equals(Palette_15Bit other)
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
          _raw[i] = ConvertColor(bitmap.GetPixel(x, y));
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
          bitmap.SetPixel(x, y, ConvertColor(_raw[i]));
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
  }
}
