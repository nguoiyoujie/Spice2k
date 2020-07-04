using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.R16
{
  public enum PaletteType : byte
  {
    EMPTY_ENTRY = 0, // No image data is stored here. Skip and proceed to the next entry.
    NEW_PALETTE = 1,
    USE_PREVIOUS = 2
  }

  public class ResourceElement
  {
    // Each element represents a frame of defined size [FrameSize].
    // An image sits within this frame, at an offset [ImageOffset] and with its own size [ImageSize].
    // ... unless this is an empty entry, then the whole element is represented by a single zero byte.

    public PaletteType PaletteType; // likely an enum for something
    public int ImageWidth;
    public int ImageHeight;
    public int ImageOffsetX;
    public int ImageOffsetY;
    public int ImageHandle;   // function unknown
    public int PaletteHandle; // function unknown
    public byte BitsPerPixel;
    public byte FrameWidth;
    public byte FrameHeight;
    public byte Alignment; // function unknown
    public byte[] ImageData;
    public ResPalette Palette;

    public bool IsEmpty { get { return PaletteType == PaletteType.EMPTY_ENTRY; } }
    public int2 ImageSize { get { return new int2(ImageWidth, ImageHeight); } set { ImageWidth = value.x; ImageHeight = value.y; } }
    public int2 ImageOffset { get { return new int2(ImageOffsetX, ImageOffsetY); } set { ImageOffsetX = value.x; ImageOffsetY = value.y; } }
    public byte2 FrameSize { get { return new byte2(FrameWidth, FrameHeight); } set { FrameWidth = value.x; FrameHeight = value.y; } }

    public void Read(BinaryReader reader, ref ResPalette currentPalette)
    {
      PaletteType = (PaletteType)reader.ReadByte();
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // no data. All else is irrelevant.
        return;
      }

      ImageWidth = reader.ReadInt32();
      ImageHeight = reader.ReadInt32();
      ImageOffsetX = reader.ReadInt32();
      ImageOffsetY = reader.ReadInt32();
      ImageHandle = reader.ReadInt32();
      PaletteHandle = reader.ReadInt32();
      BitsPerPixel = reader.ReadByte();
      FrameWidth = reader.ReadByte();
      FrameHeight = reader.ReadByte();
      Alignment = reader.ReadByte();

      // insanity
      if (ImageWidth < 0) { throw new InvalidDataException("Unexpected negative number for image width! (Value = {0})".F(ImageWidth)); }
      if (ImageHeight < 0) { throw new InvalidDataException("Unexpected negative number for image height! (Value = {0})".F(ImageHeight)); }
      if (FrameWidth < 0) { throw new InvalidDataException("Unexpected negative number for frame width! (Value = {0})".F(FrameWidth)); }
      if (FrameHeight < 0) { throw new InvalidDataException("Unexpected negative number for frame height! (Value = {0})".F(FrameHeight)); }

      int pixels = ImageWidth * ImageHeight;
      if (BitsPerPixel == 8)
      {
        ImageData = reader.ReadBytes(pixels);
      }
      else if (BitsPerPixel == 16)
      {
        ImageData = reader.ReadBytes(pixels * 2);
      }
      else
      {
        // pixelated insanity
        throw new InvalidDataException("Unexpected bits per pixel! (Value = {0})".F(BitsPerPixel));
      }

      if (BitsPerPixel == 8)
      {
        if (PaletteHandle != 0) // seen from the old editor, is this needed?
        {
          switch (PaletteType)
          {
            case PaletteType.NEW_PALETTE:
              currentPalette.Read(reader);
              break;

            case PaletteType.USE_PREVIOUS:
              break;
          }
        }
      }
      Palette = currentPalette;
    }

    public void Write(BinaryWriter writer, ref ResPalette prevPalette)
    {
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // no data. Wirte a single null byte.
        writer.Write('\0');
        return;
      }

      if (prevPalette.Equals(Palette)) 
      { 
        PaletteType = PaletteType.USE_PREVIOUS;
      }
      else
      {
        PaletteType = PaletteType.NEW_PALETTE;
        prevPalette = Palette; // for the next entry
      }

      writer.Write((byte)PaletteType);
      writer.Write(ImageWidth);
      writer.Write(ImageHeight);
      writer.Write(ImageOffsetX);
      writer.Write(ImageOffsetY);
      writer.Write(ImageHandle);
      writer.Write(PaletteHandle);
      writer.Write(BitsPerPixel);
      writer.Write(FrameWidth);
      writer.Write(FrameHeight);
      writer.Write(Alignment);
      writer.Write(ImageData);

      if (PaletteType == PaletteType.NEW_PALETTE)
      {
        Palette.Write(writer);
      }
    }

    public Bitmap Draw(bool includeFrame, bool makeTransparent)
    {
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // at least draw something so it does not error out.
        Bitmap empty = new Bitmap(1, 1);
        empty.MakeTransparent();
        return empty;
      }

      Bitmap bmp = (includeFrame) ? new Bitmap(FrameWidth, FrameHeight) : new Bitmap(ImageWidth, ImageHeight);

      if (BitsPerPixel == 8)
      {
        for (int x = 0; x < ImageWidth; x++)
          for (int y = 0; y < ImageHeight; y++)
          {
            int pos = x + y * ImageWidth;
            byte data8 = ImageData[pos];
            bmp.SetPixel(x, y, Palette.Get(data8));
          }
      }
      else if (BitsPerPixel == 16)
      {
        for (int x = 0; x < ImageWidth; x++)
          for (int y = 0; y < ImageHeight; y++)
          {
            int pos = (x + y * ImageWidth) * 2;
            ushort data16 = BitConverter.ToUInt16(ImageData, pos);
            bmp.SetPixel(x, y, ResPalette.ConvertColor(data16));
          }
      }
      else
      {
        throw new InvalidDataException("Unexpected bits per pixel! (Value = {0})".F(BitsPerPixel));
      }

      if (makeTransparent)
      {
        bmp.MakeTransparent(Palette.Get(0));
      }

      if (includeFrame)
      {
        Bitmap bmpFrame = new Bitmap(FrameWidth, FrameHeight);
        bmpFrame.MakeTransparent();
        Graphics g = Graphics.FromImage(bmpFrame);
        g.DrawImageUnscaled(bmp, new Point(ImageOffsetX, ImageOffsetY));
        return bmpFrame;
      }
      else
      {
        return bmp;
      }
    }
  }

  public unsafe struct ResPalette
  {
    // each color represented by a 16-bit integer.
    public int Memory; //?
    public int PaletteHandle; //?
    private fixed ushort Data[256];

    public void Read(BinaryReader reader)
    {
      int count = Marshal.SizeOf(typeof(ResPalette));
      byte[] readBuffer = reader.ReadBytes(count);
      GCHandle handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
      this = (ResPalette)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(ResPalette));
      handle.Free();
    }

    public void Write(BinaryWriter writer)
    {
      int count = Marshal.SizeOf(typeof(ResPalette));
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
