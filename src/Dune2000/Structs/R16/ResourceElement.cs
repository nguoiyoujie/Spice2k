using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Pal;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;
using System.Drawing;
using System.IO;

namespace Dune2000.Structs.R16
{
  public enum PaletteType : byte
  {
    EMPTY_ENTRY = 0, // No image data is stored here. Skip and proceed to the next entry.
    EMBEDDED_PALETTE = 1,
    REFERENCED_PALETTE = 2
  }

  public class ResourceElement
  {
    // Each element represents a frame of defined size [FrameSize].
    // An image sits within this frame, at an offset [ImageOffset] and with its own size [ImageSize].
    // ... unless this is an empty entry, then the whole element is represented by a single zero byte.

    public PaletteType PaletteType;
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

    // for resources that include their own palette
    public int Memory; // function unknown
    public int PaletteHandle2;// function unknown
    public Palette_15Bit Palette;

    public bool IsEmpty { get { return PaletteType == PaletteType.EMPTY_ENTRY; } }
    public int2 ImageSize { get { return new int2(ImageWidth, ImageHeight); } set { ImageWidth = value.x; ImageHeight = value.y; } }
    public int2 ImageOffset { get { return new int2(ImageOffsetX, ImageOffsetY); } set { ImageOffsetX = value.x; ImageOffsetY = value.y; } }
    public int2 FrameSize { get { return new int2(FrameWidth, FrameHeight); } set { FrameWidth = (byte)value.x; FrameHeight = (byte)value.y; } }

    public void Read(BinaryReader reader, ref Palette_15Bit currentPalette)
    {
      PaletteType = (PaletteType)reader.ReadByte();
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // no data. All else is irrelevant. The whole resource is 1 byte of zero.
        return;
      }

      ImageWidth = reader.ReadInt32();
      ImageHeight = reader.ReadInt32();
      ImageOffsetX = reader.ReadInt32();
      ImageOffsetY = reader.ReadInt32();
      ImageHandle = reader.ReadInt32();
      PaletteHandle = reader.ReadInt32();
      BitsPerPixel = reader.ReadByte();
      FrameHeight = reader.ReadByte(); // height comes before width. Why?
      FrameWidth = reader.ReadByte();
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

      if (PaletteHandle == 0)
      {
        // use the base palette?
      }
      else
      {
        if (BitsPerPixel == 8)
        {
          switch (PaletteType)
          {
            case PaletteType.EMBEDDED_PALETTE:
              Memory = reader.ReadInt32();
              PaletteHandle2 = reader.ReadInt32();
              currentPalette.Read(reader);
              break;

            case PaletteType.REFERENCED_PALETTE:
              break;
          }
        }
        Palette = currentPalette;
      }
    }

    public void Write(BinaryWriter writer, ref Palette_15Bit prevPalette)
    {
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // no data. Wirte a single null byte.
        writer.Write('\0');
        return;
      }

      if (PaletteHandle == 0)
      {
        // base palette, just set the type and don't write another palette data in
        PaletteType = PaletteType.EMBEDDED_PALETTE;
      }
      else if (prevPalette.Equals(Palette)) 
      { 
        PaletteType = PaletteType.REFERENCED_PALETTE;
      }
      else
      {
        PaletteType = PaletteType.EMBEDDED_PALETTE;
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
      writer.Write(FrameHeight);
      writer.Write(FrameWidth);
      writer.Write(Alignment);
      writer.Write(ImageData);

      if (PaletteType == PaletteType.EMBEDDED_PALETTE)
      {
        Palette.Write(writer);
      }
    }

    public Bitmap GetBitmap(ref IPalette basePalette, ref HousePaletteFile housePalette, bool includeFrame, bool makeTransparent, int houseIndex)
    {
      if (PaletteType == PaletteType.EMPTY_ENTRY)
      {
        // at least draw something so it does not error out.
        Bitmap empty = new Bitmap(1, 1);
        empty.MakeTransparent();
        return empty;
      }

      Bitmap bmp = new Bitmap(ImageWidth, ImageHeight);
      if (BitsPerPixel == 8)
      {
        IPalette pal = (PaletteHandle == 0) ? basePalette : Palette;
        if (houseIndex != -1)
        {
          pal = housePalette.Merge(pal, houseIndex);
        }

        for (int x = 0; x < ImageWidth; x++)
          for (int y = 0; y < ImageHeight; y++)
          {
            int pos = x + y * ImageWidth;
            byte data8 = ImageData[pos];

            if (makeTransparent && data8 == 0)
            {
              bmp.SetPixel(x, y, Color.Transparent);
            }
            else if (makeTransparent && data8 == 1)
            {
              bmp.SetPixel(x, y, Color.FromArgb(128,0,0,0));
            }
            else
            {
              bmp.SetPixel(x, y, pal.Get(data8));
            }
          }
      }
      else if (BitsPerPixel == 16)
      {
        // doesn't care about palettes, as its image data is direct color
        for (int x = 0; x < ImageWidth; x++)
          for (int y = 0; y < ImageHeight; y++)
          {
            int pos = (x + y * ImageWidth) * 2;
            ushort data16 = BitConverter.ToUInt16(ImageData, pos);
            bmp.SetPixel(x, y, Palette_15Bit.ConvertColor(data16));
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
        g.DrawImageUnscaled(bmp, new Point((FrameWidth - ImageWidth) / 2, (FrameHeight - ImageHeight) / 2));
        return bmpFrame;
      }
      else
      {
        return bmp;
      }
    }
  }
}
