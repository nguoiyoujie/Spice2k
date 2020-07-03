namespace Dune2000.Launcher.UI.UserControls
{
  partial class ConfigurationScreen
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
      this.spBack = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.lblGamePath = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spDifficulty = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spGamePath = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spFind = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spPrevItem = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextItem = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spSave = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.ofdGamePath = new System.Windows.Forms.OpenFileDialog();
      this.spBG.SuspendLayout();
      this.spDifficulty.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BRIEFING;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.BRIEFING;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spBack);
      this.spBG.Controls.Add(this.lblGamePath);
      this.spBG.Controls.Add(this.spDifficulty);
      this.spBG.Controls.Add(this.spPrevItem);
      this.spBG.Controls.Add(this.spTitle);
      this.spBG.Controls.Add(this.spNextItem);
      this.spBG.Controls.Add(this.spSave);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spBG";
      this.spBG.Size = new System.Drawing.Size(960, 600);
      this.spBG.TabIndex = 1;
      this.spBG.TextColor = System.Drawing.Color.Orange;
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
      this.spKeyHelp.Location = new System.Drawing.Point(55, 29);
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
      this.spBack.Location = new System.Drawing.Point(17, 29);
      this.spBack.Name = "spBack";
      this.spBack.Size = new System.Drawing.Size(32, 32);
      this.spBack.TabIndex = 26;
      this.spBack.Click += new System.EventHandler(this.SpBack_Click);
      // 
      // lblGamePath
      // 
      this.lblGamePath.BackColor = System.Drawing.Color.Transparent;
      this.lblGamePath.Font = new System.Drawing.Font("Agency FB", 14F);
      this.lblGamePath.Location = new System.Drawing.Point(138, 134);
      this.lblGamePath.Name = "lblGamePath";
      this.lblGamePath.Size = new System.Drawing.Size(371, 27);
      this.lblGamePath.TabIndex = 10;
      this.lblGamePath.Text = "Game Executable Path";
      this.lblGamePath.TextColor = System.Drawing.Color.Orange;
      this.lblGamePath.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spDifficulty
      // 
      this.spDifficulty.Alignment = System.Drawing.StringAlignment.Center;
      this.spDifficulty.BackColor = System.Drawing.Color.Transparent;
      this.spDifficulty.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.INPUT_OK_BOX;
      this.spDifficulty.BaseImage = global::Dune2000.Launcher.Properties.Resources.INPUT_OK_BOX;
      this.spDifficulty.Controls.Add(this.spGamePath);
      this.spDifficulty.Controls.Add(this.spFind);
      this.spDifficulty.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spDifficulty.Location = new System.Drawing.Point(138, 163);
      this.spDifficulty.Name = "spDifficulty";
      this.spDifficulty.Size = new System.Drawing.Size(680, 64);
      this.spDifficulty.TabIndex = 9;
      this.spDifficulty.TextColor = System.Drawing.Color.Orange;
      // 
      // spGamePath
      // 
      this.spGamePath.BackColor = System.Drawing.Color.Transparent;
      this.spGamePath.Font = new System.Drawing.Font("Agency FB", 11F);
      this.spGamePath.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spGamePath.Location = new System.Drawing.Point(48, 21);
      this.spGamePath.Name = "spGamePath";
      this.spGamePath.Size = new System.Drawing.Size(507, 27);
      this.spGamePath.TabIndex = 11;
      this.spGamePath.Text = "<empty>";
      this.spGamePath.TextColor = System.Drawing.Color.Orange;
      this.spGamePath.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spFind
      // 
      this.spFind.Alignment = System.Drawing.StringAlignment.Center;
      this.spFind.BackColor = System.Drawing.Color.Transparent;
      this.spFind.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.EMPTY;
      this.spFind.BaseImage = global::Dune2000.Launcher.Properties.Resources.EMPTY;
      this.spFind.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spFind.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spFind.Location = new System.Drawing.Point(561, 20);
      this.spFind.Name = "spFind";
      this.spFind.Size = new System.Drawing.Size(74, 28);
      this.spFind.TabIndex = 11;
      this.spFind.Text = "Find";
      this.spFind.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spFind.TextColor = System.Drawing.Color.Orange;
      this.spFind.TextDisabledColor = System.Drawing.Color.Gray;
      this.spFind.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spFind.Click += new System.EventHandler(this.SpFind_Click);
      // 
      // spPrevItem
      // 
      this.spPrevItem.Alignment = System.Drawing.StringAlignment.Center;
      this.spPrevItem.BackColor = System.Drawing.Color.Transparent;
      this.spPrevItem.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RBACK_DN;
      this.spPrevItem.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.RBACK_DS;
      this.spPrevItem.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RBACK_UP;
      this.spPrevItem.BaseImage = global::Dune2000.Launcher.Properties.Resources.RBACK_UP;
      this.spPrevItem.Enabled = false;
      this.spPrevItem.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spPrevItem.Location = new System.Drawing.Point(139, 528);
      this.spPrevItem.Name = "spPrevItem";
      this.spPrevItem.Size = new System.Drawing.Size(24, 24);
      this.spPrevItem.TabIndex = 7;
      this.spPrevItem.TextColor = System.Drawing.Color.Orange;
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.spTitle.Location = new System.Drawing.Point(285, 64);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(371, 27);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Configuration";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextShadowColor = System.Drawing.Color.Black;
      // 
      // spNextItem
      // 
      this.spNextItem.Alignment = System.Drawing.StringAlignment.Center;
      this.spNextItem.BackColor = System.Drawing.Color.Transparent;
      this.spNextItem.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RMORE_DN;
      this.spNextItem.BackgroundDisabledImage = global::Dune2000.Launcher.Properties.Resources.RMORE_DS;
      this.spNextItem.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RMORE_UP;
      this.spNextItem.BaseImage = global::Dune2000.Launcher.Properties.Resources.RMORE_UP;
      this.spNextItem.Enabled = false;
      this.spNextItem.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spNextItem.Location = new System.Drawing.Point(175, 528);
      this.spNextItem.Name = "spNextItem";
      this.spNextItem.Size = new System.Drawing.Size(24, 24);
      this.spNextItem.TabIndex = 6;
      this.spNextItem.TextColor = System.Drawing.Color.Orange;
      // 
      // spSave
      // 
      this.spSave.Alignment = System.Drawing.StringAlignment.Center;
      this.spSave.BackColor = System.Drawing.Color.Transparent;
      this.spSave.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.RB_DN;
      this.spSave.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.RB_UP;
      this.spSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.spSave.BaseImage = global::Dune2000.Launcher.Properties.Resources.RB_UP;
      this.spSave.Font = new System.Drawing.Font("Agency FB", 20.25F);
      this.spSave.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spSave.Location = new System.Drawing.Point(731, 521);
      this.spSave.Name = "spSave";
      this.spSave.Size = new System.Drawing.Size(110, 39);
      this.spSave.TabIndex = 3;
      this.spSave.Text = "Apply";
      this.spSave.TextClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.spSave.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spSave.TextColor = System.Drawing.Color.Orange;
      this.spSave.TextDisabledColor = System.Drawing.Color.Gray;
      this.spSave.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spSave.TextShadowColor = System.Drawing.Color.Black;
      this.spSave.Click += new System.EventHandler(this.SpSave_Click);
      // 
      // ofdGamePath
      // 
      this.ofdGamePath.Filter = "Dune2000 executable file|DUNE2000.exe|All files|*.*";
      this.ofdGamePath.Title = "Select Dune2000 game executable";
      // 
      // ConfigurationScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "ConfigurationScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.spDifficulty.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spSave;
    private Objects.SpriteBox spPrevItem;
    private Objects.SpriteBox spNextItem;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spDifficulty;
    private Objects.SpriteBox spFind;
    private Objects.SpriteBox lblGamePath;
    private Objects.SpriteBox spGamePath;
    private System.Windows.Forms.OpenFileDialog ofdGamePath;
    private Objects.SpriteBox spBack;
    private Objects.SpriteBox spKeyHelp;
  }
}
