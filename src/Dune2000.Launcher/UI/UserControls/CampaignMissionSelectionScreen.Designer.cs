namespace Dune2000.Launcher.UI.UserControls
{
  partial class CampaignMissionSelectionScreen
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
      DisposeInner();
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.spBG = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spKeyHelp = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTerritories = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spRefresh = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBack = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spPrevPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.DUNEMAP;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.DUNEMAP;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spTerritories);
      this.spBG.Controls.Add(this.spRefresh);
      this.spBG.Controls.Add(this.spBack);
      this.spBG.Controls.Add(this.spPrevPage);
      this.spBG.Controls.Add(this.spNextPage);
      this.spBG.Controls.Add(this.spTitle);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spBG";
      this.spBG.Size = new System.Drawing.Size(960, 600);
      this.spBG.TabIndex = 1;
      this.spBG.TextColor = System.Drawing.Color.Empty;
      // 
      // spKeyHelp
      // 
      this.spKeyHelp.Alignment = System.Drawing.StringAlignment.Center;
      this.spKeyHelp.BackColor = System.Drawing.Color.Transparent;
      this.spKeyHelp.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.OPS_DN;
      this.spKeyHelp.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.OPS_DIS;
      this.spKeyHelp.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.OPS_UP;
      this.spKeyHelp.BaseImage = global::Dune2000.Launcher.Properties.Resources.OPS_UP;
      this.spKeyHelp.BorderThickness = 0F;
      this.spKeyHelp.Location = new System.Drawing.Point(62, 18);
      this.spKeyHelp.Name = "spKeyHelp";
      this.spKeyHelp.Size = new System.Drawing.Size(32, 32);
      this.spKeyHelp.TabIndex = 27;
      this.spKeyHelp.Click += new System.EventHandler(this.SpKeyHelp_Click);
      // 
      // spTerritories
      // 
      this.spTerritories.Alignment = System.Drawing.StringAlignment.Center;
      this.spTerritories.BackColor = System.Drawing.Color.Transparent;
      this.spTerritories.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spTerritories.Font = new System.Drawing.Font("Agency FB", 16F);
      this.spTerritories.Location = new System.Drawing.Point(4, 113);
      this.spTerritories.LockWhenFading = true;
      this.spTerritories.Name = "spTerritories";
      this.spTerritories.Size = new System.Drawing.Size(954, 378);
      this.spTerritories.TabIndex = 26;
      this.spTerritories.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spRefresh
      // 
      this.spRefresh.Alignment = System.Drawing.StringAlignment.Center;
      this.spRefresh.BackColor = System.Drawing.Color.Transparent;
      this.spRefresh.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.REFR_DN;
      this.spRefresh.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.REFR_DIS;
      this.spRefresh.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.REFR_UP;
      this.spRefresh.BaseImage = global::Dune2000.Launcher.Properties.Resources.REFR_UP;
      this.spRefresh.BorderThickness = 0F;
      this.spRefresh.Location = new System.Drawing.Point(100, 18);
      this.spRefresh.Name = "spRefresh";
      this.spRefresh.Size = new System.Drawing.Size(32, 32);
      this.spRefresh.TabIndex = 25;
      this.spRefresh.Click += new System.EventHandler(this.SpRefresh_Click);
      // 
      // spBack
      // 
      this.spBack.Alignment = System.Drawing.StringAlignment.Center;
      this.spBack.BackColor = System.Drawing.Color.Transparent;
      this.spBack.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.LEAV_DN;
      this.spBack.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.LEAV_DIS;
      this.spBack.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.LEAV_UP;
      this.spBack.BaseImage = global::Dune2000.Launcher.Properties.Resources.LEAV_UP;
      this.spBack.BorderThickness = 0F;
      this.spBack.Location = new System.Drawing.Point(24, 18);
      this.spBack.Name = "spBack";
      this.spBack.Size = new System.Drawing.Size(32, 32);
      this.spBack.TabIndex = 24;
      this.spBack.Click += new System.EventHandler(this.SpBack_Click);
      // 
      // spPrevPage
      // 
      this.spPrevPage.Alignment = System.Drawing.StringAlignment.Center;
      this.spPrevPage.BackColor = System.Drawing.Color.Transparent;
      this.spPrevPage.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.ALT_DN;
      this.spPrevPage.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.ALT_DS;
      this.spPrevPage.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.ALT_UP;
      this.spPrevPage.BaseImage = global::Dune2000.Launcher.Properties.Resources.ALT_UP;
      this.spPrevPage.BorderThickness = 0F;
      this.spPrevPage.Enabled = false;
      this.spPrevPage.Location = new System.Drawing.Point(33, 64);
      this.spPrevPage.Name = "spPrevPage";
      this.spPrevPage.Size = new System.Drawing.Size(32, 32);
      this.spPrevPage.TabIndex = 23;
      this.spPrevPage.Click += new System.EventHandler(this.SpPrevPage_Click);
      // 
      // spNextPage
      // 
      this.spNextPage.Alignment = System.Drawing.StringAlignment.Center;
      this.spNextPage.BackColor = System.Drawing.Color.Transparent;
      this.spNextPage.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.ART_DN;
      this.spNextPage.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.ART_DS;
      this.spNextPage.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.ART_UP;
      this.spNextPage.BaseImage = global::Dune2000.Launcher.Properties.Resources.ART_UP;
      this.spNextPage.BorderThickness = 0F;
      this.spNextPage.Enabled = false;
      this.spNextPage.Location = new System.Drawing.Point(899, 64);
      this.spNextPage.Name = "spNextPage";
      this.spNextPage.Size = new System.Drawing.Size(32, 32);
      this.spNextPage.TabIndex = 22;
      this.spNextPage.Click += new System.EventHandler(this.SpNextPage_Click);
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 16F);
      this.spTitle.Location = new System.Drawing.Point(71, 64);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(822, 27);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Select Your Mission";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextShadowColor = System.Drawing.Color.Black;
      // 
      // CampaignMissionSelectionScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "CampaignMissionSelectionScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spPrevPage;
    private Objects.SpriteBox spNextPage;
    private Objects.SpriteBox spBack;
    private Objects.SpriteBox spRefresh;
    private Objects.SpriteBox spTerritories;
    private Objects.SpriteBox spKeyHelp;
  }
}
