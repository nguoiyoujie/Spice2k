using Dune2000.Enums;
using Primrose.Primitives.ValueTypes;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Mis
{
  [StructLayout(LayoutKind.Explicit, Size = 28)]

  public struct MisCondition
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public uint Time; // Time, Time between Intervals

    [FieldOffset(4)]
    public uint InitialDelay; // for Intervals

    [FieldOffset(8)]
    public uint Value; // RunCount for Intervals, and Threshold for Casualities, BaseDestroyedUnknown, TileRevealedUnknown, Credits

    [FieldOffset(12)]
    public uint X;

    [FieldOffset(16)]
    public uint Y;

    [FieldOffset(20)]
    public float Ratio; // for Casualities

    [FieldOffset(24)]
    public House House;

    [FieldOffset(25)]
    public ConditionType Condition;

    [FieldOffset(26)]
    public Building Building; // for BuildingExists

    [FieldOffset(27)]
    public Unit Unit; // for UnitExists

    [FieldOffset(27)]
    public Compare Compare;
    #endregion

    public uint2 Position
    {
      get
      {
        return new uint2(X, Y);
      }
      set
      {
        X = Position.x;
        Y = Position.y;
      }
    }
  }
}
