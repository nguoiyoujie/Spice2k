using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.Util;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using Primrose.Primitives.Tasks;
using Primrose.Primitives.ValueTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.Objects
{
  public partial class SpriteBox : Panel
  {
    public const float MIN_SCALE = 0.01f;

    public readonly struct TextFormatInfo
    {
      public readonly string FontFamilyName;
      public readonly float FontSize;
      public readonly FontStyle FontStyle;
      public readonly StringAlignment Alignment;
      public readonly StringAlignment LineAlignment;
      public readonly StringFormatFlags FormatFlags;
      public readonly StringTrimming Trimming;
      public readonly Color TextColor;
      public readonly Color ShadowColor;
      public readonly PointF ShadowOffset;
      public readonly SizeF Size;

      public Font Font { get { return new Font(FontFamilyName, FontSize, FontStyle); } }

      public StringFormat Format
      {
        get
        {
          return new StringFormat
          {
            Alignment = Alignment,
            LineAlignment = LineAlignment,
            FormatFlags = FormatFlags,
            Trimming = Trimming
          };
        }
      }

      public TextFormatInfo(Font font, StringFormat format, SizeF size, Color textColor, Color shadowColor, PointF shadowOffset)
      {
        FontFamilyName = font.FontFamily.Name;
        FontSize = font.Size;
        FontStyle = font.Style;
        Alignment = format.Alignment;
        LineAlignment = format.LineAlignment;
        FormatFlags = format.FormatFlags;
        Trimming = format.Trimming;
        Size = size;
        TextColor = textColor;
        ShadowColor = shadowColor;
        ShadowOffset = shadowOffset;
      }
    }

    public UpdateDelegate TextCacheUpdated;
    public UpdateDelegate AnimationCycleCompleted;
    public UpdateDelegate FadeCycleCompleted;

    #region Image Properties
    [Category("Appearance")]
    [DefaultValue(AnimateType.ALWAYS)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public AnimateType Animate { get { return _animate; } set { if (_animate != value) { _animate = value; UpdateAnimCount();  UpdateState(); } } }

    [Category("Behavior")]
    [DefaultValue(false)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool LockWhenAnimating { get; set; }

    [Category("Behavior")]
    [DefaultValue(false)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool LockWhenFading { get; set; }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Image BaseImage { get { return _baseImage; } set { if (_baseImage != value) { _baseImage = value; if (value == null) { BackgroundImage = null; } InvalidateIfMouseState(MouseState.NONE); } } }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Image BackgroundDisabledImage { get { return _disabledImage; } set { if (_disabledImage != value) { _disabledImage = value; InvalidateIfDisabled(); } } }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Image BackgroundHoverImage { get { return _hoverImage; } set { if (_hoverImage != value) { _hoverImage = value; InvalidateIfMouseState(MouseState.HOVER); } } }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Image BackgroundClickImage { get { return _clickImage; } set { if (_clickImage != value) { _clickImage = value; InvalidateIfMouseState(MouseState.DOWN); } } }

    [Category("Appearance")]
    [DefaultValue(ImageLayout.Zoom)]
    [AmbientValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { if (base.BackgroundImageLayout != value) { base.BackgroundImageLayout = value; UpdateState(); } } }

    [Category("Behavior")]
    [DefaultValue(InterpolationMode.NearestNeighbor)]
    public InterpolationMode InterpolationMode { get; set; }
    #endregion

    #region Text Properties
    [Category("Appearance")]
    [AmbientValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Font Font { get { return base.Font ?? DefaultFont; } set { if (base.Font != value) { base.Font = value; InvalidateIfMouseState(MouseState.NONE); } } }

    [Category("Appearance")]
    [AmbientValue(null)]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Font DisabledFont { get { return _textDisabledFont; } set { if (_textDisabledFont != value) { _textDisabledFont = value; InvalidateIfDisabled(); } } }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Font HoverFont { get { return _textHoverFont; } set { if (_textHoverFont != value) { _textHoverFont = value; InvalidateIfMouseState(MouseState.HOVER); } } }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Font ClickFont { get { return _textClickFont; } set { if (_textClickFont != value) { _textClickFont = value; InvalidateIfMouseState(MouseState.DOWN); } } }

    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text { get { return base.Text; } set { if (base.Text != value) { base.Text = value; _textCache.Clear(); UpdateState(); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color TextColor { get { return _textBaseColor; } set { if (_textBaseColor != value) { _textBaseColor = value; InvalidateIfMouseState(MouseState.NONE); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color TextShadowColor { get { return _shadowColor; } set { if (_shadowColor != value) { _shadowColor = value; UpdateState(); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Point), "-1,1")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Point TextShadowOffset { get { return _shadowOffset; } set { if (_shadowOffset != value) { _shadowOffset = value; UpdateState(); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Point), "0,0")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Point TextClickOffset { get { return _clickOffset; } set { if (_clickOffset != value) { _clickOffset = value; InvalidateIfMouseState(MouseState.DOWN); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color TextDisabledColor { get { return _textDisabledColor; } set { if (_textDisabledColor != value) { _textDisabledColor = value; InvalidateIfDisabled(); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color TextHoverColor { get { return _textHoverColor; } set { if (_textHoverColor != value) { _textHoverColor = value; InvalidateIfMouseState(MouseState.HOVER); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color TextClickColor { get { return _textClickColor; } set { if (_textClickColor != value) { _textClickColor = value; InvalidateIfMouseState(MouseState.DOWN); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Padding), "0,0,0,0")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Padding TextMargin { get { return _textPadding; } set { if (_textPadding != value) { _textPadding = value; Invalidate(); } } }

    [Category("Appearance")]
    [DefaultValue(0)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public int TextPage { get { return _textPage; } set { if (_textPage != value) { _textPage = value; SetFade(PageFadeTicks); Invalidate(); } } }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TextPageCount { get; private set; }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFirstTextPage { get { return TextPage <= 0; } }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLastTextPage { get { return TextPage >= TextPageCount - 1; } }

    [Category("Appearance")]
    [DefaultValue(StringAlignment.Near)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public StringAlignment Alignment { get { return _textAlignment; } set { if (_textAlignment != value) { _textAlignment = value; Invalidate(); } } }

    [Category("Appearance")]
    [DefaultValue(StringAlignment.Near)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public StringAlignment LineAlignment { get { return _textLineAlignment; } set { if (_textLineAlignment != value) { _textLineAlignment = value; Invalidate(); } } }
    #endregion

    #region Border Properties
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color BorderColor { get { return _borderBaseColor; } set { if (_borderBaseColor != value) { _borderBaseColor = value; InvalidateIfMouseState(MouseState.NONE); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color BorderDisabledColor { get { return _borderDisabledColor; } set { if (_borderDisabledColor != value) { _borderDisabledColor = value; InvalidateIfDisabled(); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color BorderHoverColor { get { return _borderHoverColor; } set { if (_borderHoverColor != value) { _borderHoverColor = value; InvalidateIfMouseState(MouseState.HOVER); } } }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color BorderClickColor { get { return _borderClickColor; } set { if (_borderClickColor != value) { _borderClickColor = value; InvalidateIfMouseState(MouseState.DOWN); } } }

    [Category("Appearance")]
    [DefaultValue(-1f)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public float BorderThickness { get { return _borderBaseThickness; } set { if (_borderBaseThickness != value) { _borderBaseThickness = value; InvalidateIfMouseState(MouseState.NONE); } } }

    [Category("Appearance")]
    [DefaultValue(-1f)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public float BorderHoverThickness { get { return _borderHoverThickness; } set { if (_borderHoverThickness != value) { _borderHoverThickness = value; InvalidateIfMouseState(MouseState.HOVER); } } }

    [Category("Appearance")]
    [DefaultValue(-1f)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public float BorderDisabledThickness { get { return _borderDisabledThickness; } set { if (_borderDisabledThickness != value) { _borderDisabledThickness = value; InvalidateIfDisabled(); } } }

    [Category("Appearance")]
    [DefaultValue(-1f)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public float BorderClickThickness { get { return _borderClickThickness; } set { if (_borderClickThickness != value) { _borderClickThickness = value; InvalidateIfMouseState(MouseState.DOWN); } } }
    #endregion

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MouseState State { get { return _state; } set { if (_state != value) { _state = value; UpdateState(); } } }

    [Category("Appearance")]
    [DefaultValue(0)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public int PageFadeTicks { get { return _pageFadeTicks; } set { if (_pageFadeTicks != value) { _pageFadeTicks = value; } } }

    private Image _baseImage;
    private Image _disabledImage;
    private Image _hoverImage;
    private Image _clickImage;

    private Font _textDisabledFont;
    private Font _textHoverFont;
    private Font _textClickFont;

    private Padding _textPadding;
    private StringAlignment _textAlignment;
    private StringAlignment _textLineAlignment;

    private Color _textBaseColor;
    private Color _textDisabledColor;
    private Color _textHoverColor ;
    private Color _textClickColor;

    private Color _borderBaseColor;
    private Color _borderDisabledColor;
    private Color _borderHoverColor;
    private Color _borderClickColor;

    private float _borderBaseThickness;
    private float _borderDisabledThickness;
    private float _borderHoverThickness;
    private float _borderClickThickness;

    private int _pageFadeTicks;

    private readonly Registry<TextFormatInfo, Image[]> _textCache = new Registry<TextFormatInfo, Image[]>() { Default = new Image[0] };
    private Image _image;
    private Font _textFont;
    private int _textPage;
    private Color _textColor;
    private Color _shadowColor;
    private Point _shadowOffset;
    private Point _clickOffset;
    private Color _borderColor;
    private float _borderThickness;
    private MouseState _state = MouseState.NONE;
    private AnimateType _animate = AnimateType.ALWAYS;
    private int _animCyclesRemaining = -1;
    private int _animFramesRemaining = 0;
    private bool _animating = false;
    private int _fadeSteps = 5;
    private int _fadeTotalSteps = 5;
    private Image _fader;
    private Task _taskFader;

    // Hacky stuff, store the size and loocation set by the designer and use them for proportional scaling.
    // It does mean that Size change events will remove any user redefinitions of size thereafter :(
    // What you see on the Designer is what you get
    private float _aspect; // width : height ratio
    private float2 _relSize; // size dimensions relative to parent _effSize
    private float2 _relLocation; // location dimensions relative to parent _displacement
    private float2 _effSize; // effective size after adjusting for _aspect
    private float2 _displacement; // displacement after adjusting for _aspect

    public Size AspectAdjustedSize { get { return _effSize.ToSize(); } }

    private Size _orgSize;
    private float2 _scale = new float2(1, 1);
    // End hacky stuff

    public SpriteBox()
    {
      InitializeComponent();

      _textBaseColor = Color.Black;
      _textDisabledColor = Color.Empty;
      _textHoverColor = Color.Empty;
      _textClickColor = Color.Empty;

      _borderBaseColor = Color.Empty;
      _borderDisabledColor = Color.Empty;
      _borderHoverColor = Color.Empty;
      _borderClickColor = Color.Empty;

      _borderBaseThickness = -1f;
      _borderDisabledThickness = -1f;
      _borderHoverThickness = -1f;
      _borderClickThickness = -1f;

      _shadowColor = Color.Empty;
      _shadowOffset = new Point(-1, 1);
      _clickOffset = new Point(0, 0);

      TextPage = 0;
      LockWhenAnimating = false;

      UpdateState();
      InterpolationMode = InterpolationMode.NearestNeighbor;
      DoubleBuffered = true;
    }

    private void UpdateAnimCount()
    {
      switch (_animate)
      {
        case AnimateType.ALWAYS:
          _animCyclesRemaining = -1;
          break;

        case AnimateType.ONCE:
          _animCyclesRemaining = 1;
          break;

        case AnimateType.NONE:
          _animCyclesRemaining = 0;
          break;
      }
    }

    private void UpdateState()
    {
      if (IsDisposed) { return; }
      if (ClientRectangle.IsEmpty) { return; }

      Image refImage = BackgroundImage;

      if (Enabled)
      {
        switch (_state)
        {
          default:
          case MouseState.NONE:
            {
              _image = BaseImage;
              BackgroundImage = _image ?? BackgroundImage;
              _textFont = Font ?? DefaultFont;
              _textColor = TextColor;
              _borderColor = BorderColor;
              _borderThickness = BorderThickness;
              break;
            }
            
          case MouseState.HOVER:
            {
              _image = Cascade.Pick(null, BackgroundHoverImage, BaseImage);
              BackgroundImage = _image ?? BackgroundImage;
              _textFont = Cascade.Pick(null, HoverFont, Font) ?? DefaultFont;
              _textColor = Cascade.Pick(Color.Empty, TextHoverColor, TextColor);
              _borderColor = Cascade.Pick(Color.Empty, BorderHoverColor, BorderColor);
              _borderThickness = Cascade.Pick(-1, BorderHoverThickness, BorderThickness);
              break;
            }

          case MouseState.DOWN:
            {
              _image = Cascade.Pick(null, BackgroundClickImage, BackgroundHoverImage, BaseImage);
              BackgroundImage = _image ?? BackgroundImage;
              _textFont = Cascade.Pick(null, ClickFont, HoverFont, Font) ?? DefaultFont;
              _textColor = Cascade.Pick(Color.Empty, TextClickColor, TextHoverColor, TextColor);
              _borderColor = Cascade.Pick(Color.Empty, BorderClickColor, BorderHoverColor, BorderColor);
              _borderThickness = Cascade.Pick(-1, BorderClickThickness, BorderHoverThickness, BorderThickness);
              break;
            }
            
        }
      }
      else
      {
        _image = Cascade.Pick(null, BackgroundDisabledImage, BaseImage);
        BackgroundImage = _image ?? BackgroundImage;
        _textFont = Cascade.Pick(null, DisabledFont, Font) ?? DefaultFont;
        _textColor = Cascade.Pick(Color.Empty, TextDisabledColor, TextColor);
        _borderColor = Cascade.Pick(Color.Empty, BorderDisabledColor, BorderColor);
        _borderThickness = Cascade.Pick(-1, BorderDisabledThickness, BorderThickness);
      }

      if (refImage != BackgroundImage)
        UpdateAnimCount();

      // for animation
      if (_animating && refImage != null && (refImage != BackgroundImage || _animCyclesRemaining == 0))
      {
        ImageAnimator.StopAnimate(refImage, OnFrameChanged);
        UnlockInput();
        _animating = false;
      }

      refImage = BackgroundImage;

      if (!_animating && _animCyclesRemaining != 0 && refImage != null && ImageAnimator.CanAnimate(refImage))
      {
        _animating = true;
        if (LockWhenAnimating) { LockInput(); }
        _animFramesRemaining = refImage.GetFrameCount(new FrameDimension(refImage.FrameDimensionsList[0]));
        ImageAnimator.Animate(refImage, OnFrameChanged);
      }

      if (!DesignMode && Size != _orgSize)
      {
        float factor = _scale.x.Clamp(MIN_SCALE, _scale.y);
        _textFont = new Font(_textFont.FontFamily, _textFont.Size * factor, _textFont.Style);
      }

      if (!string.IsNullOrWhiteSpace(Text))
      {
        // update the cache so that the PageCount is updated as early as possible
        GetOrCreateFromTextPageCache(out _);
      }

      Invalidate();
    }

    private void OnFrameChanged(object o, EventArgs e)
    {
      if (IsDisposed) { return; }
      _animFramesRemaining--;
      if (_animFramesRemaining < 0)
      {
        if (_animate == AnimateType.ONCE) { _animCyclesRemaining--; }
        TaskHandler.StartNew(new TaskSet(() => AnimationCycleCompleted?.Invoke()));
      }
      Invalidate();
    }

    private void LockInput()
    {
      if (FindForm() is GameForm g)
      {
        g.Lock(this);
      }
    }

    private void UnlockInput()
    {
      if (FindForm() is GameForm g)
      {
        g.Unlock(this);
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      if (IsDisposed) { return; }
      if (ClientRectangle.IsEmpty) { return; }
      if (_animating && BackgroundImage != null) { ImageAnimator.UpdateFrames(BackgroundImage); }

      pe.Graphics.InterpolationMode = InterpolationMode;
      if (InterpolationMode == InterpolationMode.NearestNeighbor) { pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half; }
      base.OnPaint(pe);

      // Text
      if (!string.IsNullOrWhiteSpace(Text))
      {
        _textFont = _textFont ?? DefaultFont;
        GetOrCreateFromTextPageCache(out Image textImg);

        Point pos = new Point((int)(ClientRectangle.X + TextMargin.Left * _scale.x), (int)(ClientRectangle.Y + TextMargin.Top * _scale.y));
        if (State == MouseState.DOWN) { pos = new Point(pos.X + _clickOffset.X, pos.Y + _clickOffset.Y); }
        pe.Graphics.DrawImageUnscaled(textImg, pos);
      }

      // Border
      if (_borderThickness > 0)
        using (Pen pen = new Pen(_borderColor, _borderThickness))
          pe.Graphics.DrawRectangle(pen, ClientRectangle);

      // Fade effect
      if (_fader != null && _fadeSteps > 0 && _fadeTotalSteps > 0)
      {
        Image f = _fader;
        ColorMatrix matrix = new ColorMatrix
        {
          Matrix33 = _fadeSteps / (float)_fadeTotalSteps
        };
        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        pe.Graphics.DrawImage(f, new Rectangle(0, 0, Width, Height), 0, 0, f.Width, f.Height, GraphicsUnit.Pixel, attributes);
      }

      // dispose
      if (_fader != null && _fadeSteps <= 0)
      {
        Image f = _fader;
        _fader = null;
        f.Dispose();
      }
    }

    public void SetFade(int steps = 5)
    {
      if (IsDisposed) { return; }
      if (steps <= 0) { return; }

      Bitmap f = new Bitmap(Width, Height);
      DrawToBitmap(f, new Rectangle(0, 0, Width, Height));
      _fader = f;
      _fadeSteps = steps;
      _fadeTotalSteps = steps;
      if (LockWhenFading) { LockInput(); }
      if (_taskFader == null) { _taskFader = Task.Factory.StartNew(DoFade); }
    }

    private void DoFade()
    {
      while (!IsDisposed)
      {
        this.Invoke(new Action(Invalidate)); // force repaint
        _fadeSteps--;
        if (_fadeSteps <= 0 || _fadeTotalSteps <= 0 || _fader == null)
        {
          UnlockInput();
          break;
        }
        Thread.Sleep(66);
      }
      this.Invoke(new Action(() => FadeCycleCompleted?.Invoke()));
      _taskFader = null;
    }

    private void GetOrCreateFromTextPageCache(out Image result)
    {
      float factor = _scale.x.Clamp(MIN_SCALE, _scale.y);

      StringFormat textFormat = new StringFormat
      {
        Alignment = Alignment,
        LineAlignment = LineAlignment,
        Trimming = StringTrimming.EllipsisWord,
        FormatFlags = StringFormatFlags.LineLimit
      };

      SizeF textBounds = new SizeF
      {
        Width = ClientRectangle.Width - (TextMargin.Left - TextMargin.Right) * _scale.x,
        Height = ClientRectangle.Height - (TextMargin.Top - TextMargin.Bottom) * _scale.y
      };

      PointF scaledShadowOffset = new PointF
      {
        X = _shadowOffset.X * factor,
        Y = _shadowOffset.Y * factor
      };

      TextFormatInfo info = new TextFormatInfo(_textFont, textFormat, textBounds, _textColor, _shadowColor, scaledShadowOffset);
      if (!_textCache.Contains(info)) { _textCache.Add(info, GenerateTextImages(Text, info)); }

      result = SelectPage(_textCache[info], TextPage, out int page, out int pageCount);
      _textPage = page;
      TextPageCount = pageCount;

      TextCacheUpdated?.Invoke();
    }

    private void ClearTextPageCache()
    {
      foreach (Image[] imgs in _textCache.GetValues())
      {
        if (imgs != null)
        {
          foreach (Image img in imgs)
          {
            img.Dispose();
          }
        }
      }
      _textCache.Clear();
    }

    private static Image[] GenerateTextImages(string text, TextFormatInfo info)
    {
      List<Image> temp = new List<Image>();
      string currtext = text;
      while (currtext.Length > 0)
      {
        Bitmap b = new Bitmap((int)info.Size.Width, (int)info.Size.Height);
        b.MakeTransparent();
        Graphics g = Graphics.FromImage(b);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.MeasureString(currtext, info.Font, info.Size, info.Format, out int chars, out int _);
        if (chars == 0) { b.Dispose(); break; }
        string renderText = currtext.Substring(0, chars);

        RectangleF region = new RectangleF(0, 0, b.Width, b.Height);
        // shadow
        if (info.ShadowColor != Color.Empty && info.ShadowOffset != Point.Empty)
        {
          region.Offset(info.ShadowOffset);
          using (SolidBrush textBrush = new SolidBrush(info.ShadowColor))
            g.DrawString(renderText, info.Font, textBrush, region, info.Format);
          region.Offset(-info.ShadowOffset.X, -info.ShadowOffset.Y);
        }

        using (SolidBrush textBrush = new SolidBrush(info.TextColor))
          g.DrawString(renderText, info.Font, textBrush, region, info.Format);

        temp.Add(b);
        currtext = currtext.Substring(chars);
      }
      return temp.ToArray();
    }

    private Image SelectPage(Image[] pages, int index, out int actualIndex, out int pageCount)
    {
      if (pages == null || pages.Length == 0)
      {
        pageCount = 0;
        actualIndex = 0;
        return null;
      }

      pageCount = pages.Length;
      actualIndex = index.Clamp(0, pageCount - 1);
      return pages[actualIndex];
    }

    private void EventHandler_SetMouseHover(object sender, EventArgs e) { State = MouseState.HOVER; }

    private void EventHandler_SetMouseDown(object sender, MouseEventArgs e) { State = MouseState.DOWN; }

    private void EventHandler_SetMouseHoverIfDown(object sender, MouseEventArgs e) { if (State == MouseState.DOWN) { State = MouseState.HOVER; } }

    private void EventHandler_SetMouseDefault(object sender, EventArgs e) { State = MouseState.NONE; }

    private void EventHandler_UpdateState(object sender, EventArgs e) { UpdateState(); }

    private void SpriteBox_SizeChanged(object sender, EventArgs e)
    {
      if (IsDisposed) { return; }
      this.SuspendDrawing();
      if (_orgSize == Size.Empty) { SaveLocatorInformation(); }

      if (_orgSize != Size.Empty)
      {
        float2 size = new float2(Size.Width.Max(1), Size.Height.Max(1));
        float2 orgSize = new float2(_orgSize.Width.Max(1), _orgSize.Height.Max(1));
        _scale = size / orgSize;
        float currAspect = size.x / size.y;
        _effSize = (_aspect < currAspect)
                    ? new float2(size.y * _aspect, size.y)
                    : new float2(size.x, size.x / _aspect);
        _displacement = (size - _effSize) / 2;

        if (Parent is SpriteBox sp)
        {
          float2 pSize = sp._effSize;
          _relSize = Size.ToFloat2() / pSize;
        }
      }

      Rescale();
      ClearTextPageCache();
      UpdateState();
      this.ResumeDrawing();
    }

    private void SpriteBox_LocationChanged(object sender, EventArgs e)
    {
      if (IsDisposed) { return; }
      this.SuspendDrawing();
      if (_orgSize != Size.Empty)
      {
        if (Parent is SpriteBox sp)
        {
          float2 pSize = sp._effSize;
          float2 pDisp = sp._displacement;

          _relLocation = (Location.ToFloat2() - pDisp) / pSize;
        }
      }
      this.ResumeDrawing();
    }

    internal void Rescale()
    {
      if (IsDisposed) { return; }
      if (DesignMode) { return; }
      if (_orgSize == Size.Empty) { return; }

      foreach (Control c in Controls)
      {
        if (c is SpriteBox sp)
        {
          float2 sploc = sp.Size.ToFloat2();
          float2 spsz = sp.Size.ToFloat2();

          switch (BackgroundImageLayout)
          {
            case ImageLayout.Zoom:
              {
                sploc = _displacement + sp._relLocation * _effSize;
                spsz = sp._relSize * _effSize;
                break;
              }

            case ImageLayout.Stretch:
              {
                sploc = sp._relLocation * Size.ToFloat2();
                spsz = sp._relSize * Size.ToFloat2();
                break;
              }

            case ImageLayout.Center:
              {
                sploc = sp._relLocation * Size.ToFloat2();
                spsz = sp._relSize * Size.ToFloat2();

                // convert negative displacement to 0 as ImageLayout.Center keeps the top left corner anchored
                Image bgImg = BackgroundImage;
                if (bgImg != null)
                {
                  float2 spdisp = (Size.ToFloat2() - bgImg.Size.ToFloat2()) / 2;
                  spdisp.x = spdisp.x.Max(0);
                  spdisp.y = spdisp.y.Max(0);

                  sploc += spdisp;
                }
                break;
              }

            // ImageLayout.Tile and ImageLayout.None keep elements aligned to top left corner
            default:
              break;

          }

          float2 preserveLoc = sp._relLocation;
          float2 preserveSz = sp._relSize;

          sp.Location = sploc.ToPoint();
          sp.Size = spsz.ToSize();

          // write back the old values to prevent accumulation of rounding errors
          if (preserveLoc != float2.Empty) { sp._relLocation = preserveLoc; }
          if (preserveSz != float2.Empty) { sp._relSize = preserveSz; }
        }
      }
    }

    private void InvalidateIfDisabled() { if (!Enabled) { UpdateState(); } }

    private void InvalidateIfMouseState(MouseState state) { if (_state == state) { UpdateState(); } }

    private void SaveLocatorInformation()
    {
      if (IsDisposed) { return; }
      _orgSize = Size;
      _aspect = Size.Width / (float)Size.Height.Max(1);

      if (Parent is SpriteBox sp)
      {
        float2 pSize = sp._effSize;
        float2 pDisp = sp._displacement;

        _relSize = Size.ToFloat2() / pSize;
        _relLocation = (Location.ToFloat2() - pDisp) / pSize;
      }
      else
        _relSize = new float2(1, 1);
    }


    public void DoClick()
    {
      OnClick(null);
    }

    private void DisposeInner()
    {
      /*
      if (DesignMode) { return; }

      // do not dispose images, these are possibly shared resources
      _baseImage?.Dispose();
      _clickImage?.Dispose();
      _disabledImage?.Dispose();
      _hoverImage?.Dispose();
      _image?.Dispose();
      */

      _textFont?.Dispose();
      _fader?.Dispose();

      TextCacheUpdated = null;
      AnimationCycleCompleted = null;
    }
  }
}

