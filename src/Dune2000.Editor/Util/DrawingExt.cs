using Primrose.Primitives.ValueTypes;
using System.Drawing;

namespace Dune2000.Editor.Util
{
  internal static class DrawingExt
  {
    public static Point ToPoint(this int2 value) { return new Point(value.x, value.y); }
    public static Size ToSize(this int2 value) { return new Size(value.x, value.y); }

    public static Point ToPoint(this float2 value) { return new Point((int)value.x, (int)value.y); }
    public static Size ToSize(this float2 value) { return new Size((int)value.x, (int)value.y); }
    public static PointF ToPointF(this float2 value) { return new PointF(value.x, value.y); }
    public static SizeF ToSizeF(this float2 value) { return new SizeF(value.x, value.y); }

    public static float2 ToFloat2(this Point value) { return new float2(value.X, value.Y); }
    public static float2 ToFloat2(this Size value) { return new float2(value.Width, value.Height); }
    public static float2 ToFloat2(this PointF value) { return new float2(value.X, value.Y); }
    public static float2 ToFloat2(this SizeF value) { return new float2(value.Width, value.Height); }
  }
}
