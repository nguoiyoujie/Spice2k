using Dune2000.Enums;
using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Uib.Campaign
{
  public partial class CampaignCommonPanel : Panel
  {
    public CampaignCommonPanel()
    {
      InitializeComponent();

      string[] greatHouses = new string[] { House.ATREIDES.ToString(), House.HARKONNEN.ToString(), House.ORDOS.ToString() };
      cbHouse1.Items.AddRange(greatHouses);
      cbHouse2.Items.AddRange(greatHouses);
      cbHouse3.Items.AddRange(greatHouses);
      cbEnemyHouse.Items.AddRange(greatHouses);
    }

    public byte RegionToAtreides1 { get { return (byte)nudA1.Value; } set { nudA1.Value = value; } }
    public byte RegionToAtreides2 { get { return (byte)nudA2.Value; } set { nudA2.Value = value; } }
    public byte RegionToAtreides3 { get { return (byte)nudA3.Value; } set { nudA3.Value = value; } }
    public byte RegionToHarkonnen1 { get { return (byte)nudH1.Value; } set { nudH1.Value = value; } }
    public byte RegionToHarkonnen2 { get { return (byte)nudH2.Value; } set { nudH2.Value = value; } }
    public byte RegionToHarkonnen3 { get { return (byte)nudH3.Value; } set { nudH3.Value = value; } }
    public byte RegionToOrdos1 { get { return (byte)nudO1.Value; } set { nudO1.Value = value; } }
    public byte RegionToOrdos2 { get { return (byte)nudO2.Value; } set { nudO2.Value = value; } }
    public byte RegionToOrdos3 { get { return (byte)nudO3.Value; } set { nudO3.Value = value; } }

    public float ScoreMultiplier { get { return (float)nudScore.Value; } set { nudScore.Value = ((decimal)value).Clamp(nudScore.Minimum, nudScore.Maximum); } }
    public string SFX1 { get { return tbSFX1.Text; } set { tbSFX1.Text = value; } }
    public string SFX2 { get { return tbSFX2.Text; } set { tbSFX2.Text = value; } }
    public string SFX3 { get { return tbSFX3.Text; } set { tbSFX3.Text = value; } }
    public string Theme { get { return tbTheme.Text; } set { tbTheme.Text = value; } }
    public int RegionAnim_House1 { get { return cbHouse1.SelectedIndex; } set { cbHouse1.SelectedIndex = value.Clamp(0, cbHouse1.Items.Count); } }
    public int RegionAnim_House2 { get { return cbHouse2.SelectedIndex; } set { cbHouse2.SelectedIndex = value.Clamp(0, cbHouse2.Items.Count); } }
    public int RegionAnim_House3 { get { return cbHouse3.SelectedIndex; } set { cbHouse3.SelectedIndex = value.Clamp(0, cbHouse3.Items.Count); } }
    public int EnemyHouse { get { return cbEnemyHouse.SelectedIndex; } set { cbEnemyHouse.SelectedIndex = value.Clamp(0, cbEnemyHouse.Items.Count); } }

    public UpdateDelegate<byte[]> RegionToAtreidesChanged;
    public UpdateDelegate<byte[]> RegionToHarkonnenChanged;
    public UpdateDelegate<byte[]> RegionToOrdosChanged;
    public UpdateDelegate<float> ScoreMultiplierChanged;
    public UpdateDelegate<string> SFX1Changed;
    public UpdateDelegate<string> SFX2Changed;
    public UpdateDelegate<string> SFX3Changed;
    public UpdateDelegate<House> RegionAnim_House1Changed;
    public UpdateDelegate<House> RegionAnim_House2Changed;
    public UpdateDelegate<House> RegionAnim_House3Changed;
    public UpdateDelegate<string> ThemeChanged;
    public UpdateDelegate<House> EnemyHouseChanged;

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Font f = new Font("Microsoft Sans Serif", 12.25F))
      {
        e.Graphics.DrawString("Common", f, Brushes.Black, new Point(211, 10));
      }

      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Far;

      e.Graphics.DrawString("Regions to Atreides", DefaultFont, Brushes.Black, new Point(205, 45), sf);
      e.Graphics.DrawString("Regions to Harkonnen", DefaultFont, Brushes.Black, new Point(205, 71), sf);
      e.Graphics.DrawString("Regions to Ordos", DefaultFont, Brushes.Black, new Point(205, 97), sf);
      e.Graphics.DrawString("Score Multiplier (Base = 200)", DefaultFont, Brushes.Black, new Point(205, 123), sf);
      e.Graphics.DrawString("Animation Order", DefaultFont, Brushes.Black, new Point(205, 150), sf);
      e.Graphics.DrawString("First", DefaultFont, Brushes.Black, new Point(205, 177), sf);
      e.Graphics.DrawString("Second", DefaultFont, Brushes.Black, new Point(205, 205), sf);
      e.Graphics.DrawString("Third", DefaultFont, Brushes.Black, new Point(205, 231), sf);
      e.Graphics.DrawString("Mission Theme (max 8 char.)", DefaultFont, Brushes.Black, new Point(205, 258), sf);
      e.Graphics.DrawString("Main Enemy House", DefaultFont, Brushes.Black, new Point(205, 284), sf);

      e.Graphics.DrawString("Map Region Update*", DefaultFont, Brushes.Black, new Point(211, 158));
      e.Graphics.DrawString("SFX (max 59 char.)", DefaultFont, Brushes.Black, new Point(367, 158));

      string sdesc = "* Map regions are pre-rendered from the first campaign scenario, "
                 + "up to and not including the mission right before the current mission. "
                 + "Then the regions from the previous mission are animated by the animation order.";
      e.Graphics.DrawString(sdesc, DefaultFont, Brushes.Black, new Rectangle(371, 43, 222, 98));
    }

    private void nudA_ValueChanged(object sender, EventArgs e)
    {
      RegionToAtreidesChanged?.Invoke(new byte[] { (byte)nudA1.Value, (byte)nudA2.Value, (byte)nudA3.Value });
    }

    private void nudH_ValueChanged(object sender, EventArgs e)
    {
      RegionToHarkonnenChanged?.Invoke(new byte[] { (byte)nudH1.Value, (byte)nudH2.Value, (byte)nudH3.Value });
    }

    private void nudO_ValueChanged(object sender, EventArgs e)
    {
      RegionToOrdosChanged?.Invoke(new byte[] { (byte)nudO1.Value, (byte)nudO2.Value, (byte)nudO3.Value });
    }

    private void nudScore_ValueChanged(object sender, EventArgs e)
    {
      ScoreMultiplierChanged?.Invoke((float)nudScore.Value);
    }

    private void tbSFX1_TextChanged(object sender, EventArgs e)
    {
      SFX1Changed?.Invoke(tbSFX1.Text);
    }

    private void tbSFX2_TextChanged(object sender, EventArgs e)
    {
      SFX2Changed?.Invoke(tbSFX2.Text);
    }

    private void tbSFX3_TextChanged(object sender, EventArgs e)
    {
      SFX3Changed?.Invoke(tbSFX3.Text);
    }

    private void tbTheme_TextChanged(object sender, EventArgs e)
    {
      ThemeChanged?.Invoke(tbTheme.Text);
    }

    private void cbHouse1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse1.SelectedIndex.Max(0);
      RegionAnim_House1Changed?.Invoke((House)index);
    }

    private void cbHouse2_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse2.SelectedIndex.Max(0);
      RegionAnim_House2Changed?.Invoke((House)index);
    }

    private void cbHouse3_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbHouse3.SelectedIndex.Max(0);
      RegionAnim_House3Changed?.Invoke((House)index);
    }

    private void cbEnemyHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = cbEnemyHouse.SelectedIndex.Max(0);
      EnemyHouseChanged?.Invoke((House)index);
    }
  }
}
