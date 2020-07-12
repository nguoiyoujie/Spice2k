using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Pal;
using Dune2000.Structs.R16;
using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Resources
{
  public partial class ImportResourceForm : Form
  {
    public ImportResourceForm()
    {
      InitializeComponent();
      foreach (object o in Enum.GetValues(typeof(House)))
        cbHouse.Items.Add(o);

      pbPreview.Zoom = 1;
      pbPreview.DrawBoundingBox = false;
      pbPreview.FitToScreen = true;
    }

    //public Bitmap Bitmap { get { return _resource; } set { if (_resource != value) { _resource = value; } } }
    public ResourceElement ResourceElement { get; private set; } = new ResourceElement();

    public IPalette UserPalette { get; set; }
    public IPalette BasePalette { get { return _basePalette; } set { _basePalette = value; } }
    public IPalette PrevPalette { get; set; }
    public HousePaletteFile HousePalette { get { return _housePalette; } set { _housePalette = value; } }

    private Bitmap _bitmap;
    private IPalette _basePalette;
    private HousePaletteFile _housePalette;
    private PaletteChoice _choice;

    protected enum PaletteChoice { USER, BASE, EXISTING }

    private void RedrawImage()
    {
      if (_bitmap == null) { return; }

      pbPreview.Preview?.Dispose();
      IPalette bpalClone = _basePalette;

      pbPreview.BoundingBox = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
      pbPreview.Offset = new Primrose.Primitives.ValueTypes.int2();
      pbPreview.Preview = ResourceElement.GetBitmap(ref bpalClone, ref _housePalette, false, cbTransparency.Checked, cboxHousePal.Checked ? cbHouse.SelectedIndex : -1);

      if (cb8Bit.Checked)
      {
        switch (_choice)
        {
          case PaletteChoice.BASE:
            pbPalette.Palette = _basePalette;
            break;

          case PaletteChoice.USER:
            pbPalette.Palette = UserPalette;
            break;

          case PaletteChoice.EXISTING:
            pbPalette.Palette = PrevPalette;
            break;
        }
      }
      else
      {
        pbPalette.Palette = default;
      }
    }

    private void bOK_Click(object sender, System.EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bClose_Click(object sender, System.EventArgs e)
    {
      Close();
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

    private void ImportImageData()
    {
      if (cb8Bit.Checked)
      {
        switch (_choice)
        {
          case PaletteChoice.BASE:
            ResourceElement.ImportImageDataAs8Bit(_bitmap, _basePalette, true, out _);
            break;

          case PaletteChoice.USER:
            ResourceElement.ImportImageDataAs8Bit(_bitmap, UserPalette, false, out _);
            break;

          case PaletteChoice.EXISTING:
            ResourceElement.ImportImageDataAs8Bit(_bitmap, PrevPalette, false, out _);
            break;
        }
      }
      else
      {
        ResourceElement.ImportImageDataAs15Bit(_bitmap);
      }
      RedrawImage();
    }

    public void Reset()
    {
      _bitmap = null;
      ResourceElement = new ResourceElement();
      pbPreview.Preview = null;
      pbPalette.Palette = default;
      cb8Bit.Checked = false;
      _choice = PaletteChoice.EXISTING;
    }

    private void bOpenImage_Click(object sender, EventArgs e)
    {
      if (ofdImage.ShowDialog() == DialogResult.OK)
      {
        try
        {
          Bitmap bmap = new Bitmap(ofdImage.FileName);
          if (bmap.Width > byte.MaxValue || bmap.Height > byte.MaxValue)
          {
            MessageBox.Show("Image dimensions ({0}x{1}) exceed limit of 255x255 pixels!".F(bmap.Width, bmap.Height));
            return;
          }
          _bitmap = bmap;
          ImportImageData();
        }
        catch
        {
          MessageBox.Show("Unable to open image");
        }
      }
    }

    private void bBasePalette_Click(object sender, EventArgs e)
    {
      if (_choice != PaletteChoice.BASE)
      {
        _choice = PaletteChoice.BASE;
        ImportImageData();
      }
    }

    private void bResetPalette_Click(object sender, EventArgs e)
    {
      if (_choice != PaletteChoice.EXISTING)
      {
        _choice = PaletteChoice.EXISTING;
        ImportImageData();
      }
    }

    private void bImportPalette_Click(object sender, EventArgs e)
    {
      if (ofdImportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          PaletteFile paletteFile = new PaletteFile();
          paletteFile.ReadFromFile(ofdImportPalette.FileName);
          UserPalette = paletteFile.Palette;
        }
        catch
        {
          MessageBox.Show("Unable to load new palette.");
        }

        _choice = PaletteChoice.USER;
        ImportImageData();
      }
    }

    private void cb8Bit_CheckedChanged(object sender, EventArgs e)
    {
      pbPalette.Visible = cb8Bit.Checked;
      bBasePalette.Visible = cb8Bit.Checked;
      bImportPalette.Visible = cb8Bit.Checked;
      bResetPalette.Visible = cb8Bit.Checked;
      ImportImageData();
    }
  }
}
