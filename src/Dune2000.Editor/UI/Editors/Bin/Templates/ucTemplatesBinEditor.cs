using System;
using System.Windows.Forms;
using Dune2000.FileFormats.Bin;
using Dune2000.FileFormats.R16;
using Dune2000.FileFormats.Uib;

namespace Dune2000.Editor.UI.Editors.Bin.Templates
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

      _path = null;
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
        _path = path;
        return true;
      }
      catch 
      {
        MessageBox.Show("The file is not a valid template binary file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      _templates.WriteToFile(path);
      _dirty = false;
      _path = path;
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
