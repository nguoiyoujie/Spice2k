using Dune2000.Editor.UI.Structs;
using Dune2000.Editor.Util;
using Dune2000.Structs.Pal;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Objects
{
  public class PaletteView : PictureBox
	{
		public PaletteView()
		{
			InitializeComponent();
		}

		public int2 Dimensions { get { return new int2(16, 16); } }

		public IPalette Palette { get { return _palette; } set { _palette = value; Invalidate(); } }
		public int[] SelectedIndices { get { return _selectedIndices?.Clone() as int[]; } set { _selectedIndices = value?.Clone() as int[]; Invalidate(); } }
		public Color SelectColor = Color.Gold;
		public float SelectThickness = 3;

		private IPalette _palette;
		private int[] _selectedIndices = new int[0];

		public UpdateDelegate<PixelInfo<Color>> CellClicked;

		public Color Get(int2 cell)
    {
			int index = cell.x + cell.y * Dimensions.x;
			return Palette.Get(index);
		}

		public void Set(int2 cell, Color color)
		{
			int index = cell.x + cell.y * Dimensions.x;
			Palette.Set(index, color);
		}

		protected override void OnPaint(PaintEventArgs pe)
    {
			if (Palette == null) { base.OnPaint(pe); return; }

			pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;



			for (int y = 0; y < Dimensions.y; y++)
				for (int x = 0; x < Dimensions.x; x++)
				{
					int index = x + y * Dimensions.x;
					using (Brush b = new SolidBrush(Palette.Get(index)))
					{
						Rectangle r = new Rectangle(x * Width / Dimensions.x, y * Width / Dimensions.y, Width / Dimensions.x, Width / Dimensions.y);
						pe.Graphics.FillRectangle(b, r);
					  pe.Graphics.DrawRectangle(Pens.Black, r);
					}
				}

			// draw selected last
			if (_selectedIndices != null)
			{
				foreach (int sindex in _selectedIndices)
				{
					int sx = sindex % Dimensions.x;
					int sy = sindex / Dimensions.x;

					if (sx == sx.Clamp(0, Dimensions.x) && sy == sy.Clamp(0, Dimensions.y))
					{
						Rectangle r = new Rectangle(sx * Width / Dimensions.x, sy * Width / Dimensions.y, Width / Dimensions.x, Width / Dimensions.y);
						using (Brush b = new SolidBrush(SelectColor))
						{
							using (Pen p = new Pen(b, SelectThickness))
							{
								pe.Graphics.DrawRectangle(p, r);
							}
						}
					}
				}
			}
		}

    private void InitializeComponent()
    {
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // PaletteView
      // 
      this.Click += new System.EventHandler(this.PaletteView_Click);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
    }

    private void PaletteView_Click(object sender, System.EventArgs e)
    {
			if (Palette == null) { return; }

			int2 cell = PointToClient(Cursor.Position).ToInt2() * Dimensions / Size.ToInt2();
			int index = cell.x + cell.y * Dimensions.x;

			CellClicked?.Invoke(new PixelInfo<Color>(cell, Palette.Get(index)));
		}
  }
}
