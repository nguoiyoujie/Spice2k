using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.Extensions.FileFormats.Bin;
using Dune2000.Extensions.Structs.Bin;
using Dune2000.FileFormats.Bin;
using Dune2000.FileFormats.R16;
using Dune2000.FileFormats.Uib;
using Dune2000.Structs.Uib;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;

namespace Dune2000.Editor.UI.UserControls
{
  public partial class ucTemplatesBinEditor : EditorControl
  {
    public ucTemplatesBinEditor()
    {
      InitializeComponent();
      panel1.Enabled = false;
    }

    private TemplatesFile _templates;
    private ResourceFile _resource;
    private TextUibFile _samples;

    public override void Unload()
    {
 
    }

    private void ReloadPage()
    {

      _dirty = false;
    }

    public override void Reload()
    {
      ReloadPage();
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        TemplatesFile templates = new TemplatesFile(); // seperate copy so incase of read error, _uib is not overwritten
        templates.ReadFromFile(path);
        _templates = templates;
        _dirty = false;
        return true;
      }
      catch 
      {
        MessageBox.Show("The file is not a valid templates binary file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      _templates.WriteToFile(path);
      _dirty = false;
      return true;
    }

    private void cbHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
      ReloadPage();
    }

    private void cbScenario_SelectedIndexChanged(object sender, EventArgs e)
    {
      ReloadPage();
    }


  }
}
