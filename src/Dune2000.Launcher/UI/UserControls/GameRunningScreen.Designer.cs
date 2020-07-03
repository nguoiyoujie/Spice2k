namespace Dune2000.Launcher.UI.UserControls
{
  partial class GameRunningScreen
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
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.tmProcess = new System.Windows.Forms.Timer(this.components);
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BRIEFING;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.BRIEFING;
      this.spBG.Controls.Add(this.spTitle);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spBG";
      this.spBG.Size = new System.Drawing.Size(960, 600);
      this.spBG.TabIndex = 1;
      this.spBG.TextColor = System.Drawing.Color.Orange;
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 24.75F);
      this.spTitle.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spTitle.Location = new System.Drawing.Point(134, 219);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(689, 111);
      this.spTitle.TabIndex = 8;
      this.spTitle.Text = "Game Session in Progress";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextShadowColor = System.Drawing.Color.Black;
      // 
      // tmProcess
      // 
      this.tmProcess.Enabled = true;
      this.tmProcess.Tick += new System.EventHandler(this.tmProcess_Tick);
      // 
      // GameRunningScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "GameRunningScreen";
      this.Size = new System.Drawing.Size(960, 600);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spTitle;
    private System.Windows.Forms.Timer tmProcess;
  }
}
