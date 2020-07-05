using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Pal
{
  /// <summary>
  /// A palette with 256 indices, each mapped to a 24-bit color (True Color: https://en.wikipedia.org/wiki/Color_depth#True_color_(24-bit))
  /// </summary>
  public unsafe struct Palette_24Bit : IPalette
  {
    private fixed byte Data[256 * 3];

    public void Read(BinaryReader reader)
    {
      int count = Marshal.SizeOf(typeof(Palette_24Bit));
      byte[] readBuffer = reader.ReadBytes(count);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (Palette_24Bit)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Palette_24Bit));
      handle.Free();
    }

    public void Write(BinaryWriter writer)
    {
      int count = Marshal.SizeOf(typeof(Palette_24Bit));
      byte[] writeBuffer = new byte[count];
      GCHandle handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
      Marshal.StructureToPtr(this, handle.AddrOfPinnedObject(), true);
      writer.Write(writeBuffer, 0, writeBuffer.Length);
      handle.Free();
    }

    public Color Get(int index)
    {
      int id = index * 3;
      return Color.FromArgb(Data[id], Data[id + 1], Data[id + 2]);
    }

    public void Set(int index, Color color)
    {
      int id = index * 3;
      Data[id] = color.R;
      Data[id + 1] = color.G;
      Data[id + 2] = color.B;
    }
  }
}
