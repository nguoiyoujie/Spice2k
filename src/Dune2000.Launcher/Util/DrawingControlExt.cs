// Adapted from https://stackoverflow.com/questions/487661/how-do-i-suspend-painting-for-a-control-and-its-children

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dune2000.Launcher.Util
{
  internal static class DrawingControlExt
  {
    const int SRCCOPY = 0xCC0020;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    [DllImport("gdi32.dll")]
    public static extern int BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(this Control parent)
    {
      SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
    }

    public static void ResumeDrawing(this Control parent)
    {
      SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
      parent.Refresh();
    }

    public static Bitmap PrintClientRectangleToBitmap(this Control c)
    {
      Size sz = c.ClientSize;
      Bitmap bmp = new Bitmap(sz.Width, sz.Height);
      using (Graphics bmpGraphics = Graphics.FromImage(bmp))
      {
        IntPtr bmpDC = bmpGraphics.GetHdc();
        using (Graphics formGraphics = Graphics.FromHwnd(c.Handle))
        {
          IntPtr formDC = formGraphics.GetHdc();
          BitBlt(bmpDC, 0, 0, sz.Width, sz.Height, formDC, 0, 0, SRCCOPY);
          formGraphics.ReleaseHdc(formDC);
        }
        bmpGraphics.ReleaseHdc(bmpDC);
      }
      return bmp;
    }
  }
}
