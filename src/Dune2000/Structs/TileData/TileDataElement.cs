using Dune2000.Enums;

namespace Dune2000.Structs.TileData
{
  public struct TileDataElement
  {
    public int Raw;

    public byte B1
    {
      get { return (byte)((Raw & unchecked((int)0xFF000000)) >> 24); }
      set { Raw = Raw & 0x00FFFFFF | (value << 24); }
    }

    public byte B2
    {
      get { return (byte)((Raw & 0xFF0000) >> 16); }
      set { Raw = Raw & unchecked((int)0xFF00FFFF) | (value << 16); }
    }

    public byte B3
    {
      get { return (byte)((Raw & 0xFF00) >> 8); }
      set { Raw = Raw & unchecked((int)0xFFFF00FF) | (value << 8); }
    }

    public byte B4
    {
      get { return (byte)(Raw & 0xFF); }
      set { Raw = Raw & unchecked((int)0xFFFFFF00) | value; }
    }

    public byte DataType // 0x00 = Unit, 0x80 = Structure, 0x40 = Spice Bloom? Others = ?
    {
      get { return B1; }
      set { B1 = value; }
    }

    public House House
    {
      get { return (House)B2; }
      set { B2 = (byte)value; }
    }

    public BuildingType Structure // to be used with DataType = 0x80
    {
      get { return (BuildingType)B4; }
      set { B4 = (byte)value; }
    }

    public UnitType Unit // to be used with DataType = 0x00
    {
      get { return (UnitType)B4; }
      set { B4 = (byte)value; }
    }
  }
}
