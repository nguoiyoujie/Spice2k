using Primrose.Primitives.ValueTypes;
using System;
using System.Runtime.InteropServices;

namespace Dune2000.Extensions.Structs.Bin
{
  [StructLayout(LayoutKind.Explicit, Size = 72)]
  public unsafe struct RegionPolygonData
  {
    public const int MAX_POINTS = 8;

    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public uint Count;

    [FieldOffset(4)]
    public fixed int Data[17];
    #endregion

    public int2[] Polygon
    {
      get
      {
        int2[] p = new int2[Count];
        for (int i = 0; i < p.Length; i++)
        {
          p[i].x = Data[2 * i];
          p[i].y = Data[2 * i + 1];
        }
        return p;
      }
      set
      {
        if (value.Length > MAX_POINTS)
        {
          throw new Exception("Input is limited to " + MAX_POINTS + " items");
        }
        Count = (uint)value.Length;
        for (int i = 0; i < value.Length; i++)
        {
          Data[2 * i] = value[i].x;
          Data[2 * i + 1] = value[i].y;
        }
      }
    }
  }
}
