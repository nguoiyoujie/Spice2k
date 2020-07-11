using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Dune2000.FileFormats.R16;
using Dune2000.Structs.Pal;
using Dune2000.Structs.R16;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;

namespace Dune2000.Editor.UI.Editors.Resources
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

      pbPreview.PixelClicked += PixelSelected;
    }

    private ResourceFile _resource;
    private PaletteFile _palette;
    private HousePaletteFile _housePalette;

    private ExportResourceForm _exportForm = new ExportResourceForm();
    private ImportResourceForm _importForm = new ImportResourceForm();
    public override string OpenFileFilter { get { return "Dune 2000 resource files|*.r8;*.r16|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 resource files|*.r8;*.r16|All files|*.*"; } }
    private bool _cpuEdit = false;

    private string GetPaletteTypeName(PaletteType type)
    {
      switch (type)
      {
        case PaletteType.EMPTY_ENTRY:
          return "Empty entry";

        case PaletteType.HIGH_COLOR:
          return "15-bit HighColor";

        case PaletteType.BASE_PALETTE:
          return "8-bit using game palette";

        case PaletteType.EMBEDDED_PALETTE:
        case PaletteType.REFERENCED_PALETTE:
          return "8-bit using stored palette";

        default:
          return "unknown or invalid format";
      }
    }

    public override void Unload()
    {
      BlankEntry();
      lboxItems.Items.Clear();
      _dirty = false;
      _path = null;
      panel1.Enabled = false;
    }

    private void ReloadEntry()
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { BlankEntry(); return; }

      _cpuEdit = true;
      RedrawImage();

      if (_resource.Resources[index].BitsPerPixel != 8)
      {
        pbPalette.Palette = null;
      }
      if (_resource.Resources[index].PaletteHandle == 0)
      {
        pbPalette.Palette = _palette.Palette;
      }
      else
      {
        pbPalette.Palette = _resource.Resources[index].Palette;
      }

      tbType.Text = GetPaletteTypeName(_resource.Resources[index].PaletteType);

      if (_resource.Resources[index].PaletteType == PaletteType.EMPTY_ENTRY)
      {
        pbPreview.Preview?.Dispose();
        pbPreview.Preview = null;

        tbAlignment.Text = "";
        tbBitsPerPixel.Text = "";
        tbImageX.Text = "";
        tbImageY.Text = "";
        nudImageOffsetX.Value = 0;
        nudImageOffsetY.Value = 0;
        nudFrameX.Value = nudFrameX.Minimum;
        nudFrameY.Value = nudFrameY.Minimum;
        tbImageHandle.Text = "";
        _cpuEdit = false; 
        return;
      }


      tbAlignment.Text = _resource.Resources[index].Alignment.ToString();
      tbBitsPerPixel.Text = _resource.Resources[index].BitsPerPixel.ToString();
      tbImageX.Text = _resource.Resources[index].ImageWidth.ToString();
      tbImageY.Text = _resource.Resources[index].ImageHeight.ToString();
      tbImageHandle.Text = _resource.Resources[index].ImageHandle.ToString();
      tbPalHandle.Text = _resource.Resources[index].PaletteHandle.ToString();
      pbPalette.SelectedIndices = null;

      // numerical up/down has restrictions.
      int fwidth = _resource.Resources[index].FrameWidth;
      if (fwidth != fwidth.Clamp((int)(nudFrameX.Minimum), (int)(nudFrameX.Maximum)))
      {
        MessageBox.Show("This resource entry has an invalid frame width. Expected: {0} - {1}. Received: {2}.".F(nudFrameX.Minimum, nudFrameX.Maximum, fwidth));
      }
      else
      { 
        nudFrameX.Value = fwidth;
      }

      int fheight = _resource.Resources[index].FrameHeight;
      if (fheight != fheight.Clamp((int)(nudFrameY.Minimum), (int)(nudFrameY.Maximum)))
      {
        MessageBox.Show("This resource entry has an invalid frame height. Expected: {0} - {1}. Received: {2}.".F(nudFrameY.Minimum, nudFrameY.Maximum, fheight));
      }
      else
      {
        nudFrameY.Value = fheight;
      }

      int imgoffx = _resource.Resources[index].ImageOffsetX;
      if (imgoffx != imgoffx.Clamp((int)(nudImageOffsetX.Minimum), (int)(nudImageOffsetX.Maximum)))
      {
        MessageBox.Show("This resource entry has an invalid image X offset. Expected: {0} - {1}. Received: {2}.".F(nudImageOffsetX.Minimum, nudImageOffsetX.Maximum, imgoffx));
      }
      else
      {
        nudImageOffsetX.Value = imgoffx;
      }

      int imgoffy = _resource.Resources[index].ImageOffsetY;
      if (imgoffy != imgoffy.Clamp((int)(nudImageOffsetY.Minimum), (int)(nudImageOffsetY.Maximum)))
      {
        MessageBox.Show("This resource entry has an invalid image Y offset. Expected: {0} - {1}. Received: {2}.".F(nudImageOffsetY.Minimum, nudImageOffsetY.Maximum, imgoffy));
      }
      else
      {
        nudImageOffsetY.Value = imgoffy;
      }

      gInfo.Enabled = true;
      _cpuEdit = false;
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
      tbImageX.Text = "";
      tbImageY.Text = "";
      nudImageOffsetX.Value = 0;
      nudImageOffsetY.Value = 0;
      nudFrameX.Value = nudFrameX.Minimum;
      nudFrameY.Value = nudFrameY.Minimum;
      tbImageHandle.Text = "";
      tbType.Text = "";

      gInfo.Enabled = false;
    }

    private string GetListboxEntryText(int index) { return "{0}\t{1}x{2}".F(index, _resource.Resources[index].ImageWidth, _resource.Resources[index].ImageHeight); }

    public override void Reload()
    {
      if (_resource == null) { return; }

      // reload the whole file, since no clone exists on memory
      LoadFile(_path);

      lboxItems.Items.Clear();
      List<string> list = new List<string>();
      for (int i = 0; i < _resource.Resources.Count; i++)
      {
        list.Add(GetListboxEntryText(i));
      }
      lboxItems.Items.AddRange(list.ToArray());
      lboxItems.SelectedIndex = 0;
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
      _resource.WriteToFile(path);
      _dirty = false;
      _path = path;
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
      nudZoom.Enabled = !cbFitToScreen.Checked;
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

    private void bMoveDown_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      // if invalid index, do nothing
      if (index < 0 || index >= lboxItems.Items.Count - 1 || _resource == null) { return; }

      _dirty = true;
      ResourceElement element = _resource.Resources[index];
      _resource.Resources.RemoveAt(index);

      _resource.Resources.Insert(index + 1, element);

      // rename the list box elements
      lboxItems.Items[index] = GetListboxEntryText(index);
      lboxItems.Items[index + 1] = GetListboxEntryText(index + 1);
      lboxItems.SelectedIndex++;
    }

    private void bMoveUp_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      // if invalid index, do nothing
      if (index < 1 || index >= lboxItems.Items.Count || _resource == null) { return; }

      _dirty = true;
      ResourceElement element = _resource.Resources[index];
      _resource.Resources.RemoveAt(index);

      _resource.Resources.Insert(index - 1, element);

      // rename the list box elements
      lboxItems.Items[index] = GetListboxEntryText(index);
      lboxItems.Items[index - 1] = GetListboxEntryText(index - 1);
      lboxItems.SelectedIndex--;
    }

    private void bExport_Click(object sender, EventArgs e)
    {
      _exportForm.Resource = _resource;
      _exportForm.Palette = _palette;
      _exportForm.HousePalette = _housePalette;
      _exportForm.ShowDialog();
    }

    private void EntryDetailsChanged(object sender, EventArgs e)
    {
      if (_cpuEdit) { return; }
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { BlankEntry(); return; }

      _resource.Resources[index].FrameWidth = (byte)(nudFrameX.Value);
      _resource.Resources[index].FrameHeight = (byte)(nudFrameY.Value);
      _resource.Resources[index].ImageOffsetX = (int)(nudImageOffsetX.Value);
      _resource.Resources[index].ImageOffsetY = (int)(nudImageOffsetY.Value);

      _dirty = true;
      RedrawImage();
    }

    private void PixelSelected(int2 pixel)
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { BlankEntry(); return; }

      if (_resource.Resources[index].BitsPerPixel == 8)
      {
        // convert frame dimensions to image dimensions
        pixel -= (_resource.Resources[index].FrameSize - _resource.Resources[index].ImageSize) / 2;

        int i = pixel.x + pixel.y * _resource.Resources[index].ImageWidth;
        if (i >= 0 && i < _resource.Resources[index].ImageData.Length)
        {
          int colorindex = _resource.Resources[index].ImageData[i];
          pbPalette.SelectedIndices = new int[] { colorindex };
        }
        else
        {
          pbPalette.SelectedIndices = null;
        }
      }
    }

    private void bExportPalette_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { return; }

      if (_resource.Resources[index].PaletteType == PaletteType.EMPTY_ENTRY || _resource.Resources[index].PaletteType == PaletteType.INVALID)
      {
        MessageBox.Show("The resource entry does not contain a palette.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.HIGH_COLOR)
      {
        MessageBox.Show("The resource entry is in 15-bit HighColor mode and does not contain a palette.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.BASE_PALETTE)
      {
        MessageBox.Show("The resource entry uses the game's base palette and does not itself contain a palette.");
        return;
      }

      if (sfdExportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          PaletteFile paletteFile = new PaletteFile();
          for (int i = 0; i < 256; i++)
          {
            paletteFile.Palette.Set(i, pbPalette.Palette.Get(i));
          }
          paletteFile.WriteToFile(sfdExportPalette.FileName);
          MessageBox.Show("Palette extracted successfully.");
        }
        catch 
        {
          MessageBox.Show("Unable to write to file.");
        }
      }
    }

    private void bImportPalette_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { return; }

      if (_resource.Resources[index].PaletteType == PaletteType.EMPTY_ENTRY || _resource.Resources[index].PaletteType == PaletteType.INVALID)
      {
        MessageBox.Show("The resource entry is empty and cannot be assigned a palette.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.HIGH_COLOR)
      {
        MessageBox.Show("The resource entry is in 15-bit HighColor mode and cannot be assigned a palette.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.BASE_PALETTE)
      {
        if (MessageBox.Show("The resource entry currently uses the game's base palette. Replace with an embedded palette?", "Confirm Import Palette", MessageBoxButtons.YesNo) != DialogResult.Yes)
        {
          return;
        }
      }

      if (ofdImportPalette.ShowDialog() == DialogResult.OK)
      {
        try
        {
          PaletteFile paletteFile = new PaletteFile();
          paletteFile.ReadFromFile(ofdImportPalette.FileName);

          for (int i = 0; i < 256; i++)
          {
            _resource.Resources[index].Palette.Set(i, paletteFile.Palette.Get(i));
          }

          if (_resource.Resources[index].PaletteType == PaletteType.BASE_PALETTE)
          {
            _resource.Resources[index].PaletteHandle = 1; // any non-zero number
          }

          _resource.Resources[index].FirstByte = 1; // embedded
          MessageBox.Show("Palette imported successfully.");
        }
        catch
        {
          MessageBox.Show("Unable to load new palette.");
        }
        _dirty = true;
        ReloadEntry();
      }
    }

    private void bRevertPalette_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      if (_resource == null) { return; }
      if (index < 0 || index >= _resource.Resources.Count) { return; }

      if (_resource.Resources[index].PaletteType == PaletteType.EMPTY_ENTRY || _resource.Resources[index].PaletteType == PaletteType.INVALID)
      {
        MessageBox.Show("The resource entry does not contain a palette to revert.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.HIGH_COLOR)
      {
        MessageBox.Show("The resource entry is in 15-bit HighColor mode and does not contain a palette to revert.");
        return;
      }
      else if (_resource.Resources[index].PaletteType == PaletteType.BASE_PALETTE)
      {
        MessageBox.Show("The resource entry is already using the base palette.");
        return;
      }

      if (MessageBox.Show("Are you sure you want to revert the palette to the game's base palette?", "Confirm Revert Palette", MessageBoxButtons.YesNo) != DialogResult.Yes)
      {
        return;
      }

      try
      {
        // set to 0.
        _resource.Resources[index].PaletteHandle = 0;

        MessageBox.Show("Palette reverted successfully.");
      }
      catch
      {
        MessageBox.Show("Unable to clear palette information.");
      }
      _dirty = true;
      ReloadEntry();
    }

    private void Group_Resized(object sender, EventArgs e)
    {
      panel10.Dock = DockStyle.Fill;
      int h = panel10.Height;
      panel10.Dock = DockStyle.Top;
      panel10.Size = new Size(panel1.Width, h);
    }

    private void bRemove_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      // if invalid index, do nothing
      if (index < 0 || index >= lboxItems.Items.Count || _resource == null) { return; }

      _dirty = true;
      _resource.Resources.RemoveAt(index);

      // recreate index
      List<string> list = new List<string>();
      lboxItems.Items.Clear();
      for (int i = 0; i < _resource.Resources.Count; i++)
      {
        list.Add(GetListboxEntryText(i));
      }
      lboxItems.Items.AddRange(list.ToArray());
      lboxItems.SelectedIndex = index;
    }

    private void bAdd_Click(object sender, EventArgs e)
    {
      int index = lboxItems.SelectedIndex;
      if (index < 0) { index = 0; }
      if (index >= lboxItems.Items.Count) { index = lboxItems.Items.Count - 1; }

      // if invalid index, do nothing
      if (index < 1 || index >= lboxItems.Items.Count || _resource == null) { return; }

      _importForm.Reset();
      _importForm.BasePalette = _palette.Palette;
      _importForm.PrevPalette = pbPalette.Palette;
      _importForm.HousePalette = _housePalette;
      if (_importForm.ShowDialog() == DialogResult.OK)
      {
        _dirty = true;
        _resource.Resources.Insert(index, _importForm.ResourceElement);

        // recreate index
        lboxItems.Items.Clear();
        lboxItems.Items.Clear();
        List<string> list = new List<string>();
        for (int i = 0; i < _resource.Resources.Count; i++)
        {
          list.Add(GetListboxEntryText(i));
        }
        lboxItems.Items.AddRange(list.ToArray());
        lboxItems.SelectedIndex = index;
      }
    }
  }
}
