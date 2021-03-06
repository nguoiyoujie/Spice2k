﻿using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 15-bit color (High Color: https://en.wikipedia.org/wiki/High_color)
  /// Each color is stored in a 16-bit space, in this format XRRRRRGGGGGBBBBB.
  /// </summary>
  public class Palette_15Bit : IPalette, IEquatable<Palette_15Bit>
  {
    private readonly ushort[] _raw = new ushort[0x100];
    public ushort[] Data
    {
      get
      {
        ushort[] ret = new ushort[0x100];
        for (int i = 0; i < 0x100; i++)
        {
          ret[i] = _raw[i];
        }
        return ret;
      }
      set
      {
        if (value.Length > 0x100) { throw new InvalidDataException("Palette only accepts an array of up to 256 elements!"); }
        for (int i = 0; i < value.Length; i++)
        {
          _raw[i] = value[i];
        }

        for (int i = value.Length; i < 0x100; i++)
        {
          _raw[i] = 0;
        }
      }
    }

    public void Read(BinaryReader reader)
    {
      byte[] readBuffer = reader.ReadBytes(0x200);
      Buffer.BlockCopy(readBuffer, 0, _raw, 0, 0x200);
    }

    public void Write(BinaryWriter writer)
    {
      byte[] writeBuffer = new byte[0x200];
      Buffer.BlockCopy(_raw, 0, writeBuffer, 0, 0x200);
      writer.Write(writeBuffer);
    }

    public int Read(BinaryReader reader, int maxLength)
    {
      int len = 0x200.Min(maxLength);
      byte[] readBuffer = reader.ReadBytes(len);
      Buffer.BlockCopy(readBuffer, 0, _raw, 0, len);
      return len;
    }

    public int Write(BinaryWriter writer, int maxLength)
    {
      int len = 0x200.Min(maxLength);
      byte[] writeBuffer = new byte[len];
      Buffer.BlockCopy(_raw, 0, writeBuffer, 0, len);
      writer.Write(writeBuffer);
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
      int r = Round(colour.R / 255f * 31f) << 10;
      int g = Round(colour.G / 255f * 31f) << 5;
      int b = Round(colour.B / 255f * 31f);
      int value = r | g | b;
      return Convert.ToUInt16(value);
    }

    private static int Round(float value)
    {
      return (int)value + ((value % 1 >= 0.5f) ?  1 : 0);
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

    public void Import(IPalette source)
    {
      for (int i = 0; i < 256; i++)
      {
        Set(i, source.Get(i));
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

    public Palette_15Bit Clone()
    {
      Palette_15Bit ret = new Palette_15Bit();
      Buffer.BlockCopy(_raw, 0, ret._raw, 0, Buffer.ByteLength(_raw));
      return ret;
    }
  }
}
