using Dune2000.Enums;
using Primrose.Primitives.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Uib.Campaign
{
  public partial class CampaignRegionPanel : Panel
  {
    public CampaignRegionPanel()
    {
      InitializeComponent();

      cbDirection1.Items.AddRange(Enum.GetNames(typeof(Direction)));
      cbDirection2.Items.AddRange(Enum.GetNames(typeof(Direction)));
    }

    public byte RegionID1 { get { return (byte)nudR1.Value; } set { nudR1.Value = value; } }
    public byte RegionID2 { get { return (byte)nudR2.Value; } set { nudR2.Value = value; } }
    public string MissionFile1 { get { return tbMapFile1.Text; } set { tbMapFile1.Text = value; } }
    public string MissionFile2 { get { return tbMapFile2.Text; } set { tbMapFile2.Text = value; } }
    public int Direction1 { get { return cbDirection1.SelectedIndex; } set { cbDirection1.SelectedIndex = value.Clamp(0, cbDirection1.Items.Count); } }
    public int Direction2 { get { return cbDirection2.SelectedIndex; } set { cbDirection2.SelectedIndex = value.Clamp(0, cbDirection2.Items.Count); } }
    public int Icon1X { get { return (int)nudIcon1X.Value; } set { nudIcon1X.Value = (int)((decimal)value).Clamp(nudIcon1X.Minimum, nudIcon1X.Maximum); } }
    public int Icon1Y { get { return (int)nudIcon1Y.Value; } set { nudIcon1Y.Value = (int)((decimal)value).Clamp(nudIcon1Y.Minimum, nudIcon1Y.Maximum); } }
    public int Icon2X { get { return (int)nudIcon2X.Value; } set { nudIcon2X.Value = (int)((decimal)value).Clamp(nudIcon2X.Minimum, nudIcon2X.Maximum); } }
    public int Icon2Y { get { return (int)nudIcon2Y.Value; } set { nudIcon2Y.Value = (int)((decimal)value).Clamp(nudIcon2Y.Minimum, nudIcon2Y.Maximum); } }

    public UpdateDelegate<byte> RegionID1Changed;
    public UpdateDelegate<byte> RegionID2Changed;
    public UpdateDelegate<string> MissionFile1Changed;
    public UpdateDelegate<string> MissionFile2Changed;
    public UpdateDelegate<int> Direction1Changed;
    public UpdateDelegate<int> Direction2Changed;
    public UpdateDelegate<int> Icon1XChanged;
    public UpdateDelegate<int> Icon1YChanged;
    public UpdateDelegate<int> Icon2XChanged;
    public UpdateDelegate<int> Icon2YChanged;

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Font f = new Font("Microsoft Sans Serif", 12.25F))
      {
        e.Graphics.DrawString("Region 1", f, Brushes.Black, new Point(210, 9));
        e.Graphics.DrawString("Region 2", f, Brushes.Black, new Point(370, 9));
      }

      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Far;

      e.Graphics.DrawString("Region ID", DefaultFont, Brushes.Black, new Point(205, 43), sf);
      e.Graphics.DrawString("Mission File (max 4 char.)", DefaultFont, Brushes.Black, new Point(205, 91), sf);
      e.Graphics.DrawString("Unused Direction", DefaultFont, Brushes.Black, new Point(205, 117), sf);
      e.Graphics.DrawString("Icon Position", DefaultFont, Brushes.Black, new Point(205, 143), sf);
      e.Graphics.DrawString("Both regions are awarded to the player house when the mission is complete*", DefaultFont, Brushes.Black, new Point(212, 64));
    }

    public void UpdateR1()
    {
      tbMapFile1.Enabled = nudR1.Value != 0;
      cbDirection1.Enabled = nudR1.Value != 0;
      nudIcon1X.Enabled = nudR1.Value != 0;
      nudIcon1Y.Enabled = nudR1.Value != 0;
    }

    public void UpdateR2()
    {
      tbMapFile2.Enabled = nudR2.Value != 0;
      cbDirection2.Enabled = nudR2.Value != 0;
      nudIcon2X.Enabled = nudR2.Value != 0;
      nudIcon2Y.Enabled = nudR2.Value != 0;
    }

    private void nudR1_ValueChanged(object sender, EventArgs e)
    {
      RegionID1Changed?.Invoke((byte)nudR1.Value);
      UpdateR1();
    }

    private void nudR2_ValueChanged(object sender, EventArgs e)
    {
      RegionID2Changed?.Invoke((byte)nudR2.Value);
      UpdateR2();
    }

    private void tbMapFile1_TextChanged(object sender, EventArgs e)
    {
      MissionFile1Changed?.Invoke(tbMapFile1.Text);
    }

    private void tbMapFile2_TextChanged(object sender, EventArgs e)
    {
      MissionFile2Changed?.Invoke(tbMapFile2.Text);
    }

    private void cbDirection1_SelectedIndexChanged(object sender, EventArgs e)
    {
      Direction1Changed?.Invoke(cbDirection1.SelectedIndex);
    }

    private void cbDirection2_SelectedIndexChanged(object sender, EventArgs e)
    {
      Direction2Changed?.Invoke(cbDirection2.SelectedIndex);
    }

    private void nudIcon1X_ValueChanged(object sender, EventArgs e)
    {
      Icon1XChanged?.Invoke((int)nudIcon1X.Value);
    }

    private void nudIcon1Y_ValueChanged(object sender, EventArgs e)
    {
      Icon1YChanged?.Invoke((int)nudIcon1Y.Value);
    }

    private void nudIcon2X_ValueChanged(object sender, EventArgs e)
    {
      Icon2XChanged?.Invoke((int)nudIcon2X.Value);
    }

    private void nudIcon2Y_ValueChanged(object sender, EventArgs e)
    {
      Icon2YChanged?.Invoke((int)nudIcon2Y.Value);
    }
  }
}
