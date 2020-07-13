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

namespace Dune2000.Editor.UI.Editors.Bin.Colours
{
  public partial class ucColoursBinEditor : EditorControl
  {
    public ucColoursBinEditor()
    {
      InitializeComponent();
      panel1.Enabled = false;

      pbPalette.CellClicked += CellSelected;
      pbPalette.SelectColor = Color.LawnGreen;
      pbPalette.SelectThickness = 5;

      _indexLabels = new Label[] { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16 };
      _indexButtons = new List<Button>(){ bH1, bH2, bH3, bH4, bH5, bH6, bH7, bH8, bH9, bH10, bH11, bH12, bH13, bH14, bH15, bH16 };
    }

    public override string OpenFileFilter { get { return "Dune 2000 colours file|colours.bin|Dune 2000 bin file|*.bin|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 bin file|*.bin|All files|*.*"; } }
    private Palette_15Bit[] _pals;
    private Label[] _indexLabels;
    private List<Button> _indexButtons;

    private int _currPalette;
    float[] _aDark = new float[]
    {
            0.4f,
            0.2f,
            0.1f,
            0f,
            -0.2f,
            -0.3f,
            -0.4f
};
    float[] _aLight = new float[]
    {
            0.1f,
            0.2f,
            0.3f,
            0.4f,
            0.5f,
            0.6f,
            0.7f
    };

    public override void Unload()
    {
      tbText.Text = "";
      _currPalette = 0;
      _pals = new Palette_15Bit[0];
      RedrawPalette();

      _dirty = false;
      _path = null;
      panel1.Enabled = false;
    }

    private void RedrawPalette()
    {
      if (_pals == null || _pals.Length == 0)
      {
        pbPalette.Palette = new Palette_15Bit();
        _currPalette = 0;
      }
      else
      {
        _currPalette = _currPalette.Clamp(0, _pals.Length);
        pbPalette.Palette = _pals[_currPalette];
      }

      for (int i = 0; i < _indexLabels.Length; i++)
      {
        _indexLabels[i].Text = (i + _currPalette * 16).ToString();
      }

      UpdatePalNavigation();
      pbPalette.Invalidate();
    }

    public override void Reload()
    {
      LoadFile(_path);
      _currPalette = 0;
      RedrawPalette();
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
        HousePaletteFile hpal = new HousePaletteFile();
        hpal.ReadFromFile(path);
        _pals = hpal.GetPalettes();
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
      HousePaletteFile hpal = new HousePaletteFile();
      hpal.SetPalettes(_pals);
      hpal.WriteToFile(path);
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
          _pals[_currPalette].Set(pixel.Position.x + pixel.Position.y * 16, cdiag.Color);
          _dirty = true;
          RedrawPalette();
        }
      }
    }

    private void bExport_Click(object sender, EventArgs e)
    {
      if (_pals == null || _pals.Length == 0) { return; }
      if (sfdExportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          Bitmap bitmap = _pals[_currPalette].ToBitmap();
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
      if (_pals == null || _pals.Length == 0) { return; }
      if (ofdImportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          Bitmap bitmap = new Bitmap(ofdImportPalette.FileName);
          _pals[_currPalette].FromBitmap(bitmap);
          MessageBox.Show("Palette imported successfully.");
        }
        catch
        {
          MessageBox.Show("Unable to load new palette.");
        }
        _dirty = true;
        RedrawPalette();
      }
    }

    private void bToText_Click(object sender, EventArgs e)
    {
      if (_pals == null || _pals.Length == 0) { return; }
      StringBuilder sb = new StringBuilder();
      //int size = pbPalette.Dimensions.x * pbPalette.Dimensions.y;
      //for (int i = 0; i < size; i++)
      foreach (int i in GetSelectedIndices())
      {
        Color c = _pals[_currPalette].Get(i);
        sb.AppendLine("{0:X2} {1:X2} {2:X2} ".F(c.R, c.G, c.B));
      }

      tbText.Text = sb.ToString(); 
    }

    private void bFromText_Click(object sender, EventArgs e)
    {
      if (_pals == null || _pals.Length == 0) { return; }
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
          _pals[_currPalette].Set(i, c);
          _dirty = true;
        }
        RedrawPalette();
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

    private void bSetColor_Click(object sender, EventArgs e)
    {
      if (_pals == null || _pals.Length == 0) { return; }
      int hindex = _indexButtons.IndexOf(sender as Button);
      if (hindex <= -1) { return; }

      _currPalette = _currPalette.Clamp(0, _pals.Length);
      int refindex = hindex * 16;

      Color c = _pals[_currPalette].Get(refindex);
      using (ColorDialog cdiag = new ColorDialog())
      {
        cdiag.Color = c;
        cdiag.AnyColor = true;
        cdiag.FullOpen = true;
        if (cdiag.ShowDialog() == DialogResult.OK)
        {
          // Set 16 colours relative to the central color
          _pals[_currPalette].Set(refindex + 7, cdiag.Color);
          _pals[_currPalette].Set(refindex + 8, cdiag.Color);

          for (int i = 0; i < 7; i++)
          {
            _pals[_currPalette].Set(refindex + i, ControlPaint.Dark(cdiag.Color, _aDark[i]));
          }
          for (int j = 0; j < 7; j++)
          {
            _pals[_currPalette].Set(refindex + j + 9, ControlPaint.Light(cdiag.Color, _aLight[j]));
          }

          _dirty = true;
          RedrawPalette();
        }
      }
    }

    private void UpdatePalNavigation()
    {
      bPrevPal.Enabled = _currPalette > 0;
      lblPal.Text = "Colours for House indices {0} - {1}".F(_currPalette * 16, _currPalette * 16 + 15);
    }

    private void bPrevPal_Click(object sender, EventArgs e)
    {
      _currPalette--;
      RedrawPalette();
    }

    private void bPrevNext_Click(object sender, EventArgs e)
    {
      if (_currPalette + 1 >= _pals.Length)
      {
        if (MessageBox.Show("A new palette page will be created to support houses above this index. This will increase the size of the file. Proceed?", "Dune 2000 Editor", MessageBoxButtons.OKCancel) == DialogResult.OK)
        {
          Palette_15Bit[] palnew = new Palette_15Bit[_pals.Length + 1];
          _pals.CopyTo(palnew, 0);
          palnew[_pals.Length] = new Palette_15Bit();
          _pals = palnew;
        }
        else
        {
          return;
        }
      }

      _currPalette++;
      RedrawPalette();
    }
  }
}
