using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.Extensions.FileFormats.Bin;
using Dune2000.Extensions.Structs.Bin;
using Dune2000.FileFormats.Mis;
using Dune2000.FileFormats.R16;
using Dune2000.FileFormats.Uib;
using Dune2000.Structs.Pal;
using Dune2000.Structs.Uib;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;

namespace Dune2000.Editor.UI.UserControls
{
  public partial class ucResourceEditor : EditorControl
  {
    public ucResourceEditor()
    {
      InitializeComponent();
      foreach (object o in Enum.GetValues(typeof(House)))
        cbHouse.Items.Add(o);

      panel1.Enabled = false;

      pbPreview.Zoom = (float)nudZoom.Value;
      pbPreview.DrawBoundingBox = cbFrame.Checked;
      pbPreview.FitToScreen = cbFitToScreen.Checked;
    }

    private ResourceFile _resource;
    private PaletteFile _palette;
    private HousePaletteFile _housePalette;

    public override string OpenFileFilter { get { return "Dune 2000 resource files|*.r8;*.r16|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 resource files|*.r8;*.r16|All files|*.*"; } }

    public override void Unload()
    {
      BlankEntry();
      lboxItems.Items.Clear();
      _dirty = false;
      panel1.Enabled = false;
    }

    private void ReloadEntry()
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { BlankEntry(); return; }

      RedrawImage();
      tbAlignment.Text = _resource.Resources[index].Alignment.ToString();
      tbBitsPerPixel.Text = _resource.Resources[index].BitsPerPixel.ToString();
      tbImageSize.Text = "{0} x {1}".F(_resource.Resources[index].ImageWidth, _resource.Resources[index].ImageHeight);
      tbImageOffset.Text = "{0}, {1}".F(_resource.Resources[index].ImageOffsetX, _resource.Resources[index].ImageOffsetY);
      tbFrameSize.Text = "{0} x {1}".F(_resource.Resources[index].FrameWidth, _resource.Resources[index].FrameHeight);
      tbImageHandle.Text = _resource.Resources[index].ImageHandle.ToString();
      tbPalHandle.Text = _resource.Resources[index].PaletteHandle.ToString();
      tbType.Text = _resource.Resources[index].PaletteType.ToString();
    }

    private void RedrawImage()
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { BlankEntry(); return; }

      pbPreview.Preview?.Dispose();
      IPalette pal = _palette.Palette;

      pbPreview.BoundingBox = new Rectangle(_resource.Resources[index].ImageOffset.ToPoint(), _resource.Resources[index].ImageSize.ToSize());
      pbPreview.Offset = _resource.Resources[index].ImageOffset;
      pbPreview.Preview = _resource.Resources[index].GetBitmap(ref pal, ref _housePalette, true, cbTransparency.Checked, cboxHousePal.Checked ? cbHouse.SelectedIndex : -1);
    }

    private void BlankEntry()
    {
      pbPreview.Preview?.Dispose();
      pbPreview.Preview = null;

      tbAlignment.Text = "";
      tbBitsPerPixel.Text = "";
      tbImageSize.Text = "";
      tbImageOffset.Text = "";
      tbFrameSize.Text = "";
      tbImageHandle.Text = "";
      tbType.Text = "";
    }

    public override void Reload()
    {
      if (_resource == null) { return; }

      lboxItems.Items.Clear();
      for (int i = 0; i < _resource.Resources.Count; i++)
      {
        lboxItems.Items.Add(string.Format("{0}\t{1}x{2}", i, _resource.Resources[i].ImageWidth, _resource.Resources[i].ImageHeight));
      }
      _dirty = false;
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        ResourceFile resource = new ResourceFile();
        resource.ReadFromFile(path);
        _resource = resource;
        _dirty = false;
        return true;
      }
      catch 
      {
        MessageBox.Show("The file is not a valid resource file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      _resource.WriteToFile(path);
      _dirty = false;
      return true;
    }

    private void lboxItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      ReloadEntry();
    }

    public bool LoadPaletteFile(string path)
    {
      try
      {
        PaletteFile pal = new PaletteFile();
        pal.ReadFromFile(path);
        _palette = pal;
        return true;
      }
      catch
      {
        MessageBox.Show("The file is not a valid palette file.");
        return false;
      }
    }

    public bool LoadHousePaletteFile(string path)
    {
      try
      {
        HousePaletteFile pal = new HousePaletteFile();
        pal.ReadFromFile(path);
        _housePalette = pal;
        return true;
      }
      catch
      {
        MessageBox.Show("The file is not a valid palette file.");
        return false;
      }
    }

    private void bLinkPalette_Click(object sender, EventArgs e)
    {
      if (ofdPalette.ShowDialog() == DialogResult.OK && LoadPaletteFile(ofdPalette.FileName))
      {
        lblPalette.Text = ofdPalette.FileName;
        ReloadEntry();
      }
    }

    private void bLinkHouseColor_Click(object sender, EventArgs e)
    {
      if (ofdHousePalette.ShowDialog() == DialogResult.OK && LoadHousePaletteFile(ofdHousePalette.FileName))
      {
        lblHouseColor.Text = ofdHousePalette.FileName;
        ReloadEntry();
      }
    }

    private void cboxHousePal_CheckedChanged(object sender, EventArgs e)
    {
      cbHouse.Enabled = cboxHousePal.Checked;
      RedrawImage();
    }

    private void cbHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
      RedrawImage();
    }

    private void cbFitToScreen_CheckedChanged(object sender, EventArgs e)
    {
      pbPreview.FitToScreen = cbFitToScreen.Checked;
    }

    private void nudZoom_ValueChanged(object sender, EventArgs e)
    {
      pbPreview.Zoom = (float)nudZoom.Value;
    }

    private void cbFrame_CheckedChanged(object sender, EventArgs e)
    {
      pbPreview.DrawBoundingBox = cbFrame.Checked;
    }

    private void cbTransparency_CheckedChanged(object sender, EventArgs e)
    {
      RedrawImage();
    }
  }
}
