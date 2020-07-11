using Dune2000.Extensions.FileFormats.INI;
using Dune2000.Extensions.Missions;
using Dune2000.Launcher.UI.Forms;
using System;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class CampaignSelectionScreen2 : PreviewKeyUserControl, ILinkedControl
  {
    public UpdateDelegate Clicked_AtreidesCampaign;
    public UpdateDelegate Clicked_HarkonnenCampaign;
    public UpdateDelegate Clicked_OrdosCampaign;
    public UpdateDelegate Clicked_ConquestCampaign;
    public UpdateDelegate Clicked_CustomCampaign;
    public UpdateDelegate Clicked_Back;

    public CampaignSelectionScreen2()
    {
      InitializeComponent();
      Dock = DockStyle.Fill;

      SetKeyAction(Keys.Escape, () => { if (spBack.Enabled) { SpBack_Click(null, null); } }, "Return to previous menu");
      SetKeyAction(Keys.D1, () => { if (spAtreides.Enabled) { SpAtreides_Click(null, null); } }, "Atreides Campaign");
      SetKeyAction(Keys.D2, () => { if (spHarkonnen.Enabled) { SpHarkonnen_Click(null, null); } }, "Harkonnen Campaign");
      SetKeyAction(Keys.D3, () => { if (spOrdos.Enabled) { SpOrdos_Click(null, null); } }, "Ordos Campaign");
      SetKeyAction(Keys.D4, () => { if (spConquest.Enabled) { SpConquest_Click(null, null); } }, "Conquest Campaign");
      SetKeyAction(Keys.D5, () => { if (spCustom.Enabled) { SpCustom_Click(null, null); } }, "Custom Campaign");
    }

    private void SpAtreides_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_AtreidesCampaign?.Invoke(); }
    private void SpHarkonnen_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_HarkonnenCampaign?.Invoke(); }
    private void SpOrdos_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_OrdosCampaign?.Invoke(); }
    private void SpConquest_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_ConquestCampaign?.Invoke(); }
    private void SpCustom_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_CustomCampaign?.Invoke(); }
    private void SpBack_Click(object sender, EventArgs e) { AudioEngine.Click(); Clicked_Back?.Invoke(); }
    private void SpKeyHelp_Click(object sender, EventArgs e) { Clicked_KeyHelp?.Invoke(); }

    public override void Activate(Engine e, Control prevControl)
    {
      // disable Conquest Mode for now
      spConquest.Visible = false;
    }

    public override void Link(GameForm f)
    {
      base.Link(f);
      try
      {
        CampaignFile atre = new CampaignFile();
        atre.ReadFromFile(@".\data\campaigns\ATREIDES.ini");
        Clicked_AtreidesCampaign = () => SelectCampaign(f, atre);
      }
      catch (Exception ex)
      {
        f.Engine.HandleError("Error reading Atreides campaign file", ex);
        spAtreides.Enabled = false;
      }

      try
      {
        CampaignFile hark = new CampaignFile();
        hark.ReadFromFile(@".\data\campaigns\HARKONNEN.ini");
        Clicked_HarkonnenCampaign = () => SelectCampaign(f, hark);
      }
      catch (Exception ex)
      {
        f.Engine.HandleError("Error reading Harkonnen campaign file", ex);
        spHarkonnen.Enabled = false;
      }

      try
      {
        CampaignFile ordo = new CampaignFile();
        ordo.ReadFromFile(@".\data\campaigns\ORDOS.ini");
        Clicked_OrdosCampaign = () => SelectCampaign(f, ordo);
      }
      catch (Exception ex)
      {
        f.Engine.HandleError("Error reading Ordos campaign file", ex);
        spOrdos.Enabled = false;
      }

      Clicked_CustomCampaign = () => SelectCampaign(f, (s) => s.Identifier.Type == MissionType.CUSTOM_CAMPAIGN);
      Clicked_Back = () => f.Remove(this, TransitionStyle.FADE_BLACK);
    }

    public void SelectCampaign(GameForm f, Predicate<MissionSet> missionFilter)
    {
      f.Push(new MissionSelectionScreen(missionFilter), TransitionStyle.FADE_BLACK);
    }

    public void SelectCampaign(GameForm f, CampaignFile campaign)
    {
      f.Push(new CampaignMissionSelectionScreen(campaign), TransitionStyle.FADE_BLACK);
    }
  }
}
