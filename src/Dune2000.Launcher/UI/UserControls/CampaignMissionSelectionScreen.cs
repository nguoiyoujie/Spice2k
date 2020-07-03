using Dune2000.Extensions.FileFormats.INI;
using Dune2000.Extensions.Missions;
using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.UI.Objects;
using Dune2000.Launcher.Util;
using FastBitmapLib;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using Primrose.Primitives.ValueTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class CampaignMissionSelectionScreen : PreviewKeyUserControl, ILinkedControl
  {
    // const
    public const int FADE_STEPS = 5;
    private const float ICON_SCALE = 0.75f; // avoid ugly overlap, WinForms doesn't draw as well as native game does.

    // fixed
    private readonly Image[] _iconSprite = new Image[] { Properties.Resources.ATRE_POINT, Properties.Resources.HARK_POINT, Properties.Resources.ORDO_POINT };
    private readonly Bitmap _colorImage;

    // images
    private readonly FastBitmap[] _samples;
    private readonly FastBitmap _territoryData;

    // calculated
    private int _terriories;
    private Size _territoryBitmapSize;
    private float2[] _centers;
    private short[,] _mapData;

    public const int TIMEOUT_MS_LOADINGSCREEN = 500;
    public const int TIMEOUT_MS_ERROR = 60000;

    public const string MESSAGE_LOADINGSCREEN = "Updating mission list...";
    public const string MESSAGE_LOADTIMEOUT = "Too long to load missions!";

    public UpdateDelegate Clicked_Back;

    private Registry<CampaignStageInfo, MissionSet[]> _missions = new Registry<CampaignStageInfo, MissionSet[]>();
    private int _page;

    private readonly IComparer<Color> _colorCmp = new ColorComparer();
    private readonly CampaignFile _campaignFile;
    private readonly List<SpriteBox> _missionBoxes = new List<SpriteBox>();

    public int Page { get { return _page; } set { if (_page != value) { AudioEngine.Click(); _page = value; UpdatePage(true); } } }
    public int PageMax { get { return (_campaignFile == null || _campaignFile.Stages == null) ? 0 : _campaignFile.Stages.Length - 1; } }

    public class ColorComparer : IComparer<Color>
    {
      public int Compare(Color x, Color y)
      {
        return x.ToArgb().CompareTo(y.ToArgb());
      }
    }

    public CampaignMissionSelectionScreen(CampaignFile campaignFile)
    {
      InitializeComponent();
      Dock = DockStyle.Fill;

      _campaignFile = campaignFile;

      string bg = _campaignFile.Images.Background;
      string mask = _campaignFile.Images.Mask;
      string[] layers = _campaignFile.Images.Layers;

      _samples = new FastBitmap[layers?.Length ?? 0];
      for (int i = 0; i < _samples.Length; i++)
      {
        _samples[i] = new Bitmap(layers[i]).FastLock();
      }
      Bitmap tdata = new Bitmap(mask);
      spBG.BaseImage = new Bitmap(bg);

      /*
      _samples = new FastBitmap[3];
      _samples[0] = Properties.Resources.DUNETERRITORY_AT.FastLock();
      _samples[1] = Properties.Resources.DUNETERRITORY_HK.FastLock();
      _samples[2] = Properties.Resources.DUNETERRITORY_OD.FastLock();
      Bitmap tdata = Properties.Resources.DUNETERRITORY;
      */

      _territoryData = tdata.FastLock();
      _territoryBitmapSize = tdata.Size;
      _colorImage = new Bitmap(_territoryBitmapSize.Width, _territoryBitmapSize.Height);
      _colorImage.MakeTransparent();

      AnalyseImage();

      SetKeyAction(Keys.Escape, () => { if (spBack.Enabled) { SpBack_Click(null, null); } }, "Return to previous menu");
      SetKeyAction(Keys.Left, () => { if (spPrevPage.Enabled) { SpPrevPage_Click(null, null); } }, "Previous mission");
      SetKeyAction(Keys.Right, () => { if (spNextPage.Enabled) { SpNextPage_Click(null, null); } }, "Next mission");
      SetKeyAction(Keys.D1, () => { if (spTerritories.Controls.Count >= 1) { (spTerritories.Controls[0] as SpriteBox)?.DoClick(); } }, "Mission Choice 1");
      SetKeyAction(Keys.D2, () => { if (spTerritories.Controls.Count >= 2) { (spTerritories.Controls[1] as SpriteBox)?.DoClick(); } }, "Mission Choice 2");
      SetKeyAction(Keys.D3, () => { if (spTerritories.Controls.Count >= 3) { (spTerritories.Controls[2] as SpriteBox)?.DoClick(); } }, "Mission Choice 3");
      SetKeyAction(Keys.D4, () => { if (spTerritories.Controls.Count >= 4) { (spTerritories.Controls[3] as SpriteBox)?.DoClick(); } }, "Mission Choice 4");
      SetKeyAction(Keys.D5, () => { if (spTerritories.Controls.Count >= 5) { (spTerritories.Controls[4] as SpriteBox)?.DoClick(); } }, "Mission Choice 5");
      SetKeyAction(Keys.D6, () => { if (spTerritories.Controls.Count >= 6) { (spTerritories.Controls[5] as SpriteBox)?.DoClick(); } }, "Mission Choice 6");
      SetKeyAction(Keys.D7, () => { if (spTerritories.Controls.Count >= 7) { (spTerritories.Controls[6] as SpriteBox)?.DoClick(); } }, "Mission Choice 7");
      SetKeyAction(Keys.D8, () => { if (spTerritories.Controls.Count >= 8) { (spTerritories.Controls[7] as SpriteBox)?.DoClick(); } }, "Mission Choice 8");
      SetKeyAction(Keys.D9, () => { if (spTerritories.Controls.Count >= 9) { (spTerritories.Controls[8] as SpriteBox)?.DoClick(); } }, "Mission Choice 9");
      SetKeyAction(Keys.R, () => { if (spRefresh.Enabled) { SpRefresh_Click(null, null); } }, "Refresh mission list");
      SetKeyAction(Keys.F5, () => { if (spRefresh.Enabled) { SpRefresh_Click(null, null); } }, "Refresh mission list");
    }

    private void AnalyseImage()
    {
      _mapData = new short[_territoryBitmapSize.Width, _territoryBitmapSize.Height];
      List<Color> colors = new List<Color>();

      // count all colors excluding the transparent color
      for (int x = 0; x < _territoryBitmapSize.Width; x++)
        for (int y = 0; y < _territoryBitmapSize.Height; y++)
        {
          Color c = _territoryData.GetPixel(x, y);
          if (c.A > 0 && !colors.Contains(c))
            colors.Add(c);
        }

      // sort colors according to int ARGB
      colors.Sort(_colorCmp);
      _terriories = colors.Count;
      //Queue<float2>[] pixels = new Queue<float2>[_terriories];
      _centers = new float2[_terriories];
      int[] points = new int[_terriories];

      // sort each pixel and write to _mapData
      for (int x = 0; x < _territoryBitmapSize.Width; x++)
        for (int y = 0; y < _territoryBitmapSize.Height; y++)
        {
          Color c = _territoryData.GetPixel(x, y);
          short regID = (short)colors.IndexOf(c);

          _mapData[x, y] = regID;
          if (regID >= 0 && regID < _terriories) 
          {
            _centers[regID] += new float2(x, y);
            points[regID]++;
          }
        }

      // turn sums to averages
      for (int i = 0; i < _terriories; i++)
      {
        if (points[i] > 0)
          _centers[i] /= points[i];
      }
    }

    private void ColorImage(short[] colorMap)
    {
      using (FastBitmap fimg = _colorImage.FastLock())
      {
        fimg.Clear(Color.Transparent);
        for (int x = 0; x < _territoryBitmapSize.Width; x++)
          for (int y = 0; y < _territoryBitmapSize.Height; y++)
          {
            short rank = _mapData[x, y];
            if (rank >= 0 && rank < colorMap.Length && colorMap[rank] >= 0 && colorMap[rank] < _samples.Length)
            {
              Color c = _samples[colorMap[rank]].GetPixel(x, y);
              fimg.SetPixel(x, y, c);
            }
          }
      }

      spTerritories.BaseImage = _colorImage;
    }

    private void ClearIcons()
    {
      foreach (SpriteBox sp in _missionBoxes)
      {
        spTerritories.Controls.Remove(sp);
        GameForm.UIPipeline.Queue(sp.Dispose);
      }
    }

    private void AddIcon(int houseIndex, MissionSet set, short regionID, string[] unitDescriptions)
    {
      if (regionID <= 0 || houseIndex < 0 || houseIndex > _iconSprite.Length) { return; }

      if (ParentForm is GameForm f)
      {
        // regionIDs are one-based
        int regIndex = regionID - 1;

        SpriteBox sp = new SpriteBox();
        // Add first
        _missionBoxes.Add(sp);
        spTerritories.Controls.Add(sp);

        sp.BaseImage = _iconSprite[houseIndex];
        sp.Click += (o, e) => { AudioEngine.Click(); f.Push(new MissionBriefingScreen(set, unitDescriptions), TransitionStyle.FADE_BLACK); };

        float2 iconLoc = _centers[regIndex];
        float2 sz = spTerritories.Size.ToFloat2() / _territoryBitmapSize.ToFloat2() * _iconSprite[houseIndex].Size.ToFloat2() * ICON_SCALE;
        float2 loc = spTerritories.Size.ToFloat2() * iconLoc / _territoryBitmapSize.ToFloat2() - sz / 2;

        sp.Location = loc.ToPoint();
        sp.Size = sz.ToSize();
      }
    }

    public void LoadMissions()
    {
      if (ParentForm is GameForm f)
      {
        LoadingScreen loadScr = null;
        try
        {
          f.Lock(this);
          Registry<CampaignStageInfo, MissionSet[]> missions = null;
          Task<bool> t = new Task<bool>(() => { return f.Engine.ImportMissions(out missions, _campaignFile.GetStage); });
          t.Start();
          if (!t.Wait(TIMEOUT_MS_LOADINGSCREEN)) // if loading takes a short time (< 500ms), no need to generate a loading screen
          {
            loadScr = new LoadingScreen(MESSAGE_LOADINGSCREEN);
            f.Popup(loadScr, false);
          }

          if (!t.Wait(TIMEOUT_MS_ERROR)) // takes too long, likely an error has occured
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
          f.Unlock(this);
        }
      }
    }

    public void SetMissions(Registry<CampaignStageInfo, MissionSet[]> missions)
    {
      _missions = missions ?? new Registry<CampaignStageInfo, MissionSet[]>();
      _page = 0;
      UpdatePage(false);
    }

    private void SetFade()
    {
      spTerritories.SetFade(FADE_STEPS);
      spTitle.SetFade(FADE_STEPS);
    }

    private void UpdatePage(bool setFade)
    {
      if (setFade) { SetFade(); }

      if (_campaignFile.Stages == null || _page < 0 || _page >= _campaignFile.Stages.Length) { return; }
      CampaignStageInfo stage = _campaignFile.Stages[_page];
      //if (stage.House < 0 || (int)stage.House >= _iconSprite.Length) { return; }

      this.SuspendDrawing();
      spPrevPage.Enabled = false;
      spNextPage.Enabled = false;
      ColorImage(stage.CampaignColorMap);
      ClearIcons();
      spTitle.Text = _campaignFile.Stages[_page].Name;
      this.ResumeDrawing();

      if (setFade)
      {
        spTerritories.FadeCycleCompleted = () => UpdateIcons(stage);
      }
      else
      {
        UpdateIcons(stage);
      }
    }

    private void UpdateIcons(CampaignStageInfo stage)
    {
      this.SuspendDrawing();
      for (int i = 0; i < stage.Missions.Length; i++)
      {
        CampaignMissionInfo mission = stage.Missions[i];
        AddIcon((int)mission.House, _missions[stage][i], mission.RegionID, mission.UnitDescription ?? stage.UnitDescription);
      }
      spPrevPage.Enabled = _page > 0;
      spNextPage.Enabled = _page < _campaignFile.Stages.Length - 1;
      this.ResumeDrawing();
      spTerritories.FadeCycleCompleted = null;
    }

    public override void Link(GameForm f)
    {
      base.Link(f);
      Clicked_Back = () => f.Remove(this, TransitionStyle.FADE_BLACK);
    }

    public override void Activate(Engine e, Control prevControl)
    {
      if (prevControl is LoadingScreen || prevControl is ErrorScreen || prevControl is KeyNavigationHelpScreen || prevControl is MissionBriefingScreen) { return; }
      LoadMissions();
    }

    public override void Deactivate(Engine e)
    {
    }

    private void SpPrevPage_Click(object sender, EventArgs e) { Page = (Page - 1).Clamp(0, PageMax); }  
    private void SpNextPage_Click(object sender, EventArgs e) { Page = (Page + 1).Clamp(0, PageMax); }
    private void SpBack_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Back?.Invoke(); }
    private void SpRefresh_Click(object sender, EventArgs e) { AudioEngine.Click(); LoadMissions(); }
    private void SpKeyHelp_Click(object sender, EventArgs e) { Clicked_KeyHelp?.Invoke(); }

    private void DisposeInner()
    {
      foreach (FastBitmap sample in _samples) { if (!sample.Locked) { sample.Dispose(); } }
      if (!_territoryData.Locked) { _territoryData.Dispose(); }
    }

  }
}
