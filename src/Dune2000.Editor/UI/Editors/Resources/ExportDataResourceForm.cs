using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.Extensions.FileFormats.INI;
using Dune2000.FileFormats.Mis;
using Dune2000.FileFormats.R16;
using Dune2000.Structs.Pal;
using Primrose.Primitives.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Resources
{
  public partial class ExportDataResourceForm : Form
  {
    public ExportDataResourceForm()
    {
      InitializeComponent();
      foreach (object o in Enum.GetValues(typeof(House)))
        cbHouse.Items.Add(o);

      pbPreview.Zoom = 1;
      pbPreview.DrawBoundingBox = false;
      pbPreview.FitToScreen = true;

      UpdateItems();
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

    private async void bOK_Click(object sender, System.EventArgs e)
    {
      Enabled = false;
      bool exportAll = cbSelectAll.Checked;

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
        string rpath = tbFilepath.Text;
        string rootDir = Path.GetDirectoryName(rpath);
        string relImagePathFmt = @"images\img_{0:0000}.png";
        string relPalettePathFmt = @"palettes\pal_{0:0000}.bin";
        IPalette pal = _palette.Palette;
        Directory.CreateDirectory(rootDir);
        Directory.CreateDirectory(Path.Combine(rootDir, "images"));
        Directory.CreateDirectory(Path.Combine(rootDir, "palettes"));

        ResourceExportINIFile rfile = new ResourceExportINIFile();
        rfile.EntryCount = _resource.Resources.Count;

        Progress<int> p = new Progress<int>();
        pbarProgress.Maximum = rfile.EntryCount;
        pbarProgress.Value = 0;
        lblProgress.Text = "Setting up...";
        p.ProgressChanged += (s, id) =>
        {
          pbarProgress.Value = id;
          lblProgress.Text = "{0} / {1}".F(id, rfile.EntryCount);
        };

        await Task.Factory.StartNew(() =>
        {
          if (exportAll)
          {
            rfile.Export(ref pal, _resource.Resources, rootDir, relImagePathFmt, relPalettePathFmt, p);
          }
          else
          {
            foreach (int index in selected.ToArray())
            {
              rfile.Export(ref pal, index, _resource.Resources[index], rootDir, relImagePathFmt.F(index), relPalettePathFmt.F(index), p);
            }
          }
          rfile.WriteToFile(rpath);
        });

        pbarProgress.Value = pbarProgress.Maximum;
        lblProgress.Text = "Finished!";
        MessageBox.Show("Export completed!");
      }
      catch (AggregateException ex)
      {
        MessageBox.Show("Export failed.\n\nReason: {0}".F(ex.InnerException?.Message ?? ex.Message));
      }
      finally
      {
        pbarProgress.Value = 0;
        lblProgress.Text = "";
        Enabled = true;
      }
    }

    private void bClose_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    private void lboxItems_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      cbSelectAll.Checked = false;
      RedrawImage();
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

    private void cbSelectAll_CheckedChanged(object sender, System.EventArgs e)
    {
      lboxItems.Enabled = !cbSelectAll.Checked;
    }

    private void bFilepath_Click(object sender, EventArgs e)
    {
      if (sfdExport.ShowDialog() == DialogResult.OK)
      {
        tbFilepath.Text = sfdExport.FileName;
      }
    }
  }
}
