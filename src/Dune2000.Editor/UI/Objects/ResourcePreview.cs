using Dune2000.Editor.Util;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Objects
{
  public class ResourcePreview : PictureBox
	{
		public ResourcePreview()
		{
			InitializeComponent();
		}

		private Image _preview;
		private bool _fitToScreen;
		private bool _drawBoundingBox;
		private float _zoom;
		private Rectangle _boundingBox;
		private int2 _offset;

		public Image Preview { get { return _preview; } set { if (_preview != value) { _preview = value; Invalidate(); } } }
		public bool FitToScreen { get { return _fitToScreen; } set { if (_fitToScreen != value) { _fitToScreen = value; Invalidate(); } } }
		public bool DrawBoundingBox { get { return _drawBoundingBox; } set { if (_drawBoundingBox != value) { _drawBoundingBox = value; Invalidate(); } } }
		public float Zoom { get { return _zoom; } set { if (_zoom != value) { _zoom = value; Invalidate(); } } }
		public Rectangle BoundingBox { get { return _boundingBox; } set { if (_boundingBox != value) { _boundingBox = value; Invalidate(); } } }
		public int2 Offset { get { return _offset; } set { if (_offset != value) { _offset = value; Invalidate(); } } }

		public UpdateDelegate<int2> PixelClicked;

		protected override void OnPaint(PaintEventArgs pe)
		{
			pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			Image image = Preview;
			float zoom = _zoom;
			if (image != null || zoom < 0)
			{
				float w = image.Width * zoom;
				float h = image.Height * zoom;
				if (FitToScreen) // full zoom
				{
					float scaleX = Width / image.Width;
					float scaleY = Height / image.Height;
					float scale = scaleX.Min(scaleY);

					w = image.Width * scale;
					h = image.Height * scale;
					zoom = scale;
				}

				int imgwidth = (int)w;
				int imgheight = (int)h;
				int offsetX = (Width - imgwidth - (int)(_offset.x * zoom)) / 2;
				int offsetY = (Height - imgheight - (int)(_offset.y * zoom)) / 2;

				Image tile = Properties.Resources.Tile;
				for (int x = -5; x < 5; x++)
				{
					for (int y = -5; y < 5; y++)
					{
						pe.Graphics.DrawImage(tile, new RectangleF(Width / 2 + x * tile.Width * zoom, Height / 2 + y * tile.Height * zoom, tile.Width * zoom, tile.Height * zoom));
					}
				}

				Rectangle frame = new Rectangle(offsetX, offsetY, imgwidth, imgheight);
				pe.Graphics.DrawImage(image, frame, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

				if (DrawBoundingBox && !BoundingBox.IsEmpty)
				{
					pe.Graphics.DrawRectangle(Pens.Magenta, frame);
				}
			}
			else if (image == null)
      {
				// don't flash when scrolling past empty entries
				Image tile = Properties.Resources.Tile;
				for (int x = -5; x < 5; x++)
				{
					for (int y = -5; y < 5; y++)
					{
						pe.Graphics.DrawImage(tile, new RectangleF(Width / 2 + x * tile.Width * zoom, Height / 2 + y * tile.Height * zoom, tile.Width * zoom, tile.Height * zoom));
					}
				}
			}
		}

		private void InitializeComponent()
		{
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // ResourcePreview
      // 
      this.Click += new System.EventHandler(this.ResourcePreview_Click);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

		}

		private void ResourcePreview_Click(object sender, System.EventArgs e)
		{
			Image image = Preview;
			float zoom = _zoom;
			if (image != null || zoom < 0)
			{
				float w = image.Width * zoom;
				float h = image.Height * zoom;
				if (FitToScreen) // full zoom
				{
					float scaleX = Width / image.Width;
					float scaleY = Height / image.Height;
					float scale = scaleX.Min(scaleY);

					w = image.Width * scale;
					h = image.Height * scale;
					zoom = scale;
				}

				int imgwidth = (int)w;
				int imgheight = (int)h;
				int offsetX = (Width - imgwidth - (int)(_offset.x * zoom)) / 2;
				int offsetY = (Height - imgheight - (int)(_offset.y * zoom)) / 2;

				float2 mloc = (PointToClient(Cursor.Position).ToFloat2() - new float2(offsetX, offsetY)) / zoom;
				int2 imloc = new int2((int)mloc.x, (int)mloc.y);

				if (imloc.x == imloc.x.Clamp(0, image.Width) && imloc.y == imloc.y.Clamp(0, image.Height))
				{
					PixelClicked?.Invoke(imloc);
				}
				else
        {
					PixelClicked?.Invoke(new int2(-1, -1));

				}
			}
		}
  }
}
