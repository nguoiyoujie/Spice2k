using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Dune2000.Editor.Util;
using Dune2000.Enums;
using Dune2000.Extensions.FileFormats.Bin;
using Dune2000.Extensions.Structs.Bin;
using Dune2000.FileFormats.Uib;
using Dune2000.Structs.Uib;
using Primrose.Primitives.Extensions;

namespace Dune2000.Editor.UI.Editors.Uib.Campaign
{
  public partial class ucCampaignUibEditor : EditorControl
  {
    public ucCampaignUibEditor()
    {
      InitializeComponent();

      string[] greatHouses = new string[] { House.ATREIDES.ToString(), House.HARKONNEN.ToString(), House.ORDOS.ToString() };
      cbHouse.Items.AddRange(greatHouses);

      string[] mapScenario = new string[] 
      { 
        "Initial state before mission 1",
        "Mission 1",
        "Mission 2",
        "Mission 3",
        "Mission 4",
        "Mission 5",
        "Mission 6",
        "Mission 7",
        "Mission 8",
        "Mission 9"
      };
      cbScenario.Items.AddRange(mapScenario);

      panel1.Enabled = false;

      cRegionPanel.RegionID1Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionID1 = m; _dirty = true; } };
      cRegionPanel.RegionID2Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionID2 = m; _dirty = true; } };
      cRegionPanel.MissionFile1Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].MissionFile1 = m; _dirty = true; } };
      cRegionPanel.MissionFile2Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].MissionFile2 = m; _dirty = true; } };
      cRegionPanel.Icon1XChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].Region1IconX = m; _dirty = true; } };
      cRegionPanel.Icon1YChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].Region1IconY = m; _dirty = true; } };
      cRegionPanel.Icon2XChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].Region2IconX = m; _dirty = true; } };
      cRegionPanel.Icon2YChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].Region2IconY = m; _dirty = true; } };

      cCommonPanel.RegionToAtreidesChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToAtreides = m; _dirty = true; } };
      cCommonPanel.RegionToHarkonnenChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToHarkonnen = m; _dirty = true; } };
      cCommonPanel.RegionToOrdosChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToOrdos = m; _dirty = true; } };
      cCommonPanel.ScoreMultiplierChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].ScoreMultiplier = m; _dirty = true; } };
      cCommonPanel.SFX1Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX1 = m; _dirty = true; } };
      cCommonPanel.SFX2Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX2 = m; _dirty = true; } };
      cCommonPanel.SFX3Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX3 = m; _dirty = true; } };
      cCommonPanel.RegionAnim_House1Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House1 = m; _dirty = true; } };
      cCommonPanel.RegionAnim_House2Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House2 = m; _dirty = true; } };
      cCommonPanel.RegionAnim_House3Changed = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House3 = m; _dirty = true; } };
      cCommonPanel.ThemeChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].Theme = m; _dirty = true; } };
      cCommonPanel.EnemyHouseChanged = (m) => { if (!_cpuedit) { _uibWorkingCopy.Houses[_house].Missions[_scenario].ScoreEnemyHouse = m; _dirty = true; } };
    }

    private CampaignUibFile _uib;
    private CampaignUibFile _uibWorkingCopy;
    private int _house;
    private int _scenario;
    private bool _cpuedit;

    public override bool SupportSearch { get { return false; } }
    public override string OpenFileFilter { get { return "Campaign uib files|campaign*.uib|Dune 2000 uib files|*.uib|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 uib files|*.uib|All files|*.*"; } }

    public override void Unload()
    {
      _cpuedit = true;
      cRegionPanel.Direction1 = -1;
      cRegionPanel.Direction2 = -1;
      cCommonPanel.RegionAnim_House1 = -1;
      cCommonPanel.RegionAnim_House2 = -1;
      cCommonPanel.RegionAnim_House3 = -1;
      cCommonPanel.EnemyHouse = -1;

      cRegionPanel.MissionFile1 = "";
      cRegionPanel.MissionFile2 = "";

      cCommonPanel.SFX1 = "";
      cCommonPanel.SFX2 = "";
      cCommonPanel.SFX3 = "";
      cCommonPanel.Theme = "";

      cRegionPanel.RegionID1 = 0;
      cRegionPanel.RegionID2 = 0;
      cRegionPanel.Icon1X = 0;
      cRegionPanel.Icon1Y = 0;
      cRegionPanel.Icon2X = 0;
      cRegionPanel.Icon2Y = 0;

      cCommonPanel.RegionToAtreides1 = 0;
      cCommonPanel.RegionToAtreides2 = 0;
      cCommonPanel.RegionToAtreides3 = 0;
      cCommonPanel.RegionToHarkonnen1 = 0;
      cCommonPanel.RegionToHarkonnen2 = 0;
      cCommonPanel.RegionToHarkonnen3 = 0;
      cCommonPanel.RegionToOrdos1 = 0;
      cCommonPanel.RegionToOrdos2 = 0;
      cCommonPanel.RegionToOrdos3 = 0;
      cCommonPanel.ScoreMultiplier = 0;

      panel1.Enabled = false;

      pbPreview.Image?.Dispose();
      pbPreview.Image = null;

      _cpuedit = false;
      _path = null;
    }

    private void ReloadPage(bool force = false)
    {
      _cpuedit = true;

      if (cbHouse.SelectedIndex == -1) { cbHouse.SelectedIndex = 0; }
      if (cbScenario.SelectedIndex == -1) { cbScenario.SelectedIndex = 0; }

      if (!force && _house == cbHouse.SelectedIndex && _scenario == cbScenario.SelectedIndex) { return; }

      _house = cbHouse.SelectedIndex;
      _scenario = cbScenario.SelectedIndex;

      CampaignMissionData data = _uibWorkingCopy.Houses[_house].Missions[_scenario];

      cRegionPanel.Direction1 = (int)data.Unconfirmed_Direction1;
      cRegionPanel.Direction2 = (int)data.Unconfirmed_Direction2;
      cCommonPanel.RegionAnim_House1 = (int)data.RegionAnim_House1;
      cCommonPanel.RegionAnim_House2 = (int)data.RegionAnim_House2;
      cCommonPanel.RegionAnim_House3 = (int)data.RegionAnim_House3;
      cCommonPanel.EnemyHouse = (int)data.ScoreEnemyHouse;

      cRegionPanel.MissionFile1 = data.MissionFile1;
      cRegionPanel.MissionFile2 = data.MissionFile2;
      cCommonPanel.SFX1 = data.SFX1;
      cCommonPanel.SFX2 = data.SFX2;
      cCommonPanel.SFX3 = data.SFX3;
      cCommonPanel.Theme = data.Theme;

      cRegionPanel.RegionID1 = data.RegionID1;
      cRegionPanel.RegionID2 = data.RegionID2;

      byte[] atr = data.RegionsAwardedToAtreides;
      byte[] har = data.RegionsAwardedToHarkonnen;
      byte[] ord = data.RegionsAwardedToOrdos;
      cCommonPanel.RegionToAtreides1 = atr[0];
      cCommonPanel.RegionToAtreides2 = atr[1];
      cCommonPanel.RegionToAtreides3 = atr[2];
      cCommonPanel.RegionToHarkonnen1 = har[0];
      cCommonPanel.RegionToHarkonnen2 = har[1];
      cCommonPanel.RegionToHarkonnen3 = har[2];
      cCommonPanel.RegionToOrdos1 = ord[0];
      cCommonPanel.RegionToOrdos2 = ord[1];
      cCommonPanel.RegionToOrdos3 = ord[2];
      cCommonPanel.ScoreMultiplier = data.ScoreMultiplier;

      cRegionPanel.Icon1X = data.Region1IconX;
      cRegionPanel.Icon1Y = data.Region1IconY;
      cRegionPanel.Icon2X = data.Region2IconX;
      cRegionPanel.Icon2Y = data.Region2IconY;

      // enable / disable region fields
      cRegionPanel.UpdateR1();
      cRegionPanel.UpdateR2();

      _cpuedit = false;
    }

    public override void Reload()
    {
      _uibWorkingCopy = _uib.Clone();
      ReloadPage(true);
      _dirty = false;
      panel1.Enabled = true;
    }

    public override bool LoadFile(string path)
    {
      try
      {
        CampaignUibFile uib = new CampaignUibFile(); // seperate copy so incase of read error, _uib is not overwritten
        uib.ReadFromFile(path);
        _uib = uib;
        _uibWorkingCopy = uib.Clone();
        _dirty = false;
        _path = path;
        return true;
      }
      catch 
      {
        MessageBox.Show("The file is not a valid campaign uib file.");
        return false;
      }
    }

    public override bool SaveFile(string path)
    {
      _uibWorkingCopy.WriteToFile(path);
      _uib = _uibWorkingCopy.Clone();
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

    private void bBefAnim_Click(object sender, EventArgs e)
    {
      Simulate(AnimStage.BEFORE_ANIM);
    }

    private void bAnim1_Click(object sender, EventArgs e)
    {
      Simulate(AnimStage.AFTER_SFX1);
    }

    private void bAnim2_Click(object sender, EventArgs e)
    {
      Simulate(AnimStage.AFTER_SFX2);
    }

    private void bAnim3_Click(object sender, EventArgs e)
    {
      Simulate(AnimStage.AFTER_SFX3);
    }

    private void bFinal_Click(object sender, EventArgs e)
    {
      Simulate(AnimStage.AFTER_SFX3, true);
    }

    Color[] _houseColors = new Color[] { Color.LightBlue, Color.DarkRed, Color.ForestGreen };

    private void Simulate(AnimStage stage = AnimStage.BEFORE_ANIM, bool icons = false)
    {
      try
      {
        // get regions
        RegionPolygonBinFile bin = new RegionPolygonBinFile();
        bin.ReadFromFile(@"assets\map\points.bin");
        Bitmap bmp = new Bitmap(pbPreview.Width, pbPreview.Height);

        House[] regionOwners = new House[bin.Polygons.Count];

        _uibWorkingCopy.GetRegionOwnership(ref regionOwners, (House)_house, _scenario, stage);

        // paint regions
        using (Graphics g = Graphics.FromImage(bmp))
        {
          g.DrawImage(new Bitmap(@"assets\map\dunemap2.png"), pbPreview.DisplayRectangle);

          for (int r = 0; r < bin.Polygons.Count; r++)
          {
            RegionPolygonData data = bin.Polygons[r];
            Point[] pts = new Point[data.Polygon.Length];
            for (int i = 0; i < pts.Length; i++)
            {
              pts[i] = data.Polygon[i].ToPoint();
            }

            int owner = (int)regionOwners[r];
            if (owner == owner.Clamp(0, 2))
            {
              using (Brush brush = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(0xCF, _houseColors[owner]), Color.Transparent))
              {
                g.FillPolygon(brush, pts);
              }
            }

            using (Pen pen = new Pen(Color.FromArgb(0x7F, Color.Black)))
            {
              g.DrawPolygon(pen, pts);
            }

            if (icons)
            {
              CampaignMissionData currData = _uibWorkingCopy.Houses[_house].Missions[_scenario];
              Size sz = new Size(72, 70);
              if (currData.RegionID1 == r + 1 || currData.RegionID2 == r + 1)
              {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                  g.DrawPolygon(pen, pts);
                }
              }

              using (Pen pen = new Pen(Color.DarkBlue))
              {
                using (Brush brush = new SolidBrush(Color.DarkBlue))
                {
                  if (currData.RegionID1 > 0)
                  {
                    Point pt = currData.Region1IconPosition.ToPoint();
                    g.DrawRectangle(pen, new Rectangle(pt, sz));
                    g.DrawString(currData.MissionFile1, DefaultFont, brush, pt.X + 10, pt.Y + 10);
                }
                  if (currData.RegionID2 > 0)
                  {
                    Point pt = currData.Region2IconPosition.ToPoint();
                    g.DrawRectangle(pen, new Rectangle(pt, sz));
                    g.DrawString(currData.MissionFile2, DefaultFont, brush, pt.X + 10, pt.Y + 10);
                  }
                }
              }
            }

            using (Brush brush = new SolidBrush(Color.White))
            {
              g.DrawString("{0}, {1}".F(cbHouse.Text, cbScenario.Text), DefaultFont, brush, new Point(5,5));
            }
          }
        }

        pbPreview.Image?.Dispose();
        pbPreview.Image = bmp;
      }
      catch { }
    }

    private void llblRegion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      cRegionPanel.Visible = !cRegionPanel.Visible;
    }

    private void llblCommon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      cCommonPanel.Visible = !cCommonPanel.Visible;
    }

    private void llblPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      pPreview.Visible = !pPreview.Visible;
    }
  }
}
