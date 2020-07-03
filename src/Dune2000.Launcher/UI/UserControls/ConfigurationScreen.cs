using Dune2000.Extensions.FileFormats.INI;
using Dune2000.Launcher.UI.Forms;
using Primrose.Primitives.Extensions;
using System;
using System.IO;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class ConfigurationScreen : PreviewKeyUserControl, ILinkedControl
  {
    public UpdateDelegate Clicked_Apply;
    public UpdateDelegate Clicked_Back;
    public ErrorDelegate SaveError;

    public ConfigurationScreen()
    {
      InitializeComponent();
      Dock = DockStyle.Fill;

      SetKeyAction(Keys.Escape, () => { if (spBack.Enabled) { SpBack_Click(null, null); } }, "Return without saving");
      SetKeyAction(Keys.F, () => { if (spFind.Enabled) { SpFind_Click(null, null); } }, "Set the game executable path");
      SetKeyAction(Keys.Enter, () => { if (spSave.Enabled) { SpSave_Click(null, null); } }, "Save changes and return");
    }

    public void LoadConfig()
    {
      LauncherSettingsFile sfile = new LauncherSettingsFile();
      try
      {
        sfile.ReadFromFile(Engine.SETTINGS_PATH);
        spGamePath.Text = sfile.ExecutablePath ?? Resource.Strings.EmptyPath;
        ofdGamePath.InitialDirectory = Path.GetDirectoryName(sfile.ExecutablePath);
      }
      catch
      {
        spGamePath.Text = Resource.Strings.EmptyPath;
      }
    }

    public bool WriteConfig()
    {
      LauncherSettingsFile sfile = new LauncherSettingsFile();

      // We read the existing file, if any. This allows settings beyond the scope of this screen to be saved
      try { sfile.ReadFromFile(Engine.SETTINGS_PATH); }
      catch { }

      if (spGamePath.Text != Resource.Strings.EmptyPath)
        sfile.ExecutablePath = spGamePath.Text;

      // Save
      try { sfile.WriteToFile(Engine.SETTINGS_PATH); }
      catch (Exception ex)
      { 
        SaveError?.Invoke(Resource.Strings.Error_WriteConfig.F(ex.Message), ex);
        return false;
      }
      return true;
    }

    private void SpSave_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Apply?.Invoke(); }
    private void SpBack_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Back?.Invoke(); }
    private void SpKeyHelp_Click(object sender, EventArgs e) { Clicked_KeyHelp?.Invoke(); }

    private void SpFind_Click(object sender, EventArgs e)
    {
      AudioEngine.Click();
      if (ofdGamePath.ShowDialog() == DialogResult.OK) { spGamePath.Text = ofdGamePath.FileName; }
    }

    public override void Link(Engine e)
    {
      SaveError = e.HandleError;
    }

    public override void Link(GameForm f)
    {
      base.Link(f);
      Clicked_Apply = () => { if (WriteConfig()) { f.Remove(this, TransitionStyle.FADE_BLACK); } };
      Clicked_Back = () => f.Remove(this, TransitionStyle.FADE_BLACK);
    }

    public override void Activate(Engine e, Control prevControl)
    {
      if (prevControl is ErrorScreen || prevControl is KeyNavigationHelpScreen ) { return; }

      LoadConfig();
    }
  }
}
