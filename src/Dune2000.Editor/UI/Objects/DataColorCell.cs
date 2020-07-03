using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Objects
{
  public class DataColorCell : DataGridViewButtonCell
	{
		private float _borderWidth = 2;
		private Color _border = SystemColors.ControlDark;
		private Color _value;

		public Color Color
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				Value = value;
			}
		}

		public DataColorCell()
		{
		}

		public DataColorCell(Color value)
		{
			Value = value;
		}

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			using (Pen pen = new Pen(_border, _borderWidth))
			{
				Rectangle rect = cellBounds;
				Color color = (value as Color?) ?? Color.Black;
				graphics.FillRectangle(new SolidBrush(color), rect);
				graphics.DrawRectangle(pen, rect);
			}
		}
	}
}
