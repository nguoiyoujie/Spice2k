using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 15-bit color (High Color: https://en.wikipedia.org/wiki/High_color)
  /// </summary>
  public unsafe struct Palette_15Bit : IPalette
  {
    private fixed ushort Data[256];

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

    public Color Get(int index)
    {
      return ConvertColor(Data[index]);
    }

    public void Set(int index, Color color)
    {
      Data[index] = ConvertColor(color);
    }

    // 16 bit stored as ?RRRRRGGGGGBBBBB
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
  }
}
