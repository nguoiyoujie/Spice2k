using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Objects
{
  public class ResourcePreview : PictureBox
	{
		public ResourcePreview() { }

		private Image _preview;
		private bool _fitToScreen;
		private bool _drawBoundingBox;
		private float _zoom;
		private Rectangle _boundingBox;
		private int2 _offset;

		public Image Preview { get { return _preview; }set { if (_preview != value) { _preview = value; Invalidate(); } } }
		public bool FitToScreen { get { return _fitToScreen; } set { if (_fitToScreen != value) { _fitToScreen = value; Invalidate(); } } }
		public bool DrawBoundingBox { get { return _drawBoundingBox; } set { if (_drawBoundingBox != value) { _drawBoundingBox = value; Invalidate(); } } }
		public float Zoom { get { return _zoom; } set { if (_zoom != value) { _zoom = value; Invalidate(); } } }
		public Rectangle BoundingBox { get { return _boundingBox; } set { if (_boundingBox != value) { _boundingBox = value; Invalidate(); } } }
		public int2 Offset { get { return _offset; } set { if (_offset != value) { _offset = value; Invalidate(); } } }

		protected override void OnPaint(PaintEventArgs pe)
    {
			pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			Image image = Preview;
			if (image != null || _zoom < 0)
			{
				float w = image.Width * _zoom;
				float h = image.Height * _zoom;
				if (FitToScreen) // full zoom
				{
					float scaleX = Width / w;
					float scaleY = Height / h;
					float scale = scaleX.Min(scaleY);

					w *= scale;
					h *= scale;
					_zoom = scale;
				}

				int imgwidth = (int)w;
				int imgheight = (int)h;
				int offsetX = (Width - imgwidth - (int)(_offset.x * _zoom)) / 2 ;
				int offsetY = (Height - imgheight - (int)(_offset.y * _zoom)) / 2 ;
				int endX = offsetX + imgwidth;
				int endY = offsetY + imgheight;

				Image tile = Properties.Resources.Tile;
				for (int x = -4; x < 5; x++)
				{
					for (int y = -4; y < 5; y++)
					{
						pe.Graphics.DrawImage(tile, new RectangleF(Width / 2 + x * tile.Width * _zoom, Height / 2 + y * tile.Height * _zoom, tile.Width * _zoom, tile.Height * _zoom));
					}
				}

				Rectangle frame = new Rectangle(offsetX, offsetY, imgwidth, imgheight);
				pe.Graphics.DrawImage(image, frame, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

				if (DrawBoundingBox && !BoundingBox.IsEmpty)
				{
					pe.Graphics.DrawRectangle(Pens.Magenta, frame);
				}
			}
    }
	}
}
