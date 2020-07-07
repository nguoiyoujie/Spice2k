using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Objects
{
	public class ExtendedDataGridView : DataGridView
	{
		// based on MVI's original editor, shows the row number on the header row 
		protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
		{
			string text = e.RowIndex.ToString();
			while (text.Length < RowCount.ToString().Length)
			{
				text = "0" + text;
			}
			SizeF sizeF = e.Graphics.MeasureString(text, this.Font);
			if (RowHeadersWidth < (int)(sizeF.Width + 20f))
			{
				RowHeadersWidth = (int)(sizeF.Width + 20f);
			}
			Brush controlText = SystemBrushes.ControlText;
			e.Graphics.DrawString(text, this.Font, controlText, (float)(e.RowBounds.Location.X + 15), (float)e.RowBounds.Location.Y + ((float)e.RowBounds.Height - sizeF.Height) / 2f);
			base.OnRowPostPaint(e);
		}
	}
}
