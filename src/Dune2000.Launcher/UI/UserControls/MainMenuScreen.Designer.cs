namespace Dune2000.Launcher.UI.UserControls
{
  partial class MainMenuScreen
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
      this.components = new System.ComponentModel.Container();
      this.spBG = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spKeyHelp = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spREye = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spLEye = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spQuit = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spSetting = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spLaunch = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spLoad = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spStart = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.tmEyeTrig = new System.Windows.Forms.Timer(this.components);
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.TITLE;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.TITLE;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spKeyHelp);
      this.spBG.Controls.Add(this.spREye);
      this.spBG.Controls.Add(this.spLEye);
      this.spBG.Controls.Add(this.spQuit);
      this.spBG.Controls.Add(this.spSetting);
      this.spBG.Controls.Add(this.spLaunch);
      this.spBG.Controls.Add(this.spLoad);
      this.spBG.Controls.Add(this.spStart);
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
      this.spKeyHelp.Location = new System.Drawing.Point(599, 505);
      this.spKeyHelp.Name = "spKeyHelp";
      this.spKeyHelp.Size = new System.Drawing.Size(32, 32);
      this.spKeyHelp.TabIndex = 28;
      this.spKeyHelp.Click += new System.EventHandler(this.SpKeyHelp_Click);
      // 
      // spREye
      // 
      this.spREye.Alignment = System.Drawing.StringAlignment.Center;
      this.spREye.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spREye.BackColor = System.Drawing.Color.Transparent;
      this.spREye.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.DUNE_R_EYE;
      this.spREye.BaseImage = global::Dune2000.Launcher.Properties.Resources.DUNE_R_EYE;
      this.spREye.BorderThickness = 0F;
      this.spREye.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spREye.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spREye.Location = new System.Drawing.Point(59, 60);
      this.spREye.Name = "spREye";
      this.spREye.Size = new System.Drawing.Size(240, 105);
      this.spREye.TabIndex = 9;
      // 
      // spLEye
      // 
      this.spLEye.Alignment = System.Drawing.StringAlignment.Center;
      this.spLEye.Animate = Dune2000.Launcher.UI.AnimateType.NONE;
      this.spLEye.BackColor = System.Drawing.Color.Transparent;
      this.spLEye.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.DUNE_L_EYE;
      this.spLEye.BaseImage = global::Dune2000.Launcher.Properties.Resources.DUNE_L_EYE;
      this.spLEye.BorderThickness = 0F;
      this.spLEye.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spLEye.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spLEye.Location = new System.Drawing.Point(656, 65);
      this.spLEye.Name = "spLEye";
      this.spLEye.Size = new System.Drawing.Size(240, 105);
      this.spLEye.TabIndex = 8;
      // 
      // spQuit
      // 
      this.spQuit.Alignment = System.Drawing.StringAlignment.Center;
      this.spQuit.BackColor = System.Drawing.Color.Transparent;
      this.spQuit.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT7_DN;
      this.spQuit.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT7_UP;
      this.spQuit.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT7_UP;
      this.spQuit.BorderThickness = 0F;
      this.spQuit.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spQuit.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spQuit.Location = new System.Drawing.Point(375, 435);
      this.spQuit.Name = "spQuit";
      this.spQuit.Size = new System.Drawing.Size(210, 30);
      this.spQuit.TabIndex = 7;
      this.spQuit.Text = "Quit Game";
      this.spQuit.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spQuit.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spQuit.TextColor = System.Drawing.Color.Orange;
      this.spQuit.TextDisabledColor = System.Drawing.Color.Gray;
      this.spQuit.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spQuit.TextShadowColor = System.Drawing.Color.Black;
      this.spQuit.Click += new System.EventHandler(this.SpQuit_Click);
      // 
      // spSetting
      // 
      this.spSetting.Alignment = System.Drawing.StringAlignment.Center;
      this.spSetting.BackColor = System.Drawing.Color.Transparent;
      this.spSetting.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT4_DN;
      this.spSetting.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT4_UP;
      this.spSetting.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT4_UP;
      this.spSetting.BorderThickness = 0F;
      this.spSetting.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spSetting.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spSetting.Location = new System.Drawing.Point(375, 366);
      this.spSetting.Name = "spSetting";
      this.spSetting.Size = new System.Drawing.Size(210, 30);
      this.spSetting.TabIndex = 6;
      this.spSetting.Text = "Settings";
      this.spSetting.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spSetting.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spSetting.TextColor = System.Drawing.Color.Orange;
      this.spSetting.TextDisabledColor = System.Drawing.Color.Gray;
      this.spSetting.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spSetting.TextShadowColor = System.Drawing.Color.Black;
      this.spSetting.Click += new System.EventHandler(this.SpSetting_Click);
      // 
      // spLaunch
      // 
      this.spLaunch.Alignment = System.Drawing.StringAlignment.Center;
      this.spLaunch.BackColor = System.Drawing.Color.Transparent;
      this.spLaunch.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT3_DN;
      this.spLaunch.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT3_UP;
      this.spLaunch.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT3_UP;
      this.spLaunch.BorderThickness = 0F;
      this.spLaunch.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spLaunch.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spLaunch.Location = new System.Drawing.Point(375, 330);
      this.spLaunch.Name = "spLaunch";
      this.spLaunch.Size = new System.Drawing.Size(210, 30);
      this.spLaunch.TabIndex = 5;
      this.spLaunch.Text = "Launch Dune 2000";
      this.spLaunch.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spLaunch.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spLaunch.TextColor = System.Drawing.Color.Orange;
      this.spLaunch.TextDisabledColor = System.Drawing.Color.Gray;
      this.spLaunch.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spLaunch.TextShadowColor = System.Drawing.Color.Black;
      this.spLaunch.Click += new System.EventHandler(this.SpLaunch_Click);
      // 
      // spLoad
      // 
      this.spLoad.Alignment = System.Drawing.StringAlignment.Center;
      this.spLoad.BackColor = System.Drawing.Color.Transparent;
      this.spLoad.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT2_DN;
      this.spLoad.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT2_UP;
      this.spLoad.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT2_UP;
      this.spLoad.BorderThickness = 0F;
      this.spLoad.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spLoad.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spLoad.Location = new System.Drawing.Point(375, 294);
      this.spLoad.Name = "spLoad";
      this.spLoad.Size = new System.Drawing.Size(210, 30);
      this.spLoad.TabIndex = 4;
      this.spLoad.Text = "Load Campaign";
      this.spLoad.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spLoad.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spLoad.TextColor = System.Drawing.Color.Orange;
      this.spLoad.TextDisabledColor = System.Drawing.Color.Gray;
      this.spLoad.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spLoad.TextShadowColor = System.Drawing.Color.Black;
      this.spLoad.Click += new System.EventHandler(this.SpLoad_Click);
      // 
      // spStart
      // 
      this.spStart.Alignment = System.Drawing.StringAlignment.Center;
      this.spStart.BackColor = System.Drawing.Color.Transparent;
      this.spStart.BackgroundClickImage = global::Dune2000.Launcher.Properties.Resources.BUT1_DN;
      this.spStart.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT1_UP;
      this.spStart.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT1_UP;
      this.spStart.BorderThickness = 0F;
      this.spStart.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spStart.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spStart.Location = new System.Drawing.Point(375, 258);
      this.spStart.Name = "spStart";
      this.spStart.Size = new System.Drawing.Size(210, 30);
      this.spStart.TabIndex = 3;
      this.spStart.Text = "Start New Campaign";
      this.spStart.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spStart.TextClickOffset = new System.Drawing.Point(1, 1);
      this.spStart.TextColor = System.Drawing.Color.Orange;
      this.spStart.TextDisabledColor = System.Drawing.Color.Gray;
      this.spStart.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spStart.TextShadowColor = System.Drawing.Color.Black;
      this.spStart.Click += new System.EventHandler(this.SpStart_Click);
      // 
      // tmEyeTrig
      // 
      this.tmEyeTrig.Enabled = true;
      this.tmEyeTrig.Interval = 45000;
      this.tmEyeTrig.Tick += new System.EventHandler(this.TmEyeTrig_Tick);
      // 
      // MainMenuScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "MainMenuScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spStart;
    private Objects.SpriteBox spQuit;
    private Objects.SpriteBox spSetting;
    private Objects.SpriteBox spLaunch;
    private Objects.SpriteBox spLoad;
    private Objects.SpriteBox spLEye;
    private Objects.SpriteBox spREye;
    private System.Windows.Forms.Timer tmEyeTrig;
    private Objects.SpriteBox spKeyHelp;
  }
}
