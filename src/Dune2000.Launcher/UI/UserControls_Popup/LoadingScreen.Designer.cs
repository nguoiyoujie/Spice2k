namespace Dune2000.Launcher.UI.UserControls
{
  partial class LoadingScreen
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
      this.spImg = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spImg2 = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spLoadingTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spLoadingText = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.spImg.SuspendLayout();
      this.SuspendLayout();
      // 
      // spErrorPanel
      // 
      this.spBG.Alignment = System.Drawing.StringAlignment.Center;
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BOX4;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.BOX4;
      this.spBG.BorderThickness = 0F;
      this.spBG.Controls.Add(this.spImg);
      this.spBG.Controls.Add(this.spLoadingTitle);
      this.spBG.Controls.Add(this.spLoadingText);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spBG.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spErrorPanel";
      this.spBG.Size = new System.Drawing.Size(360, 195);
      this.spBG.TabIndex = 8;
      this.spBG.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spBG.TextColor = System.Drawing.Color.Orange;
      this.spBG.TextDisabledColor = System.Drawing.Color.Gray;
      this.spBG.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spBG.TextPage = 0;
      // 
      // spImg
      // 
      this.spImg.Alignment = System.Drawing.StringAlignment.Center;
      this.spImg.BackColor = System.Drawing.Color.Transparent;
      this.spImg.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.SPICE_BG;
      this.spImg.BaseImage = global::Dune2000.Launcher.Properties.Resources.SPICE_BG;
      this.spImg.BorderThickness = 0F;
      this.spImg.Controls.Add(this.spImg2);
      this.spImg.Font = new System.Drawing.Font("Agency FB", 12.25F);
      this.spImg.Location = new System.Drawing.Point(31, 67);
      this.spImg.Name = "spImg";
      this.spImg.Size = new System.Drawing.Size(96, 96);
      this.spImg.TabIndex = 12;
      this.spImg.TextColor = System.Drawing.Color.Orange;
      this.spImg.TextDisabledColor = System.Drawing.Color.Gray;
      this.spImg.TextPage = 0;
      // 
      // spImg2
      // 
      this.spImg2.Alignment = System.Drawing.StringAlignment.Center;
      this.spImg2.BackColor = System.Drawing.Color.Transparent;
      this.spImg2.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.SPICE;
      this.spImg2.BaseImage = global::Dune2000.Launcher.Properties.Resources.SPICE;
      this.spImg2.BorderThickness = 0F;
      this.spImg2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spImg2.Font = new System.Drawing.Font("Agency FB", 12.25F);
      this.spImg2.Location = new System.Drawing.Point(0, 0);
      this.spImg2.Name = "spImg2";
      this.spImg2.Size = new System.Drawing.Size(96, 96);
      this.spImg2.TabIndex = 13;
      this.spImg2.TextColor = System.Drawing.Color.Orange;
      this.spImg2.TextDisabledColor = System.Drawing.Color.Gray;
      this.spImg2.TextPage = 0;
      // 
      // spLoadingTitle
      // 
      this.spLoadingTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spLoadingTitle.BackColor = System.Drawing.Color.Transparent;
      this.spLoadingTitle.BorderThickness = 0F;
      this.spLoadingTitle.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spLoadingTitle.Location = new System.Drawing.Point(31, 29);
      this.spLoadingTitle.Name = "spLoadingTitle";
      this.spLoadingTitle.Size = new System.Drawing.Size(293, 32);
      this.spLoadingTitle.TabIndex = 11;
      this.spLoadingTitle.Text = "Loading...";
      this.spLoadingTitle.TextColor = System.Drawing.Color.Orange;
      this.spLoadingTitle.TextDisabledColor = System.Drawing.Color.Gray;
      this.spLoadingTitle.TextPage = 0;
      // 
      // spLoadingText
      // 
      this.spLoadingText.Alignment = System.Drawing.StringAlignment.Center;
      this.spLoadingText.BackColor = System.Drawing.Color.Transparent;
      this.spLoadingText.BorderThickness = 0F;
      this.spLoadingText.Font = new System.Drawing.Font("Agency FB", 12.25F);
      this.spLoadingText.Location = new System.Drawing.Point(133, 67);
      this.spLoadingText.Name = "spLoadingText";
      this.spLoadingText.Size = new System.Drawing.Size(191, 96);
      this.spLoadingText.TabIndex = 10;
      this.spLoadingText.TextColor = System.Drawing.Color.Orange;
      this.spLoadingText.TextDisabledColor = System.Drawing.Color.Gray;
      this.spLoadingText.TextPage = 0;
      // 
      // LoadingScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "LoadingScreen";
      this.Size = new System.Drawing.Size(360, 195);
      this.spBG.ResumeLayout(false);
      this.spImg.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spLoadingText;
    private Objects.SpriteBox spLoadingTitle;
    private Objects.SpriteBox spImg;
    private Objects.SpriteBox spImg2;
  }
}
