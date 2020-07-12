using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Dune2000.FileFormats.R16;
using Dune2000.Structs.Pal;
using Dune2000.Util.Palette;
using Primrose.Primitives.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Resources
{
  public partial class ExportResourceForm : Form
  {
    public ExportResourceForm()
    {
      InitializeComponent();
      foreach (object o in Enum.GetValues(typeof(House)))
        cbHouse.Items.Add(o);

      pbPreview.Zoom = 1;
      pbPreview.DrawBoundingBox = false;
      pbPreview.FitToScreen = true;

      UpdateItems();
      UpdatePreviewFileName();
    }

    public ResourceFile Resource { get { return _resource; } set { if (_resource != value) { _resource = value; UpdateItems(); } } }
    public PaletteFile Palette { get { return _palette; } set { _palette = value; } }
    public HousePaletteFile HousePalette { get { return _housePalette; } set { _housePalette = value; } }

    private ResourceFile _resource;
    private PaletteFile _palette;
    private HousePaletteFile _housePalette;

    private void UpdateItems()
    {
      if (_resource == null) { return; }

      lboxItems.Items.Clear();
      List<string> list = new List<string>();
      for (int i = 0; i < _resource.Resources.Count; i++)
      {
        list.Add(GetListboxEntryText(i));
      }
      lboxItems.Items.AddRange(list.ToArray());
    }

    private string GetListboxEntryText(int index) { return "{0}\t{1}x{2}".F(index, _resource.Resources[index].ImageWidth, _resource.Resources[index].ImageHeight); }

    private void RedrawImage()
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { return; }

      pbPreview.Preview?.Dispose();
      IPalette pal = _palette.Palette;

      pbPreview.BoundingBox = new Rectangle(_resource.Resources[index].ImageOffset.ToPoint(), _resource.Resources[index].ImageSize.ToSize());
      pbPreview.Offset = new Primrose.Primitives.ValueTypes.int2(); // _resource.Resources[index].ImageOffset;
      pbPreview.Preview = _resource.Resources[index].GetBitmap(ref pal, ref _housePalette, false, cbTransparency.Checked, cboxHousePal.Checked ? cbHouse.SelectedIndex : -1);
    }

    private void Save(ref IPalette palette, int index, string format, bool transparency, int houseIndex)
    {
      Image img = _resource.Resources[index].GetBitmap(ref palette, ref _housePalette, false, transparency, houseIndex);
      img.Save(format.F(index));
    }

    private void bOK_Click(object sender, System.EventArgs e)
    {
      bool exportAll = cbSelectAll.CheckState == CheckState.Checked;
      List<int> selected = new List<int>(lboxItems.SelectedIndices.Count);
      if (!exportAll)
      {
        foreach (int s in lboxItems.SelectedIndices)
        {
          selected.Add(s);
        }
      }

      try
      {
        bool transparency = cbTransparency.Checked;
        int houseIndex = cboxHousePal.Checked ? cbHouse.SelectedIndex : -1;
        Directory.CreateDirectory(tbDirectory.Text);
        IPalette pal = _palette.Palette;

        if (PaletteUtil.HasNonUniqueSpecialIndices(ref pal, out byte[] affected))
        {
          MessageBox.Show("The palette has some special indices that are mapped to the same colors as other indices. This may give incorrect results when re-importing.\n\n" +
                          "Affected indices: {0}".F(string.Join(",", affected)));
        }

        Task t = Task.Factory.StartNew(() =>
        {
          string format = Path.Combine(tbDirectory.Text, tbFormat.Text);
          if (exportAll)
          {
            for (int i = 0; i < _resource.Resources.Count; i++)
            {
              Save(ref pal, i, format, transparency, houseIndex);
            }
          }
          else
          {
            foreach (int index in selected.ToArray())
            {
              Save(ref pal, index, format, transparency, houseIndex);
            }
          }
        });
        t.Wait();

        MessageBox.Show("Export completed!");
      }
      catch (AggregateException ex)
      {
        MessageBox.Show("Export failed.\n\nReason: {0}".F(ex.InnerException?.Message ?? ex.Message));
      }
    }

    private void bClose_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    private void lboxItems_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      cbSelectAll.CheckState = lboxItems.SelectedIndex == -1 ? CheckState.Unchecked : CheckState.Indeterminate;
      RedrawImage();
      UpdatePreviewFileName();
    }

    private void cboxHousePal_CheckedChanged(object sender, System.EventArgs e)
    {
      cbHouse.Enabled = cboxHousePal.Checked;
      RedrawImage();
    }

    private void cbHouse_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      RedrawImage();
    }

    private void cbTransparency_CheckedChanged(object sender, System.EventArgs e)
    {
      RedrawImage();
    }

    private void tbFormat_TextChanged(object sender, System.EventArgs e)
    {
      UpdatePreviewFileName();
    }

    private void UpdatePreviewFileName()
    { 
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { return; }

      try
      {
        string text = tbFormat.Text.F(index);
        if (text.Length == 0)
        {
          lblFormat.Text = "<no file name specified!>";
          lblFormat.ForeColor = Color.Red;
          return;
        }

        foreach (char c in Path.GetInvalidFileNameChars())
        {
          if (text.Contains(c.ToString()))
          {
            lblFormat.Text = "<Invalid character in file name!";
            lblFormat.ForeColor = Color.Red;
            return;
          }
        }

        if (!Path.HasExtension(text))
        {
          text += ".png";
        }

        lblFormat.Text = text;
        lblFormat.ForeColor = Color.Black;
      }
      catch
      {
        lblFormat.Text = "<Error applying format string as file name!";
        lblFormat.ForeColor = Color.Red;
      }
    }

    private void cbSelectAll_CheckedChanged(object sender, System.EventArgs e)
    {
      lboxItems.Enabled = cbSelectAll.CheckState != CheckState.Checked;
    }

    private void bDirectory_Click(object sender, EventArgs e)
    {
      if (fbdExport.ShowDialog() == DialogResult.OK)
      {
        tbDirectory.Text = fbdExport.SelectedPath;
      }
    }
  }
}
