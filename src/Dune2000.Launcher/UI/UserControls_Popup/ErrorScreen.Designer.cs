namespace Dune2000.Launcher.UI.UserControls
{
  partial class ErrorScreen
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
      this.spPrevPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spNextPage = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spErrorTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spErrorText = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spErrAck = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spErrorPanel
      // 
      this.spBG.Alignment = System.Drawing.StringAlignment.Center;
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BOX11;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.BOX11;
      this.spBG.Controls.Add(this.spPrevPage);
      this.spBG.Controls.Add(this.spNextPage);
      this.spBG.Controls.Add(this.spErrorTitle);
      this.spBG.Controls.Add(this.spErrorText);
      this.spBG.Controls.Add(this.spErrAck);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spBG.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spErrorPanel";
      this.spBG.Size = new System.Drawing.Size(474, 255);
      this.spBG.TabIndex = 8;
      this.spBG.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spBG.TextColor = System.Drawing.Color.Orange;
      this.spBG.TextDisabledColor = System.Drawing.Color.Gray;
      this.spBG.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
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
      this.spPrevPage.Location = new System.Drawing.Point(359, 184);
      this.spPrevPage.Name = "spPrevPage";
      this.spPrevPage.Size = new System.Drawing.Size(32, 32);
      this.spPrevPage.TabIndex = 13;
      this.spPrevPage.Click += new System.EventHandler(this.spPrevPage_Click);
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
      this.spNextPage.Location = new System.Drawing.Point(397, 184);
      this.spNextPage.Name = "spNextPage";
      this.spNextPage.Size = new System.Drawing.Size(32, 32);
      this.spNextPage.TabIndex = 12;
      this.spNextPage.Click += new System.EventHandler(this.spNextPage_Click);
      // 
      // spErrorTitle
      // 
      this.spErrorTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spErrorTitle.BackColor = System.Drawing.Color.Transparent;
      this.spErrorTitle.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spErrorTitle.Location = new System.Drawing.Point(42, 38);
      this.spErrorTitle.Name = "spErrorTitle";
      this.spErrorTitle.Size = new System.Drawing.Size(387, 39);
      this.spErrorTitle.TabIndex = 11;
      this.spErrorTitle.Text = "<Error Title>";
      this.spErrorTitle.TextColor = System.Drawing.Color.Orange;
      this.spErrorTitle.TextDisabledColor = System.Drawing.Color.Gray;
      // 
      // spErrorText
      // 
      this.spErrorText.Alignment = System.Drawing.StringAlignment.Center;
      this.spErrorText.BackColor = System.Drawing.Color.Transparent;
      this.spErrorText.Font = new System.Drawing.Font("Agency FB", 12.25F);
      this.spErrorText.Location = new System.Drawing.Point(42, 83);
      this.spErrorText.Name = "spErrorText";
      this.spErrorText.Size = new System.Drawing.Size(387, 95);
      this.spErrorText.TabIndex = 10;
      this.spErrorText.Text = "<Error Text>";
      this.spErrorText.TextColor = System.Drawing.Color.Orange;
      this.spErrorText.TextDisabledColor = System.Drawing.Color.Gray;
      // 
      // spErrAck
      // 
      this.spErrAck.Alignment = System.Drawing.StringAlignment.Center;
      this.spErrAck.BackColor = System.Drawing.Color.Transparent;
      this.spErrAck.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spErrAck.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spErrAck.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spErrAck.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spErrAck.Location = new System.Drawing.Point(176, 184);
      this.spErrAck.Name = "spErrAck";
      this.spErrAck.Size = new System.Drawing.Size(120, 30);
      this.spErrAck.TabIndex = 9;
      this.spErrAck.Text = "OK";
      this.spErrAck.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spErrAck.TextColor = System.Drawing.Color.Orange;
      this.spErrAck.TextDisabledColor = System.Drawing.Color.Gray;
      this.spErrAck.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spErrAck.Click += new System.EventHandler(this.spErrAck_Click);
      // 
      // ErrorScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "ErrorScreen";
      this.Size = new System.Drawing.Size(474, 255);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spErrAck;
    private Objects.SpriteBox spErrorText;
    private Objects.SpriteBox spErrorTitle;
    private Objects.SpriteBox spPrevPage;
    private Objects.SpriteBox spNextPage;
  }
}
