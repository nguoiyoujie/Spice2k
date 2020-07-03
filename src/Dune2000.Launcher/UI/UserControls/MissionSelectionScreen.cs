using Dune2000.Extensions.Missions;
using Dune2000.FileFormats.INI;
using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.UI.Objects;
using Dune2000.Launcher.Util;
using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class MissionSelectionScreen : PreviewKeyUserControl, ILinkedControl
  {
    public const int TIMEOUT_MS_LOADINGSCREEN = 1500;
    public const int TIMEOUT_MS_ERROR = 60000;

    public const string MESSAGE_LOADINGSCREEN = "Updating mission list...";
    public const string MESSAGE_LOADTIMEOUT = "Too long to load missions!";

    public UpdateDelegate Clicked_Start;
    public UpdateDelegate Clicked_Back;

    private MissionSet[] _missions;
    private int _selectedMissionIndex = -1;
    private int _page;

    private readonly Predicate<MissionSet> _missionFilter;
    private readonly SpriteBox[] MissionBoxes;

    public MissionSelectionScreen(Predicate<MissionSet> missionFilter)
    {
      InitializeComponent();
      Dock = DockStyle.Fill;

      _missionFilter = missionFilter;
      MissionBoxes = new SpriteBox[]
      {
        spMission1,
        spMission2,
        spMission3,
        spMission4,
        spMission5,
        spMission6,
        spMission7,
        spMission8,
        spMission9,
        spMission10,
      };

      SetKeyAction(Keys.Escape, () => { if (spBack.Enabled) { SpBack_Click(null, null); } }, "Return to previous menu");
      SetKeyAction(Keys.Enter, () => { if (spStart.Enabled) { SpStart_Click(null, null); } }, "Open selected mission");
      SetKeyAction(Keys.Left, () => { if (spPrevPage.Enabled) { SpPrevPage_Click(null, null); } }, "Previous page");
      SetKeyAction(Keys.Right, () => { if (spNextPage.Enabled) { SpNextPage_Click(null, null); } }, "Next page");
      SetKeyAction(Keys.D1, () => { if (spMission1.Enabled) { MissionClick(spMission1, null); } }, "Select 1st mission");
      SetKeyAction(Keys.D2, () => { if (spMission2.Enabled) { MissionClick(spMission2, null); } }, "Select 2nd mission");
      SetKeyAction(Keys.D3, () => { if (spMission3.Enabled) { MissionClick(spMission3, null); } }, "Select 3nd mission");
      SetKeyAction(Keys.D4, () => { if (spMission4.Enabled) { MissionClick(spMission4, null); } }, "Select 4th mission");
      SetKeyAction(Keys.D5, () => { if (spMission5.Enabled) { MissionClick(spMission5, null); } }, "Select 5th mission");
      SetKeyAction(Keys.D6, () => { if (spMission6.Enabled) { MissionClick(spMission6, null); } }, "Select 6th mission");
      SetKeyAction(Keys.D7, () => { if (spMission7.Enabled) { MissionClick(spMission7, null); } }, "Select 7th mission");
      SetKeyAction(Keys.D8, () => { if (spMission8.Enabled) { MissionClick(spMission8, null); } }, "Select 8th mission");
      SetKeyAction(Keys.D9, () => { if (spMission9.Enabled) { MissionClick(spMission9, null); } }, "Select 9th mission");
      SetKeyAction(Keys.D0, () => { if (spMission10.Enabled) { MissionClick(spMission10, null); } }, "Select 10th mission");
      SetKeyAction(Keys.R, () => { if (spRefresh.Enabled) { SpRefresh_Click(null, null); } }, "Refresh mission list");
      SetKeyAction(Keys.F5, () => { if (spRefresh.Enabled) { SpRefresh_Click(null, null); } }, "Refresh mission list");
    }

    public void LoadMissions()
    {
      if (ParentForm is GameForm f)
      {
        LoadingScreen loadScr = null;
        try
        {
          MissionSet[] missions = null;
          Task<bool> t = new Task<bool>(() => { return f.Engine.ImportMissions(out missions, _missionFilter); });
          t.Start();
          if (!t.Wait(TIMEOUT_MS_LOADINGSCREEN)) // if loading takes a short time (< 500ms), no need to generate a loading screen
          {
            loadScr = new LoadingScreen(MESSAGE_LOADINGSCREEN);
            f.Popup(loadScr, false);
          }

          if (!t.Wait(TIMEOUT_MS_ERROR))
          {
            throw new TimeoutException(MESSAGE_LOADTIMEOUT);
          }

          SetMissions(t.Result ? missions : null);
        }
        catch (Exception ex)
        {
          SetMissions(null);
          f.Engine.HandleError(ex);
        }
        finally
        {
          if (loadScr != null) { loadScr.Release(); }
        }
      }
    }

    public void SetMissions(MissionSet[] missions)
    {
      _missions = missions ?? new MissionSet[0];
      _page = 0;
      UpdatePage();
    }

    private void UpdatePage()
    {
      this.SuspendDrawing();
      _page = _page.Clamp(0, _missions.Length / MissionBoxes.Length);
      int first = _page * MissionBoxes.Length;
      for (int i = 0; i < MissionBoxes.Length; i++)
      {
        int curr = first + i;
        if (_missions.Length > curr)
        {
          MissionBoxes[i].Text = _missions[curr].Info.Name;
          MissionBoxes[i].Tag = curr;
          MissionBoxes[i].Visible = true;
        }
        else
        {
          MissionBoxes[i].Text = "";
          MissionBoxes[i].Tag = null;
          MissionBoxes[i].Visible = false;
        }
      }

      spPrevPage.Enabled = _page > 0;
      spNextPage.Enabled = _page < _missions.Length / MissionBoxes.Length;
      UpdateSelectedMission();
      this.ResumeDrawing();
    }

    private void UpdateSelectedMission()
    {
      for (int i = 0; i < MissionBoxes.Length; i++)
      {
        if (MissionBoxes[i].Tag is int index && index == _selectedMissionIndex)
        {
          if (MissionBoxes[i].BaseImage != Properties.Resources.BUT9_SEL)
          {
            MissionBoxes[i].SetFade(2);
            MissionBoxes[i].TextColor = System.Drawing.Color.Black;
            MissionBoxes[i].TextHoverColor = System.Drawing.Color.Black;
            MissionBoxes[i].TextShadowOffset = default;
            MissionBoxes[i].BaseImage = Properties.Resources.BUT9_SEL;
            MissionBoxes[i].BackgroundClickImage = Properties.Resources.BUT9_SEL;
          }
        }
        else
        {
          if (MissionBoxes[i].BaseImage != Properties.Resources.BUT9_UP)
          {
            MissionBoxes[i].SetFade(2);
            MissionBoxes[i].TextColor = System.Drawing.Color.Orange;
            MissionBoxes[i].TextHoverColor = System.Drawing.Color.FromArgb(255, 192, 64, 0);
            MissionBoxes[i].TextShadowOffset = new Point(-1,-1);
            MissionBoxes[i].BaseImage = Properties.Resources.BUT9_UP;
            MissionBoxes[i].BackgroundClickImage = Properties.Resources.BUT9_DN;
          }
        }
      }
      if (_selectedMissionIndex >= 0 && _selectedMissionIndex < _missions.Length)
      {
        MissionSet currSet = _missions[_selectedMissionIndex];
        spSelected.Text = currSet.Info.Name;
        try
        {
          MapRulesFile r = new MapRulesFile();
          r.ReadFromFile(currSet.Source.Rules);

          StringBuilder sb = new StringBuilder();
          sb.AppendLine("Mission: {0}".F(currSet.Info.Name));
          sb.AppendLine("Author: {0}".F(r.Basic.Author));
          sb.AppendLine("Playing as: {0}".F(currSet.Info.House));

          spDescription.SetFade(4);
          spDescription.Text = sb.ToString();
          spStart.Enabled = true;
        }
        catch
        {
          spDescription.SetFade(4);
          spDescription.Text = "Error opening mission rules file!";
          spStart.Enabled = false;
        }
      }
      else
      {
        spStart.Enabled = false;
      }
    }

    private void MissionClick(object sender, EventArgs e)
    {
      int sel = (((Control)sender).Tag as int?) ?? -1;
      if (_selectedMissionIndex != sel)
      {
        AudioEngine.Click();
        _selectedMissionIndex = sel;
        this.SuspendDrawing();
        UpdateSelectedMission();
        this.ResumeDrawing();
      }
    }

    public override void Link(GameForm f)
    {
      base.Link(f);
      Clicked_Back = () => f.Remove(this, TransitionStyle.FADE_BLACK);
      Clicked_Start = () => {
        if (_selectedMissionIndex >= 0 && _selectedMissionIndex < _missions.Length)
          f.Push(new MissionBriefingScreen(_missions[_selectedMissionIndex]), TransitionStyle.FADE_BLACK);
      };
    }

    public override void Activate(Engine e, Control prevControl)
    {
      if (prevControl is LoadingScreen || prevControl is ErrorScreen || prevControl is KeyNavigationHelpScreen || prevControl is MissionBriefingScreen) { return; }
      LoadMissions();
    }

    private void SpNextPage_Click(object sender, EventArgs e) { AudioEngine.Click(); _page++; UpdatePage(); }
    private void SpPrevPage_Click(object sender, EventArgs e) { AudioEngine.Click(); _page--; UpdatePage(); }
    private void SpBack_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Back?.Invoke(); }
    private void SpStart_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Start?.Invoke(); }
    private void SpRefresh_Click(object sender, EventArgs e) { AudioEngine.Click(); LoadMissions(); }
    private void SpKeyHelp_Click(object sender, EventArgs e) { Clicked_KeyHelp?.Invoke(); }
  }
}
