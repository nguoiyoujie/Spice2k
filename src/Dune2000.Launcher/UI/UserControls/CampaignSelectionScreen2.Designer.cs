namespace Dune2000.Launcher.UI.UserControls
{
  partial class CampaignSelectionScreen2
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
      this.spConquest = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBack = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spOrdos = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spHarkonnen = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spCustom = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spAtreides = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.CAMPAIGN_SELECT;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.CAMPAIGN_SELECT;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spConquest);
      this.spBG.Controls.Add(this.spBack);
      this.spBG.Controls.Add(this.spOrdos);
      this.spBG.Controls.Add(this.spHarkonnen);
      this.spBG.Controls.Add(this.spCustom);
      this.spBG.Controls.Add(this.spAtreides);
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
      this.spKeyHelp.Location = new System.Drawing.Point(54, 5);
      this.spKeyHelp.Name = "spKeyHelp";
      this.spKeyHelp.Size = new System.Drawing.Size(32, 32);
      this.spKeyHelp.TabIndex = 28;
      this.spKeyHelp.Click += new System.EventHandler(this.SpKeyHelp_Click);
      // 
      // spConquest
      // 
      this.spConquest.Alignment = System.Drawing.StringAlignment.Center;
      this.spConquest.BackColor = System.Drawing.Color.Transparent;
      this.spConquest.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.DUNEMAP2;
      this.spConquest.BaseImage = global::Dune2000.Launcher.Properties.Resources.DUNEMAP2;
      this.spConquest.BorderColor = System.Drawing.Color.SlateBlue;
      this.spConquest.BorderDisabledColor = System.Drawing.Color.Gray;
      this.spConquest.BorderDisabledThickness = 5F;
      this.spConquest.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.spConquest.BorderHoverThickness = 5F;
      this.spConquest.BorderThickness = 5F;
      this.spConquest.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spConquest.Location = new System.Drawing.Point(16, 378);
      this.spConquest.Name = "spConquest";
      this.spConquest.Size = new System.Drawing.Size(280, 175);
      this.spConquest.TabIndex = 17;
      this.spConquest.Text = "Conquest Mode";
      this.spConquest.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spConquest.TextColor = System.Drawing.Color.DarkSlateBlue;
      this.spConquest.TextDisabledColor = System.Drawing.Color.Gray;
      this.spConquest.TextShadowColor = System.Drawing.Color.Black;
      this.spConquest.TextShadowOffset = new System.Drawing.Point(-2, 2);
      this.spConquest.Click += new System.EventHandler(this.SpConquest_Click);
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
      this.spBack.Location = new System.Drawing.Point(16, 5);
      this.spBack.Name = "spBack";
      this.spBack.Size = new System.Drawing.Size(32, 32);
      this.spBack.TabIndex = 16;
      this.spBack.Click += new System.EventHandler(this.SpBack_Click);
      // 
      // spOrdos
      // 
      this.spOrdos.Alignment = System.Drawing.StringAlignment.Center;
      this.spOrdos.BackColor = System.Drawing.Color.Transparent;
      this.spOrdos.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DN;
      this.spOrdos.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DIS;
      this.spOrdos.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spOrdos.BaseImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spOrdos.BorderColor = System.Drawing.Color.Green;
      this.spOrdos.BorderDisabledColor = System.Drawing.Color.Gray;
      this.spOrdos.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.spOrdos.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold);
      this.spOrdos.Location = new System.Drawing.Point(424, 325);
      this.spOrdos.Name = "spOrdos";
      this.spOrdos.Size = new System.Drawing.Size(120, 40);
      this.spOrdos.TabIndex = 14;
      this.spOrdos.Text = "Ordos";
      this.spOrdos.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spOrdos.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.spOrdos.TextDisabledColor = System.Drawing.Color.Gray;
      this.spOrdos.TextShadowColor = System.Drawing.Color.Black;
      this.spOrdos.TextShadowOffset = new System.Drawing.Point(-2, 2);
      this.spOrdos.Click += new System.EventHandler(this.SpOrdos_Click);
      // 
      // spHarkonnen
      // 
      this.spHarkonnen.Alignment = System.Drawing.StringAlignment.Center;
      this.spHarkonnen.BackColor = System.Drawing.Color.Transparent;
      this.spHarkonnen.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DN;
      this.spHarkonnen.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DIS;
      this.spHarkonnen.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spHarkonnen.BaseImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spHarkonnen.BorderColor = System.Drawing.Color.Maroon;
      this.spHarkonnen.BorderDisabledColor = System.Drawing.Color.Gray;
      this.spHarkonnen.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.spHarkonnen.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold);
      this.spHarkonnen.Location = new System.Drawing.Point(710, 325);
      this.spHarkonnen.Name = "spHarkonnen";
      this.spHarkonnen.Size = new System.Drawing.Size(120, 40);
      this.spHarkonnen.TabIndex = 13;
      this.spHarkonnen.Text = "Harkonnen";
      this.spHarkonnen.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spHarkonnen.TextColor = System.Drawing.Color.Red;
      this.spHarkonnen.TextDisabledColor = System.Drawing.Color.Gray;
      this.spHarkonnen.TextShadowColor = System.Drawing.Color.Black;
      this.spHarkonnen.TextShadowOffset = new System.Drawing.Point(-2, 2);
      this.spHarkonnen.Click += new System.EventHandler(this.SpHarkonnen_Click);
      // 
      // spCustom
      // 
      this.spCustom.Alignment = System.Drawing.StringAlignment.Center;
      this.spCustom.BackColor = System.Drawing.Color.Transparent;
      this.spCustom.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.SCOREUI;
      this.spCustom.BaseImage = global::Dune2000.Launcher.Properties.Resources.SCOREUI;
      this.spCustom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spCustom.BorderDisabledColor = System.Drawing.Color.Gray;
      this.spCustom.BorderDisabledThickness = 5F;
      this.spCustom.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
      this.spCustom.BorderHoverThickness = 5F;
      this.spCustom.BorderThickness = 5F;
      this.spCustom.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spCustom.Location = new System.Drawing.Point(668, 378);
      this.spCustom.Name = "spCustom";
      this.spCustom.Size = new System.Drawing.Size(280, 175);
      this.spCustom.TabIndex = 12;
      this.spCustom.Text = "Custom Scenarios";
      this.spCustom.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spCustom.TextColor = System.Drawing.Color.Moccasin;
      this.spCustom.TextDisabledColor = System.Drawing.Color.Gray;
      this.spCustom.TextShadowColor = System.Drawing.Color.Black;
      this.spCustom.TextShadowOffset = new System.Drawing.Point(-2, 2);
      this.spCustom.Click += new System.EventHandler(this.SpCustom_Click);
      // 
      // spAtreides
      // 
      this.spAtreides.Alignment = System.Drawing.StringAlignment.Center;
      this.spAtreides.BackColor = System.Drawing.Color.Transparent;
      this.spAtreides.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DN;
      this.spAtreides.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.WBUT_DIS;
      this.spAtreides.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spAtreides.BaseImage = global::Dune2000.Launcher.Properties.Resources.WBUT_UP;
      this.spAtreides.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.spAtreides.BorderDisabledColor = System.Drawing.Color.Gray;
      this.spAtreides.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.spAtreides.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold);
      this.spAtreides.Location = new System.Drawing.Point(134, 325);
      this.spAtreides.Name = "spAtreides";
      this.spAtreides.Size = new System.Drawing.Size(120, 40);
      this.spAtreides.TabIndex = 11;
      this.spAtreides.Text = "Atreides";
      this.spAtreides.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spAtreides.TextColor = System.Drawing.Color.LightSkyBlue;
      this.spAtreides.TextDisabledColor = System.Drawing.Color.Gray;
      this.spAtreides.TextShadowColor = System.Drawing.Color.Black;
      this.spAtreides.TextShadowOffset = new System.Drawing.Point(-2, 2);
      this.spAtreides.Click += new System.EventHandler(this.SpAtreides_Click);
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 16F);
      this.spTitle.Location = new System.Drawing.Point(314, 47);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(342, 27);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Select your Campaign";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextShadowColor = System.Drawing.Color.Black;
      // 
      // CampaignSelectionScreen2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "CampaignSelectionScreen2";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spOrdos;
    private Objects.SpriteBox spHarkonnen;
    private Objects.SpriteBox spCustom;
    private Objects.SpriteBox spAtreides;
    private Objects.SpriteBox spBack;
    private Objects.SpriteBox spConquest;
    private Objects.SpriteBox spKeyHelp;
  }
}
