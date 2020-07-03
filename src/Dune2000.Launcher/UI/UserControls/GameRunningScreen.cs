using Dune2000.Launcher.UI.Forms;
using System;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class GameRunningScreen : PreviewKeyUserControl, ILinkedControl
  {
    public UpdateDelegate Released;

    public GameRunningScreen()
    {
      InitializeComponent();
      Dock = DockStyle.Fill;
      //_process = process;
      //_process.Exited += (o, e) => Release();
    }

    Engine _engine;
    //Process _process;

    public void Release()
    {
      Released?.Invoke();
    }

    public override void Link(Engine e)
    {
      _engine = e;
    }

    public override void Link(GameForm f)
    {
      base.Link(f);
      f.WindowState = FormWindowState.Minimized;
      Released += () =>
      {
        f.Remove(this);
        if (f.Current is MissionBriefingScreen)
          f.Pop();

        f.WindowState = FormWindowState.Normal;
        Released = null;
      };
    }

    private void tmProcess_Tick(object sender, EventArgs e)
    {
      if (!_engine.IsGameInProcess)
      {
        Release();
      }
    }
  }
}
