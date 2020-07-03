using Dune2000.Launcher.UI.Forms;
using System;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class MainMenuScreen : PreviewKeyUserControl, ILinkedControl
  {
    public MainMenuScreen()
    {
      InitializeComponent();
      Dock = DockStyle.Fill;

      _eyeTimerEnable = new Action(() => EyeTimer(true));
      _eyeTimerDisable = new Action(() => EyeTimer(false));

      spLEye.AnimationCycleCompleted += SpLEye_AnimComplete;

      EyeTimer(true);
      SetKeyAction(Keys.D1, () => { if (spStart.Enabled) { SpStart_Click(null, null); } }, spStart.Text);
      SetKeyAction(Keys.D2, () => { if (spLoad.Enabled) { SpLoad_Click(null, null); } }, spLoad.Text);
      SetKeyAction(Keys.D3, () => { if (spLaunch.Enabled) { SpLaunch_Click(null, null); } }, spLaunch.Text);
      SetKeyAction(Keys.D4, () => { if (spSetting.Enabled) { SpSetting_Click(null, null); } }, spSetting.Text);
      SetKeyAction(Keys.Escape, () => { if (spQuit.Enabled) { SpQuit_Click(null, null); } }, spQuit.Text);
    }

    private void SpStart_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_NewCampaign?.Invoke(); }
    private void SpLoad_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_LoadCampaign?.Invoke(); }
    private void SpLaunch_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_LaunchGame?.Invoke(); }
    private void SpSetting_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Config?.Invoke(); }
    private void SpQuit_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Quit?.Invoke(); }
    private void SpKeyHelp_Click(object sender, EventArgs e) { Clicked_KeyHelp?.Invoke(); }

    public UpdateDelegate Clicked_NewCampaign;
    public UpdateDelegate Clicked_LoadCampaign;
    public UpdateDelegate Clicked_LaunchGame;
    public UpdateDelegate Clicked_Config;
    public UpdateDelegate Clicked_Quit;

    private readonly Action _eyeTimerEnable;
    private readonly Action _eyeTimerDisable;

    public override void Link(GameForm f)
    {
      base.Link(f);
      Clicked_NewCampaign = () => f.Push(new CampaignSelectionScreen2(), TransitionStyle.FADE_BLACK);
      Clicked_LaunchGame = () => { f.Engine.LaunchGame(); f.Push(new GameRunningScreen(), TransitionStyle.FADE_TWEEN); };
      Clicked_Config = () => f.Push(new ConfigurationScreen(), TransitionStyle.FADE_BLACK);
      Clicked_Quit = () => { f.ShowConfirmClose = false; f.Close(); };
    }

    public override void Activate(Engine e, Control prevControl)
    {
      if (prevControl == null || prevControl is ConfigurationScreen)
      {
        // mount
        bool mountSuccess = e.LoadMount();
        spStart.Enabled = mountSuccess && Clicked_NewCampaign?.GetInvocationList().Length > 0;
        spLoad.Enabled = mountSuccess && Clicked_LoadCampaign?.GetInvocationList().Length > 0;
        spLaunch.Enabled = mountSuccess && Clicked_LaunchGame?.GetInvocationList().Length > 0;

        AudioEngine.PlayMusic(AudioGlobals.Music_MainMenu);
      }
    }

    public override void Deactivate(Engine e)
    {
      AudioEngine.StopMusic();
    }

    private void TmEyeTrig_Tick(object sender, EventArgs e)
    {
      spLEye.Animate = AnimateType.ONCE;
      spREye.Animate = AnimateType.ONCE;
      Invoke(_eyeTimerDisable);
    }

    private void SpLEye_AnimComplete()
    {
      spLEye.Animate = AnimateType.NONE;
      spREye.Animate = AnimateType.NONE;
      Invoke(_eyeTimerEnable);
    }

    private void EyeTimer(bool enable)
    {
      if (enable)
      {
        tmEyeTrig.Interval = new Random().Next(60000, 120000);
        tmEyeTrig.Enabled = true;
      }
      else
      {
        tmEyeTrig.Enabled = false;
      }
    }

  }
}
