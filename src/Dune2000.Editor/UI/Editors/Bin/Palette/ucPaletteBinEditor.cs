using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Dune2000.Editor.UI.Structs;
using Dune2000.FileFormats.Mis;
using Dune2000.Structs.Pal;
using Primrose.Primitives.Extensions;

namespace Dune2000.Editor.UI.Editors.Bin.Palette
{
  public partial class ucPaletteBinEditor : EditorControl
  {
    public ucPaletteBinEditor()
    {
      InitializeComponent();
      panel1.Enabled = false;

      pbPalette.CellClicked += CellSelected;
      pbPalette.SelectColor = Color.LawnGreen;
      pbPalette.SelectThickness = 5;
    }

    public override string OpenFileFilter { get { return "Dune 2000 palette file|palette.bin|Dune 2000 bin file|*.bin|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 bin file|*.bin|All files|*.*"; } }
    private PaletteFile _pal;

    public override void Unload()
    {
      pbPalette.Palette = new Palette_24Bit_64();
      tbText.Text = "";
      _dirty = false;
      _path = null;
      panel1.Enabled = false;
    }

    public override void Reload()
    {
      pbPalette.Palette = _pal.Palette;
      _dirty = false;
      panel1.Enabled = true;
    }

    public override void Refresh()
    {
      pbPalette.Invalidate();
    }

    public override bool LoadFile(string path)
    {
      try
      {
        PaletteFile pal = new PaletteFile();
        pal.ReadFromFile(path);
        _pal = pal;
        _dirty = false;
        _path = path;
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
      _pal.Palette = (Palette_24Bit_64)(pbPalette.Palette);
      _pal.WriteToFile(path);
      _dirty = false;
      _path = path;
      return true;
    }

    private void CellSelected(PixelInfo<Color> pixel)
    {
      Color c = pixel.ColorInfo;
      using (ColorDialog cdiag = new ColorDialog())
      {
        cdiag.Color = c;
        cdiag.AnyColor = true;
        cdiag.FullOpen = true;
        if (cdiag.ShowDialog() == DialogResult.OK)
        {
          pbPalette.Set(pixel.Position, cdiag.Color);
          _dirty = true;
          Refresh();
        }
      }
    }

    private void bExport_Click(object sender, EventArgs e)
    {
      if (pbPalette.Palette == null) { return; }
      if (sfdExportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          Bitmap bitmap = pbPalette.Palette.ToBitmap();
          bitmap.Save(sfdExportPalette.FileName);
          MessageBox.Show("Palette extracted successfully.");
        }
        catch 
        {
          MessageBox.Show("Unable to write to file.");
        }
      }
    }

    private void bImport_Click(object sender, EventArgs e)
    {
      if (pbPalette.Palette == null) { return; }
      if (ofdImportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          Bitmap bitmap = new Bitmap(ofdImportPalette.FileName);
          pbPalette.Palette.FromBitmap(bitmap);
          MessageBox.Show("Palette imported successfully.");
        }
        catch
        {
          MessageBox.Show("Unable to load new palette.");
        }
        _dirty = true;
        Refresh();
      }
    }

    private void bToText_Click(object sender, EventArgs e)
    {
      if (pbPalette.Palette == null) { return; }
      StringBuilder sb = new StringBuilder();
      //int size = pbPalette.Dimensions.x * pbPalette.Dimensions.y;
      //for (int i = 0; i < size; i++)
      foreach (int i in GetSelectedIndices())
      {
        Color c = pbPalette.Palette.Get(i);
        sb.AppendLine("{0:X2} {1:X2} {2:X2} ".F(c.R, c.G, c.B));
      }

      tbText.Text = sb.ToString(); 
    }

    private void bFromText_Click(object sender, EventArgs e)
    {
      if (pbPalette.Palette == null) { return; }
      try
      {
        string[] slist = tbText.Text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] indices = GetSelectedIndices();
        if (indices.Length * 3 != slist.Length)
        {
          MessageBox.Show("Expected {0} byte codes for {1} indices, found {2} instead.".F(indices.Length * 3, indices.Length, slist.Length));
          return;
        }

        int curr = 0;
        foreach (int i in indices)
        {
          if (!byte.TryParse(slist[curr++], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out byte r))
          {
            MessageBox.Show("Invalid byte code '{0}' found at entry {1}".F(slist[i], i));
            return;
          }

          if (!byte.TryParse(slist[curr++], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out byte g))
          {
            MessageBox.Show("Invalid byte code '{0}' found at entry {1}".F(slist[i + 1], i + 1));
            return;
          }

          if (!byte.TryParse(slist[curr++], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out byte b))
          {
            MessageBox.Show("Invalid byte code '{0}' found at entry {1}".F(slist[i + 2], i + 2));
            return;
          }
          Color c = Color.FromArgb(r, g, b);
          pbPalette.Palette.Set(i, c);
          _dirty = true;
        }
        Refresh();
      }
      catch
      {
        MessageBox.Show("Unable to load palette from text.");
      }
    }

    private int[] GetSelectedIndices()
    {
      List<int> list = new List<int>();
      for (int i = (int)nudStart.Value; i <= nudEnd.Value; i++)
      {
        list.Add(i);
      }
      return list.ToArray();
    }

    private void nudStart_ValueChanged(object sender, EventArgs e)
    {
      if (nudEnd.Value < nudStart.Value)
      {
        nudEnd.Value = nudStart.Value;
      }
      else
      {
        pbPalette.SelectedIndices = GetSelectedIndices();
      }
    }

    private void nudEnd_ValueChanged(object sender, EventArgs e)
    {
      if (nudEnd.Value < nudStart.Value)
      {
        nudStart.Value = nudEnd.Value;
      }
      else
      {
        pbPalette.SelectedIndices = GetSelectedIndices();
      }
    }
  }
}
