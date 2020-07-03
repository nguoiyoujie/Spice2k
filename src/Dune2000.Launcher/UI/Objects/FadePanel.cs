using Dune2000.Launcher.Util;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.Objects
{
  public partial class FadePanel : Panel
  {
    private Bitmap _bg;
    private Bitmap _black;
    private Bitmap _fg;

    private Bitmap _currFade;
    private Bitmap _tgtFade;
    private int _fadeSteps;
    private int _fadeTotalSteps;

    public UpdateDelegate FadeFinished;

    public FadePanel()
    {
      InitializeComponent();
      DoubleBuffered = true;
    }

    public void CaptureBackground(Control parent)
    {
      _black?.Dispose();
      _bg?.Dispose();

      Rectangle r = parent.DisplayRectangle;
      _black = new Bitmap(r.Width, r.Height);
      Graphics gblack = Graphics.FromImage(_black);
      gblack.Clear(Color.Black);
      _bg = parent.PrintClientRectangleToBitmap();
    }

    public void CaptureForeground(Control parent)
    {
      _fg?.Dispose();

      if (!(parent is Form))
      {
        _fg = new Bitmap(_bg);
        Rectangle r = parent.DisplayRectangle;
        parent.DrawToBitmap(_fg, r);
      }
      else
      {
        _fg = parent.PrintClientRectangleToBitmap();
      }
    }


    public void SetFade(int steps = 5, FadeStyle style = FadeStyle.NOFADE)
    {
      if (IsDisposed) { return; }
      if (style == FadeStyle.NOFADE) { return; }
      if (steps <= 0) { return; }

      InitFade(style);

      _fadeSteps = steps;
      _fadeTotalSteps = steps;
      BackgroundImage = _currFade;
      Visible = true;
      tmFade.Enabled = true;
    }

    public void InitFade(FadeStyle style)
    {
      switch (style)
      {
        case FadeStyle.FADEIN_FROM_BLACK:
          _currFade = _black;
          _tgtFade = _fg;
          break;

        case FadeStyle.FADEIN_FROM_BACKGROUND:
          _currFade = _bg;
          _tgtFade = _fg;
          break;

        case FadeStyle.FADEOUT_TO_BLACK:
          _currFade = _bg;
          _tgtFade = _black;
          break;

        case FadeStyle.FADEOUT_TO_BACKGROUND:
        default:
          _currFade = null;
          _tgtFade = null;
          break;
      }
    }

    private void TmFade_Tick(object sender, EventArgs e)
    {
      if (IsDisposed) { return; }
      Invalidate(); // force repaint
      _fadeSteps--;
      if (_fadeSteps <= 0 || _fadeTotalSteps <= 0 || _currFade == null || _tgtFade == null)
      {
        tmFade.Enabled = false;
        Visible = false;
        FadeFinished?.Invoke();
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      // Fade effect
      base.OnPaint(pe);

      if (_tgtFade != null && _fadeSteps > 0 && _fadeTotalSteps > 0)
      {
        Image f = _tgtFade;
        ColorMatrix matrix = new ColorMatrix
        {
          Matrix33 = (_fadeTotalSteps - _fadeSteps + 1) / (float)_fadeTotalSteps // add 1 to achieve full black at end of cycle.
        };
        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        pe.Graphics.DrawImage(f, new Rectangle(0, 0, Width, Height), 0, 0, f.Width, f.Height, GraphicsUnit.Pixel, attributes);
      }
    }

    private void DisposeInner()
    {
      _black?.Dispose();
      _bg?.Dispose();
      _fg?.Dispose();
    }
  }
}
