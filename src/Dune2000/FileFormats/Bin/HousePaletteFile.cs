using Dune2000.Structs.Pal;
using Primrose.FileFormats.Common;
using System.Drawing;
using System.IO;

namespace Dune2000.FileFormats.Mis
{
  // also known as Colour.bin
  // stores 16 colors each of the 8 (or more) houses
  // Has the property to replace the last 16 entries of the normal palette (240-255)
  // Supports a variable size, in multiples of 16 houses.
  public struct HousePaletteFile : IFile
  {
    private int _houses;
    private Palette_15Bit[] _palettes;

    public int Houses { get { return _houses; } set { if (_houses < value) { _houses = value; Resize(); } } }

    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        Houses = (int)((fs.Length - 1) / 32 + 1); // 16 * 2 bytes per color
        //int sets = (int)((fs.Length - 1) / 256 + 1);
        //_palettes = new Palette_15Bit[sets];
        using (BinaryReader reader = new BinaryReader(fs))
        {
          for (int i = 0; i < _palettes.Length; i++)
          {
            _palettes[i].Read(reader);
          }
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      int bytesToWrite = Houses * 32; // 16 * 2 bytes per color
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          for (int i = 0; i < _palettes.Length; i++)
          {
            if (bytesToWrite <= 0) { break; }
            bytesToWrite -= _palettes[i].Write(writer, bytesToWrite);
          }
        }
      }
    }

    private void Resize()
    {
      int h = _houses;
      int sets = (h - 1) / 16 + 1;
      if (_palettes == null || sets > _palettes.Length)
      {
        Palette_15Bit[] list = new Palette_15Bit[sets];
        _palettes?.CopyTo(list, 0);
        _palettes = list;
      }
    }

    public Palette_15Bit[] GetPalettes()
    {
      return (Palette_15Bit[])_palettes.Clone();
    }

    public void SetPalettes(Palette_15Bit[] palettes)
    {
      _palettes = palettes;
      Houses = palettes.Length * 16;
    }

    public void FromBitmap(Bitmap bitmap)
    {
      int pixels = bitmap.Height * bitmap.Width;
      Houses = ((pixels - 1) / 16 + 1);

      int p = 0;
      int i = 0;
      for (int y = 0; y < bitmap.Height; y++)
        for (int x = 0; x < bitmap.Width; x++)
        {
          _palettes[p].Set(i, bitmap.GetPixel(x, y));
          i++;
          if (i == 256) { p++; i = 0; }
        }

      while (i < 256)
      {
        _palettes[p].Set(i, Color.Black);
        i++;
      }
    }

    public Bitmap ToBitmap()
    {
      Bitmap bitmap = new Bitmap(16, Houses);
      int p = 0;
      int i = 0;
      for (int y = 0; y < bitmap.Height; y++)
        for (int x = 0; x < bitmap.Width; x++)
        {
          bitmap.SetPixel(x, y, _palettes[p].Get(i));
          i++;
          if (i == 256) { p++; i = 0; }
        }
      return bitmap;
    }

    public IPalette Merge(IPalette destPalette, int houseIndex)
    {
      // invalid
      if (houseIndex < 0) { return destPalette; }
      int set = houseIndex / 16;
      if (_palettes == null || set >= _palettes.Length) { return destPalette; }

      int houseOffset = houseIndex * 16;

      // make a copy
      IPalette result = destPalette;
      for (int i = 0; i < 16; i++)
      {
        result.Set(240 + i, _palettes[set].Get(houseOffset + i));
      }
      return result;
    }
  }
}
