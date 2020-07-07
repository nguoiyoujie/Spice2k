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
using Primrose.Primitives.Factories;

namespace Dune2000.Editor.UI.UserControls
{
  public partial class ucCampaignUibEditor : EditorControl
  {
    public ucCampaignUibEditor()
    {
      InitializeComponent();

      cbDirection1.Items.AddRange(Enum.GetNames(typeof(Direction)));
      cbDirection2.Items.AddRange(Enum.GetNames(typeof(Direction)));

      string[] greatHouses = new string[] { House.ATREIDES.ToString(), House.HARKONNEN.ToString(), House.ORDOS.ToString() };
      cbHouse.Items.AddRange(greatHouses);
      cbHouse1.Items.AddRange(greatHouses);
      cbHouse2.Items.AddRange(greatHouses);
      cbHouse3.Items.AddRange(greatHouses);
      cbEnemyHouse.Items.AddRange(greatHouses);

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
    }

    private CampaignUibFile _uib;
    private CampaignUibFile _uibWorkingCopy;
    private int _house;
    private int _scenario;

    public override bool SupportSearch { get { return false; } }
    public override string OpenFileFilter { get { return "Campaign uib files|campaign*.uib|Dune 2000 uib files|*.uib|All files|*.*"; } }
    public override string SaveFileFilter { get { return "Dune 2000 uib files|*.uib|All files|*.*"; } }

    public override void Unload()
    {
      cbDirection1.SelectedIndex = -1;
      cbDirection2.SelectedIndex = -1;
      cbHouse1.SelectedIndex = -1;
      cbHouse2.SelectedIndex = -1;
      cbHouse3.SelectedIndex = -1;
      cbEnemyHouse.SelectedIndex = -1;

      tbMapFile1.Text = "";
      tbMapFile2.Text = "";
      tbSFX1.Text = "";
      tbSFX2.Text = "";
      tbSFX3.Text = "";
      tbTheme.Text = "";

      nudR1.Value = 0;
      nudR2.Value = 0;
      nudA1.Value = 0;
      nudA2.Value = 0;
      nudA3.Value = 0;
      nudH1.Value = 0;
      nudH2.Value = 0;
      nudH3.Value = 0;
      nudO1.Value = 0;
      nudO2.Value = 0;
      nudO3.Value = 0;
      nudIcon1X.Value = 0;
      nudIcon1Y.Value = 0;
      nudIcon2X.Value = 0;
      nudIcon2Y.Value = 0;
      nudScore.Value = 0;
      panel1.Enabled = false;

      pbPreview.Image?.Dispose();
      pbPreview.Image = null;
    }

    private void ReloadPage(bool force = false)
    {
      if (cbHouse.SelectedIndex == -1) { cbHouse.SelectedIndex = 0; }
      if (cbScenario.SelectedIndex == -1) { cbScenario.SelectedIndex = 0; }

      if (!force && _house == cbHouse.SelectedIndex && _scenario == cbScenario.SelectedIndex) { return; }

      _house = cbHouse.SelectedIndex;
      _scenario = cbScenario.SelectedIndex;

      CampaignMissionData data = _uibWorkingCopy.Houses[_house].Missions[_scenario];

      cbDirection1.SelectedIndex = ((int)data.Unconfirmed_Direction1).Clamp(0, cbDirection1.Items.Count);
      cbDirection2.SelectedIndex = ((int)data.Unconfirmed_Direction2).Clamp(0, cbDirection2.Items.Count);
      cbHouse1.SelectedIndex = ((int)data.RegionAnim_House1).Clamp(0, cbHouse1.Items.Count);
      cbHouse2.SelectedIndex = ((int)data.RegionAnim_House2).Clamp(0, cbHouse2.Items.Count);
      cbHouse3.SelectedIndex = ((int)data.RegionAnim_House3).Clamp(0, cbHouse3.Items.Count);
      cbEnemyHouse.SelectedIndex = ((int)data.ScoreEnemyHouse).Clamp(0, cbEnemyHouse.Items.Count);

      tbMapFile1.Text = data.MissionFile1;
      tbMapFile2.Text = data.MissionFile2;
      tbSFX1.Text = data.SFX1;
      tbSFX2.Text = data.SFX2;
      tbSFX3.Text = data.SFX3;
      tbTheme.Text = data.Theme;

      nudR1.Value = data.RegionID1;
      nudR2.Value = data.RegionID2;

      byte[] atr = data.RegionsAwardedToAtreides;
      byte[] har = data.RegionsAwardedToHarkonnen;
      byte[] ord = data.RegionsAwardedToOrdos;
      nudA1.Value = atr[0];
      nudA2.Value = atr[1];
      nudA3.Value = atr[2];
      nudH1.Value = har[0];
      nudH2.Value = har[1];
      nudH3.Value = har[2];
      nudO1.Value = ord[0];
      nudO2.Value = ord[1];
      nudO3.Value = ord[2];
      nudIcon1X.Value = ((decimal)data.Region1IconX).Clamp(nudIcon1X.Minimum, nudIcon1X.Maximum);
      nudIcon1Y.Value = ((decimal)data.Region1IconY).Clamp(nudIcon1Y.Minimum, nudIcon1Y.Maximum);
      nudIcon2X.Value = ((decimal)data.Region2IconX).Clamp(nudIcon2X.Minimum, nudIcon2X.Maximum);
      nudIcon2Y.Value = ((decimal)data.Region2IconY).Clamp(nudIcon2Y.Minimum, nudIcon2Y.Maximum);
      nudScore.Value = ((decimal)data.ScoreMultiplier).Clamp(nudScore.Minimum, nudScore.Maximum);

      // enable / disable region fields
      tbMapFile1.Enabled = nudR1.Value != 0;
      cbDirection1.Enabled = nudR1.Value != 0;
      nudIcon1X.Enabled = nudR1.Value != 0;
      nudIcon1Y.Enabled = nudR1.Value != 0;

      tbMapFile2.Enabled = nudR2.Value != 0;
      cbDirection2.Enabled = nudR2.Value != 0;
      nudIcon2X.Enabled = nudR2.Value != 0;
      nudIcon2Y.Enabled = nudR2.Value != 0;
    }

    public override void Reload()
    {
      _uibWorkingCopy = _uib;
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
        _uibWorkingCopy = uib;
        _dirty = false;
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
      _uib = _uibWorkingCopy;
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

    private void nudR1_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionID1 = (byte)nudR1.Value;
      tbMapFile1.Enabled = nudR1.Value != 0;
      cbDirection1.Enabled = nudR1.Value != 0;
      nudIcon1X.Enabled = nudR1.Value != 0;
      nudIcon1Y.Enabled = nudR1.Value != 0;
    }

    private void nudR2_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionID2 = (byte)nudR2.Value;
      tbMapFile2.Enabled = nudR2.Value != 0;
      cbDirection2.Enabled = nudR2.Value != 0;
      nudIcon2X.Enabled = nudR2.Value != 0;
      nudIcon2Y.Enabled = nudR2.Value != 0;
    }

    private void nudIcon1X_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Region1IconX = (int)nudIcon1X.Value;
    }

    private void nudIcon1Y_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Region1IconY = (int)nudIcon1Y.Value;
    }

    private void nudIcon2X_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Region2IconX = (int)nudIcon2X.Value;
    }

    private void nudIcon2Y_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Region2IconY = (int)nudIcon2Y.Value;
    }

    private void nudA_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToAtreides = new byte[] { (byte)nudA1.Value, (byte)nudA2.Value, (byte)nudA3.Value };
    }

    private void nudH_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToHarkonnen = new byte[] { (byte)nudH1.Value, (byte)nudH2.Value, (byte)nudH3.Value };
    }

    private void nudO_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionsAwardedToOrdos = new byte[] { (byte)nudO1.Value, (byte)nudO2.Value, (byte)nudO3.Value };
    }

    private void nudScore_ValueChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].ScoreMultiplier = (float)nudScore.Value;
    }

    private void tbMapFile1_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].MissionFile1 = tbMapFile1.Text;
    }

    private void tbMapFile2_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].MissionFile2 = tbMapFile2.Text;
    }

    private void tbSFX1_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX1 = tbSFX1.Text;
    }

    private void tbSFX2_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX2 = tbSFX2.Text;
    }

    private void tbSFX3_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].SFX3 = tbSFX3.Text;
    }

    private void tbTheme_TextChanged(object sender, EventArgs e)
    {
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Theme = tbTheme.Text;
    }

    private void cbDirection1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbDirection1.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Unconfirmed_Direction1 = (Direction)index;
    }

    private void cbDirection2_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbDirection2.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].Unconfirmed_Direction2 = (Direction)index;
    }

    private void cbHouse1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse1.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House1 = (House)index;
    }

    private void cbHouse2_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse2.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House2 = (House)index;
    }

    private void cbHouse3_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse3.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].RegionAnim_House3 = (House)index;
    }

    private void cbEnemyHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbEnemyHouse.SelectedIndex.Max(0);
      _uibWorkingCopy.Houses[_house].Missions[_scenario].ScoreEnemyHouse = (House)index;
    }

    private void bBefAnim_Click(object sender, EventArgs e)
    {
      Simulate(0);
    }

    private void bAnim1_Click(object sender, EventArgs e)
    {
      Simulate(1);
    }

    private void bAnim2_Click(object sender, EventArgs e)
    {
      Simulate(2);
    }

    private void bAnim3_Click(object sender, EventArgs e)
    {
      Simulate(3);
    }

    private void bFinal_Click(object sender, EventArgs e)
    {
      Simulate(3, true);
    }

    Color[] _houseColors = new Color[] { Color.LightBlue, Color.DarkRed, Color.ForestGreen };

    private void Simulate(int anims = 0, bool icons = false)
    {
      try
      {
        Registry<int, int> alloc = new Registry<int, int>();
        alloc.Default = -1;

        for (int scen = 0; scen < _scenario; scen++)
        {
          CampaignMissionData data = _uibWorkingCopy.Houses[_house].Missions[scen];

          House[] animOrder = new House[] {
            data.RegionAnim_House1,
            data.RegionAnim_House2,
            data.RegionAnim_House3
          };

          for (int h = 0; h < animOrder.Length; h++)
          {
            if (scen < _scenario - 1 || anims > h)
            {
              int ihouse = (int)animOrder[h];
              if (_house == ihouse) { alloc.Put(data.RegionID1, ihouse); alloc.Put(data.RegionID2, ihouse); }
              switch (animOrder[h])
              {
                case House.ATREIDES:
                  foreach (int r in data.RegionsAwardedToAtreides) { alloc.Put(r, ihouse); }
                  break;

                case House.HARKONNEN:
                  foreach (int r in data.RegionsAwardedToHarkonnen) { alloc.Put(r, ihouse); }
                  break;

                case House.ORDOS:
                  foreach (int r in data.RegionsAwardedToOrdos) { alloc.Put(r, ihouse); }
                  break;
              }
            }
          }
        }

        // get regions
        RegionPolygonBinFile bin = new RegionPolygonBinFile();
        bin.ReadFromFile(@"assets\map\points.bin");
        Bitmap bmp = new Bitmap(pbPreview.Width, pbPreview.Height);

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

            int owner = alloc.Get(r + 1);
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
      pRegion.Visible = !pRegion.Visible;
    }

    private void llblCommon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      pCommon.Visible = !pCommon.Visible;
    }

    private void llblPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      pPreview.Visible = !pPreview.Visible;
    }
  }
}
