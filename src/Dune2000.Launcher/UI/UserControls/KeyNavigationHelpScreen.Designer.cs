namespace Dune2000.Launcher.UI.UserControls
{
  partial class KeyNavigationHelpScreen
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
      this.spTitle = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spKeyDesc = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spAck = new Dune2000.Launcher.UI.Objects.SpriteBox();
      this.spBG.SuspendLayout();
      this.SuspendLayout();
      // 
      // spBG
      // 
      this.spBG.Alignment = System.Drawing.StringAlignment.Center;
      this.spBG.BackColor = System.Drawing.Color.Transparent;
      this.spBG.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BOX10;
      this.spBG.BaseImage = global::Dune2000.Launcher.Properties.Resources.BOX10;
      this.spBG.Controls.Add(this.spPrevPage);
      this.spBG.Controls.Add(this.spNextPage);
      this.spBG.Controls.Add(this.spTitle);
      this.spBG.Controls.Add(this.spKeyDesc);
      this.spBG.Controls.Add(this.spAck);
      this.spBG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spBG.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spBG.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spBG.Location = new System.Drawing.Point(0, 0);
      this.spBG.Name = "spBG";
      this.spBG.Size = new System.Drawing.Size(360, 420);
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
      this.spPrevPage.Location = new System.Drawing.Point(246, 350);
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
      this.spNextPage.Location = new System.Drawing.Point(284, 350);
      this.spNextPage.Name = "spNextPage";
      this.spNextPage.Size = new System.Drawing.Size(32, 32);
      this.spNextPage.TabIndex = 12;
      this.spNextPage.Click += new System.EventHandler(this.spNextPage_Click);
      // 
      // spTitle
      // 
      this.spTitle.Alignment = System.Drawing.StringAlignment.Center;
      this.spTitle.BackColor = System.Drawing.Color.Transparent;
      this.spTitle.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spTitle.Location = new System.Drawing.Point(42, 38);
      this.spTitle.Name = "spTitle";
      this.spTitle.Size = new System.Drawing.Size(274, 25);
      this.spTitle.TabIndex = 11;
      this.spTitle.Text = "Interactive Key List";
      this.spTitle.TextColor = System.Drawing.Color.Orange;
      this.spTitle.TextDisabledColor = System.Drawing.Color.Gray;
      // 
      // spKeyDesc
      // 
      this.spKeyDesc.BackColor = System.Drawing.Color.Transparent;
      this.spKeyDesc.Font = new System.Drawing.Font("Agency FB", 12.25F);
      this.spKeyDesc.Location = new System.Drawing.Point(42, 69);
      this.spKeyDesc.Name = "spKeyDesc";
      this.spKeyDesc.Size = new System.Drawing.Size(274, 275);
      this.spKeyDesc.TabIndex = 10;
      this.spKeyDesc.Text = "<Key Description>";
      this.spKeyDesc.TextColor = System.Drawing.Color.Orange;
      this.spKeyDesc.TextDisabledColor = System.Drawing.Color.Gray;
      // 
      // spAck
      // 
      this.spAck.Alignment = System.Drawing.StringAlignment.Center;
      this.spAck.BackColor = System.Drawing.Color.Transparent;
      this.spAck.BackgroundImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spAck.BaseImage = global::Dune2000.Launcher.Properties.Resources.BUT8_UP;
      this.spAck.Font = new System.Drawing.Font("Agency FB", 14.25F);
      this.spAck.LineAlignment = System.Drawing.StringAlignment.Center;
      this.spAck.Location = new System.Drawing.Point(42, 350);
      this.spAck.Name = "spAck";
      this.spAck.Size = new System.Drawing.Size(120, 30);
      this.spAck.TabIndex = 9;
      this.spAck.Text = "OK";
      this.spAck.TextClickColor = System.Drawing.Color.OrangeRed;
      this.spAck.TextColor = System.Drawing.Color.Orange;
      this.spAck.TextDisabledColor = System.Drawing.Color.Gray;
      this.spAck.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.spAck.Click += new System.EventHandler(this.spAck_Click);
      // 
      // KeyNavigationHelpScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.spBG);
      this.Name = "KeyNavigationHelpScreen";
      this.Size = new System.Drawing.Size(360, 420);
      this.spBG.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private Objects.SpriteBox spBG;
    private Objects.SpriteBox spAck;
    private Objects.SpriteBox spKeyDesc;
    private Objects.SpriteBox spTitle;
    private Objects.SpriteBox spPrevPage;
    private Objects.SpriteBox spNextPage;
  }
}
