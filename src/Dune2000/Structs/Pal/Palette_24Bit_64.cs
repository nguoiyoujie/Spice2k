using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 24-bit color (True Color: https://en.wikipedia.org/wiki/Color_depth#True_color_(24-bit))
  /// This version treats value 64 as the highest intensity.
  /// </summary>
  public unsafe struct Palette_24Bit_64 : IPalette
  {
    private fixed byte Data[256 * 3];

    public void Read(BinaryReader reader)
    {
      int count = Marshal.SizeOf(typeof(Palette_24Bit_64));
      byte[] readBuffer = reader.ReadBytes(count);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (Palette_24Bit_64)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Palette_24Bit_64));
      handle.Free();
    }

    public void Write(BinaryWriter writer)
    {
      int count = Marshal.SizeOf(typeof(Palette_24Bit_64));
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
      int r = Data[id] * 4;
      int g = Data[id + 1] * 4;
      int b = Data[id + 2] * 4;

      return Color.FromArgb(r, g, b);
    }

    public void Set(int index, Color color)
    {
      int id = index * 3;
      // 256 / 64 = 4
      Data[id] = (byte)(color.R / 4);
      Data[id + 1] = (byte)(color.G / 4);
      Data[id + 2] = (byte)(color.B / 4);
    }
  }
}
