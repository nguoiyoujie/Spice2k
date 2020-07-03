namespace Dune2000.Launcher.UI.UserControls
{
  partial class MissionSelectionScreen
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
      this.spRefresh = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBack = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spPrevPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spDescription = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission10 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission9 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission8 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission7 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission6 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission5 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission4 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission3 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission2 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spStart = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spMission1 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spSelected = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.SCOREUI;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.SCOREUI;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spRefresh);
      this.spBG.Controls.Add(this.spBack);
      this.spBG.Controls.Add(this.spPrevPage);
      this.spBG.Controls.Add(this.spNextPage);
      this.spBG.Controls.Add(this.spDescription);
      this.spBG.Controls.Add(this.spMission10);
      this.spBG.Controls.Add(this.spMission9);
      this.spBG.Controls.Add(this.spMission8);
      this.spBG.Controls.Add(this.spMission7);
      this.spBG.Controls.Add(this.spMission6);
      this.spBG.Controls.Add(this.spMission5);
      this.spBG.Controls.Add(this.spMission4);
      this.spBG.Controls.Add(this.spMission3);
      this.spBG.Controls.Add(this.spMission2);
      this.spBG.Controls.Add(this.spStart);
      this.spBG.Controls.Add(this.spMission1);
      this.spBG.Controls.Add(this.spSelected);
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
      this.spKeyHelp.TabIndex = 28;
      this.spKeyHelp.Click += new System.EventHandler(this.SpKeyHelp_Click);
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
      this.spRefresh.Location = new System.Drawing.Point(36, 86);
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
      this.spPrevPage.Location = new System.Drawing.Point(416, 486);
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
      this.spNextPage.Location = new System.Drawing.Point(454, 486);
      this.spNextPage.Name = "spNextPage";
      this.spNextPage.Size = new System.Drawing.Size(32, 32);
      this.spNextPage.TabIndex = 22;
      this.spNextPage.Click += new System.EventHandler(this.SpNextPage_Click);
      // 
      // spDescription
      // 
      this.spDescription.BackColor = System.Drawing.Color.Transparent;
      this.spDescription.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.SHADE_50;
      this.spDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.spDescription.BaseImage = global::Dune2000.Launcher.Properties.Resources.SHADE_50;
      this.spDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spDescription.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spDescription.Location = new System.Drawing.Point(492, 124);
      this.spDescription.Name = "spDescription";
      this.spDescription.Size = new System.Drawing.Size(434, 394);
      this.spDescription.TabIndex = 21;
      this.spDescription.Text = "Description Example";
      this.spDescription.TextColor = System.Drawing.Color.Orange;
      this.spDescription.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spMission10
      // 
      this.spMission10.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission10.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission10.BackColor = System.Drawing.Color.Transparent;
      this.spMission10.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission10.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission10.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission10.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission10.Location = new System.Drawing.Point(36, 448);
      this.spMission10.Name = "spMission10";
      this.spMission10.Size = new System.Drawing.Size(450, 30);
      this.spMission10.TabIndex = 20;
      this.spMission10.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission10.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission10.TextColor = System.Drawing.Color.Orange;
      this.spMission10.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission10.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission10.TextShadowColor = System.Drawing.Color.Black;
      this.spMission10.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission9
      // 
      this.spMission9.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission9.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission9.BackColor = System.Drawing.Color.Transparent;
      this.spMission9.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission9.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission9.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission9.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission9.Location = new System.Drawing.Point(36, 412);
      this.spMission9.Name = "spMission9";
      this.spMission9.Size = new System.Drawing.Size(450, 30);
      this.spMission9.TabIndex = 19;
      this.spMission9.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission9.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission9.TextColor = System.Drawing.Color.Orange;
      this.spMission9.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission9.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission9.TextShadowColor = System.Drawing.Color.Black;
      this.spMission9.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission8
      // 
      this.spMission8.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission8.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission8.BackColor = System.Drawing.Color.Transparent;
      this.spMission8.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission8.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission8.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission8.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission8.Location = new System.Drawing.Point(36, 376);
      this.spMission8.Name = "spMission8";
      this.spMission8.Size = new System.Drawing.Size(450, 30);
      this.spMission8.TabIndex = 18;
      this.spMission8.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission8.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission8.TextColor = System.Drawing.Color.Orange;
      this.spMission8.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission8.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission8.TextShadowColor = System.Drawing.Color.Black;
      this.spMission8.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission7
      // 
      this.spMission7.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission7.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission7.BackColor = System.Drawing.Color.Transparent;
      this.spMission7.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission7.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission7.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission7.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission7.Location = new System.Drawing.Point(36, 340);
      this.spMission7.Name = "spMission7";
      this.spMission7.Size = new System.Drawing.Size(450, 30);
      this.spMission7.TabIndex = 17;
      this.spMission7.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission7.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission7.TextColor = System.Drawing.Color.Orange;
      this.spMission7.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission7.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission7.TextShadowColor = System.Drawing.Color.Black;
      this.spMission7.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission6
      // 
      this.spMission6.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission6.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission6.BackColor = System.Drawing.Color.Transparent;
      this.spMission6.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission6.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission6.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission6.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission6.Location = new System.Drawing.Point(36, 304);
      this.spMission6.Name = "spMission6";
      this.spMission6.Size = new System.Drawing.Size(450, 30);
      this.spMission6.TabIndex = 16;
      this.spMission6.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission6.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission6.TextColor = System.Drawing.Color.Orange;
      this.spMission6.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission6.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission6.TextShadowColor = System.Drawing.Color.Black;
      this.spMission6.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission5
      // 
      this.spMission5.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission5.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission5.BackColor = System.Drawing.Color.Transparent;
      this.spMission5.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission5.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission5.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission5.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission5.Location = new System.Drawing.Point(36, 268);
      this.spMission5.Name = "spMission5";
      this.spMission5.Size = new System.Drawing.Size(450, 30);
      this.spMission5.TabIndex = 15;
      this.spMission5.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission5.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission5.TextColor = System.Drawing.Color.Orange;
      this.spMission5.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission5.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission5.TextShadowColor = System.Drawing.Color.Black;
      this.spMission5.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission4
      // 
      this.spMission4.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission4.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission4.BackColor = System.Drawing.Color.Transparent;
      this.spMission4.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission4.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission4.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission4.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission4.Location = new System.Drawing.Point(36, 232);
      this.spMission4.Name = "spMission4";
      this.spMission4.Size = new System.Drawing.Size(450, 30);
      this.spMission4.TabIndex = 14;
      this.spMission4.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission4.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission4.TextColor = System.Drawing.Color.Orange;
      this.spMission4.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission4.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission4.TextShadowColor = System.Drawing.Color.Black;
      this.spMission4.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission3
      // 
      this.spMission3.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission3.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission3.BackColor = System.Drawing.Color.Transparent;
      this.spMission3.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission3.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission3.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission3.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission3.Location = new System.Drawing.Point(36, 196);
      this.spMission3.Name = "spMission3";
      this.spMission3.Size = new System.Drawing.Size(450, 30);
      this.spMission3.TabIndex = 13;
      this.spMission3.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission3.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission3.TextColor = System.Drawing.Color.Orange;
      this.spMission3.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission3.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission3.TextShadowColor = System.Drawing.Color.Black;
      this.spMission3.Click += new System.EventHandler(this.MissionClick);
      // 
      // spMission2
      // 
      this.spMission2.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission2.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission2.BackColor = System.Drawing.Color.Transparent;
      this.spMission2.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission2.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission2.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission2.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission2.Location = new System.Drawing.Point(36, 160);
      this.spMission2.Name = "spMission2";
      this.spMission2.Size = new System.Drawing.Size(450, 30);
      this.spMission2.TabIndex = 12;
      this.spMission2.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission2.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission2.TextColor = System.Drawing.Color.Orange;
      this.spMission2.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission2.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission2.TextShadowColor = System.Drawing.Color.Black;
      this.spMission2.Click += new System.EventHandler(this.MissionClick);
      // 
      // spStart
      // 
      this.spStart.Alignment = System.Drawing.StringAlignment.Center;
      this.spStart.BackColor = System.Drawing.Color.Transparent;
      this.spStart.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT8_DN;
      this.spStart.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.BUTN8_UP;
      this.spStart.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spStart.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spStart.BorderThickness = 0F;
      this.spStart.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spStart.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spStart.Location = new System.Drawing.Point(798, 550);
      this.spStart.Name = "spStart";
      this.spStart.Size = new System.Drawing.Size(120, 30);
      this.spStart.TabIndex = 11;
      this.spStart.Text = "Select Mission";
      this.spStart.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spStart.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spStart.TextColor = System.Drawing.Color.Orange;
      this.spStart.TextDisabledColor = System.Drawing.Color.Gray;
      this.spStart.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spStart.TextShadowColor = System.Drawing.Color.Black;
      this.spStart.Click += new System.EventHandler(this.SpStart_Click);
      // 
      // spMission1
      // 
      this.spMission1.Alignment = System.Drawing.StringAlignment.Center;
      this.spMission1.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spMission1.BackColor = System.Drawing.Color.Transparent;
      this.spMission1.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT9_DN;
      this.spMission1.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission1.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT9_UP;
      this.spMission1.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spMission1.Location = new System.Drawing.Point(36, 124);
      this.spMission1.Name = "spMission1";
      this.spMission1.Size = new System.Drawing.Size(450, 30);
      this.spMission1.TabIndex = 10;
      this.spMission1.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission1.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spMission1.TextColor = System.Drawing.Color.Orange;
      this.spMission1.TextDisabledColor = System.Drawing.Color.Gray;
      this.spMission1.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spMission1.TextShadowColor = System.Drawing.Color.Black;
      this.spMission1.Click += new System.EventHandler(this.MissionClick);
      // 
      // spSelected
      // 
      this.spSelected.Alignment = System.Drawing.StringAlignment.Center;
      this.spSelected.BackColor = System.Drawing.Color.Transparent;
      this.spSelected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spSelected.Font = new System.Drawing.Font("Agency FB", 18F);
      this.spSelected.Location = new System.Drawing.Point(36, 524);
      this.spSelected.Name = "spSelected";
      this.spSelected.Size = new System.Drawing.Size(710, 32);
      this.spSelected.TabIndex = 9;
      this.spSelected.TextColor = System.Drawing.Color.Orange;
      this.spSelected.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 16F);
      this.spTitle.Location = new System.Drawing.Point(314, 64);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(342, 27);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Select Your Mission";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextShadowColor = System.Drawing.Color.Black;
      // 
      // MissionSelectionScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "MissionSelectionScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spSelected;
    private Objects.SpriteBox spMission1;
    private Objects.SpriteBox spStart;
    private Objects.SpriteBox spMission10;
    private Objects.SpriteBox spMission9;
    private Objects.SpriteBox spMission8;
    private Objects.SpriteBox spMission7;
    private Objects.SpriteBox spMission6;
    private Objects.SpriteBox spMission5;
    private Objects.SpriteBox spMission4;
    private Objects.SpriteBox spMission3;
    private Objects.SpriteBox spMission2;
    private Objects.SpriteBox spDescription;
    private Objects.SpriteBox spPrevPage;
    private Objects.SpriteBox spNextPage;
    private Objects.SpriteBox spBack;
    private Objects.SpriteBox spRefresh;
    private Objects.SpriteBox spKeyHelp;
  }
}
