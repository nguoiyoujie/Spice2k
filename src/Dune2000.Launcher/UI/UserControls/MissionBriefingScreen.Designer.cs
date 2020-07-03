namespace Dune2000.Launcher.UI.UserControls
{
  partial class MissionBriefingScreen
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
      //DisposeInner();
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
      this.spBack = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spDifficulty = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spHard = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNormal = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spEasy = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spPrevItem = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextItem = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBriefing = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spImage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spStart = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spPrevPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.spDifficulty.SuspendLayout();
      this.spBriefing.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.PICTBOOK;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.PICTBOOK;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spBack);
      this.spBG.Controls.Add(this.spDifficulty);
      this.spBG.Controls.Add(this.spPrevItem);
      this.spBG.Controls.Add(this.spTitle);
      this.spBG.Controls.Add(this.spNextItem);
      this.spBG.Controls.Add(this.spBriefing);
      this.spBG.Controls.Add(this.spStart);
      this.spBG.Controls.Add(this.spPrevPage);
      this.spBG.Controls.Add(this.spNextPage);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spBG";
      this.spBG.Size = new System.Drawing.Size(960, 600);
      this.spBG.TabIndex = 1;
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
      this.spKeyHelp.Location = new System.Drawing.Point(61, 20);
      this.spKeyHelp.Name = "spKeyHelp";
      this.spKeyHelp.Size = new System.Drawing.Size(32, 32);
      this.spKeyHelp.TabIndex = 28;
      this.spKeyHelp.Click += new System.EventHandler(this.SpKeyHelp_Click);
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
      this.spBack.Location = new System.Drawing.Point(23, 20);
      this.spBack.Name = "spBack";
      this.spBack.Size = new System.Drawing.Size(32, 32);
      this.spBack.TabIndex = 25;
      this.spBack.Click += new System.EventHandler(this.SpBack_Click);
      // 
      // spDifficulty
      // 
      this.spDifficulty.Alignment = System.Drawing.StringAlignment.Center;
      this.spDifficulty.BackColor = System.Drawing.Color.Transparent;
      this.spDifficulty.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.DIFFICULTY;
      this.spDifficulty.BaseImage = global::Dune2000.Launcher.Properties.Resources.DIFFICULTY;
      this.spDifficulty.BorderThickness = 0F;
      this.spDifficulty.Controls.Add(this.spHard);
      this.spDifficulty.Controls.Add(this.spNormal);
      this.spDifficulty.Controls.Add(this.spEasy);
      this.spDifficulty.Location = new System.Drawing.Point(315, 431);
      this.spDifficulty.Name = "spDifficulty";
      this.spDifficulty.Size = new System.Drawing.Size(328, 64);
      this.spDifficulty.TabIndex = 9;
      // 
      // spHard
      // 
      this.spHard.Alignment = System.Drawing.StringAlignment.Center;
      this.spHard.BackColor = System.Drawing.Color.Transparent;
      this.spHard.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.HARD_DN;
      this.spHard.BaseImage = global::Dune2000.Launcher.Properties.Resources.HARD_DN;
      this.spHard.BorderThickness = 0F;
      this.spHard.Location = new System.Drawing.Point(208, 21);
      this.spHard.Name = "spHard";
      this.spHard.Size = new System.Drawing.Size(74, 28);
      this.spHard.TabIndex = 11;
      this.spHard.Click += new System.EventHandler(this.SpHard_Click);
      // 
      // spNormal
      // 
      this.spNormal.Alignment = System.Drawing.StringAlignment.Center;
      this.spNormal.BackColor = System.Drawing.Color.Transparent;
      this.spNormal.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.NORMAL_DN;
      this.spNormal.BaseImage = global::Dune2000.Launcher.Properties.Resources.NORMAL_DN;
      this.spNormal.BorderThickness = 0F;
      this.spNormal.Location = new System.Drawing.Point(126, 21);
      this.spNormal.Name = "spNormal";
      this.spNormal.Size = new System.Drawing.Size(74, 28);
      this.spNormal.TabIndex = 11;
      this.spNormal.Click += new System.EventHandler(this.SpNormal_Click);
      // 
      // spEasy
      // 
      this.spEasy.Alignment = System.Drawing.StringAlignment.Center;
      this.spEasy.BackColor = System.Drawing.Color.Transparent;
      this.spEasy.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.EASY_DN;
      this.spEasy.BaseImage = global::Dune2000.Launcher.Properties.Resources.EASY_DN;
      this.spEasy.BorderThickness = 0F;
      this.spEasy.Location = new System.Drawing.Point(44, 21);
      this.spEasy.Name = "spEasy";
      this.spEasy.Size = new System.Drawing.Size(74, 28);
      this.spEasy.TabIndex = 10;
      this.spEasy.Click += new System.EventHandler(this.SpEasy_Click);
      // 
      // spPrevItem
      // 
      this.spPrevItem.BackColor = System.Drawing.Color.Transparent;
      this.spPrevItem.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RBACK_DN;
      this.spPrevItem.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.RBACK_DS;
      this.spPrevItem.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RBACK_UP;
      this.spPrevItem.BaseImage = global::Dune2000.Launcher.Properties.Resources.RBACK_UP;
      this.spPrevItem.BorderThickness = 0F;
      this.spPrevItem.Enabled = false;
      this.spPrevItem.Location = new System.Drawing.Point(142, 528);
      this.spPrevItem.Name = "spPrevItem";
      this.spPrevItem.Size = new System.Drawing.Size(24, 24);
      this.spPrevItem.TabIndex = 7;
      this.spPrevItem.Click += new System.EventHandler(this.SpPrevItem_Click);
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 14F);
      this.spTitle.Location = new System.Drawing.Point(285, 64);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(371, 27);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Title Example";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextDisabledColor = System.Drawing.Color.Gray;
      this.spTitle.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      // 
      // spNextItem
      // 
      this.spNextItem.Alignment = System.Drawing.StringAlignment.Center;
      this.spNextItem.BackColor = System.Drawing.Color.Transparent;
      this.spNextItem.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RMORE_DN;
      this.spNextItem.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.RMORE_DS;
      this.spNextItem.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RMORE_UP;
      this.spNextItem.BaseImage = global::Dune2000.Launcher.Properties.Resources.RMORE_UP;
      this.spNextItem.BorderThickness = 0F;
      this.spNextItem.Enabled = false;
      this.spNextItem.Location = new System.Drawing.Point(179, 528);
      this.spNextItem.Name = "spNextItem";
      this.spNextItem.Size = new System.Drawing.Size(24, 24);
      this.spNextItem.TabIndex = 6;
      this.spNextItem.TextDisabledColor = System.Drawing.Color.Gray;
      this.spNextItem.Click += new System.EventHandler(this.SpNextItem_Click);
      // 
      // spBriefing
      // 
      this.spBriefing.BackColor = System.Drawing.Color.Transparent;
      this.spBriefing.Controls.Add(this.spImage);
      this.spBriefing.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spBriefing.Location = new System.Drawing.Point(127, 97);
      this.spBriefing.Name = "spBriefing";
      this.spBriefing.Size = new System.Drawing.Size(702, 333);
      this.spBriefing.TabIndex = 0;
      this.spBriefing.Text = "Test Text Example";
      this.spBriefing.TextColor = System.Drawing.Color.Orange;
      this.spBriefing.TextDisabledColor = System.Drawing.Color.Gray;
      this.spBriefing.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      // 
      // spImage
      // 
      this.spImage.BackColor = System.Drawing.Color.Transparent;
      this.spImage.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spImage.Location = new System.Drawing.Point(0, 35);
      this.spImage.Name = "spImage";
      this.spImage.Size = new System.Drawing.Size(128, 128);
      this.spImage.TabIndex = 10;
      this.spImage.TextColor = System.Drawing.Color.Orange;
      this.spImage.TextDisabledColor = System.Drawing.Color.Gray;
      this.spImage.Visible = false;
      // 
      // spStart
      // 
      this.spStart.Alignment = System.Drawing.StringAlignment.Center;
      this.spStart.BackColor = System.Drawing.Color.Transparent;
      this.spStart.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RB_DN;
      this.spStart.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RB_UP;
      this.spStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.spStart.BaseImage = global::Dune2000.Launcher.Properties.Resources.RB_UP;
      this.spStart.BorderThickness = 0F;
      this.spStart.Font = new System.Drawing.Font("Agency FB", 22F);
      this.spStart.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spStart.Location = new System.Drawing.Point(728, 520);
      this.spStart.Name = "spStart";
      this.spStart.Size = new System.Drawing.Size(110, 38);
      this.spStart.TabIndex = 3;
      this.spStart.Text = "Start";
      this.spStart.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spStart.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spStart.TextColor = System.Drawing.Color.Orange;
      this.spStart.TextDisabledColor = System.Drawing.Color.Gray;
      this.spStart.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spStart.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.spStart.Click += new System.EventHandler(this.SpStart_Click);
      // 
      // spPrevPage
      // 
      this.spPrevPage.Alignment = System.Drawing.StringAlignment.Center;
      this.spPrevPage.BackColor = System.Drawing.Color.Transparent;
      this.spPrevPage.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.AUP_DN;
      this.spPrevPage.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.AUP_DS;
      this.spPrevPage.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.AUP_UP;
      this.spPrevPage.BaseImage = global::Dune2000.Launcher.Properties.Resources.AUP_UP;
      this.spPrevPage.BorderThickness = 0F;
      this.spPrevPage.Enabled = false;
      this.spPrevPage.Location = new System.Drawing.Point(835, 360);
      this.spPrevPage.Name = "spPrevPage";
      this.spPrevPage.Size = new System.Drawing.Size(32, 32);
      this.spPrevPage.TabIndex = 5;
      this.spPrevPage.Click += new System.EventHandler(this.SpPrevPage_Click);
      // 
      // spNextPage
      // 
      this.spNextPage.Alignment = System.Drawing.StringAlignment.Center;
      this.spNextPage.BackColor = System.Drawing.Color.Transparent;
      this.spNextPage.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.ADN_DN;
      this.spNextPage.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.ADN_DS;
      this.spNextPage.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.ADN_UP;
      this.spNextPage.BaseImage = global::Dune2000.Launcher.Properties.Resources.ADN_UP;
      this.spNextPage.BorderThickness = 0F;
      this.spNextPage.Enabled = false;
      this.spNextPage.Location = new System.Drawing.Point(835, 398);
      this.spNextPage.Name = "spNextPage";
      this.spNextPage.Size = new System.Drawing.Size(32, 32);
      this.spNextPage.TabIndex = 4;
      this.spNextPage.Click += new System.EventHandler(this.SpNextPage_Click);
      // 
      // MissionBriefingScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "MissionBriefingScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.spDifficulty.ResumeLayout(false);
      this.spBriefing.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Objects.SpriteBox spBriefing;
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spStart;
    private Objects.SpriteBox spNextPage;
    private Objects.SpriteBox spPrevPage;
    private Objects.SpriteBox spPrevItem;
    private Objects.SpriteBox spNextItem;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spDifficulty;
    private Objects.SpriteBox spHard;
    private Objects.SpriteBox spNormal;
    private Objects.SpriteBox spEasy;
    private Objects.SpriteBox spImage;
    private Objects.SpriteBox spBack;
    private Objects.SpriteBox spKeyHelp;
  }
}
