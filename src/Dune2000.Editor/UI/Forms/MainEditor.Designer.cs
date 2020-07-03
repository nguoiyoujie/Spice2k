namespace Dune2000.Editor.UI.Forms
{
  partial class MainEditor
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tcMain = new System.Windows.Forms.TabControl();
      this.tpTextUib = new System.Windows.Forms.TabPage();
      this.ucTextUibEditor1 = new Dune2000.Editor.UI.UserControls.ucTextUibEditor();
      this.tpColourUib = new System.Windows.Forms.TabPage();
      this.ucColourUibEditor1 = new Dune2000.Editor.UI.UserControls.ucColourUibEditor();
      this.tpMenuUib = new System.Windows.Forms.TabPage();
      this.ucMenusUibEditor1 = new Dune2000.Editor.UI.UserControls.ucMenusUibEditor();
      this.tpCampaignUib = new System.Windows.Forms.TabPage();
      this.ucCampaignUibEditor1 = new Dune2000.Editor.UI.UserControls.ucCampaignUibEditor();
      this.label1 = new System.Windows.Forms.Label();
      this.tcMain.SuspendLayout();
      this.tpTextUib.SuspendLayout();
      this.tpColourUib.SuspendLayout();
      this.tpMenuUib.SuspendLayout();
      this.tpCampaignUib.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcMain
      // 
      this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tcMain.Controls.Add(this.tpTextUib);
      this.tcMain.Controls.Add(this.tpColourUib);
      this.tcMain.Controls.Add(this.tpMenuUib);
      this.tcMain.Controls.Add(this.tpCampaignUib);
      this.tcMain.Location = new System.Drawing.Point(12, 33);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new System.Drawing.Size(937, 557);
      this.tcMain.TabIndex = 1;
      // 
      // tpTextUib
      // 
      this.tpTextUib.Controls.Add(this.ucTextUibEditor1);
      this.tpTextUib.Location = new System.Drawing.Point(4, 22);
      this.tpTextUib.Name = "tpTextUib";
      this.tpTextUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpTextUib.Size = new System.Drawing.Size(929, 531);
      this.tpTextUib.TabIndex = 0;
      this.tpTextUib.Text = "Text Uib";
      this.tpTextUib.UseVisualStyleBackColor = true;
      // 
      // ucTextUibEditor1
      // 
      this.ucTextUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTextUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucTextUibEditor1.Name = "ucTextUibEditor1";
      this.ucTextUibEditor1.Size = new System.Drawing.Size(923, 525);
      this.ucTextUibEditor1.TabIndex = 1;
      // 
      // tpColourUib
      // 
      this.tpColourUib.Controls.Add(this.ucColourUibEditor1);
      this.tpColourUib.Location = new System.Drawing.Point(4, 22);
      this.tpColourUib.Name = "tpColourUib";
      this.tpColourUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpColourUib.Size = new System.Drawing.Size(929, 467);
      this.tpColourUib.TabIndex = 1;
      this.tpColourUib.Text = "Colour Uib";
      this.tpColourUib.UseVisualStyleBackColor = true;
      // 
      // ucColourUibEditor1
      // 
      this.ucColourUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucColourUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucColourUibEditor1.Name = "ucColourUibEditor1";
      this.ucColourUibEditor1.Size = new System.Drawing.Size(923, 461);
      this.ucColourUibEditor1.TabIndex = 0;
      // 
      // tpMenuUib
      // 
      this.tpMenuUib.Controls.Add(this.ucMenusUibEditor1);
      this.tpMenuUib.Location = new System.Drawing.Point(4, 22);
      this.tpMenuUib.Name = "tpMenuUib";
      this.tpMenuUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpMenuUib.Size = new System.Drawing.Size(929, 467);
      this.tpMenuUib.TabIndex = 2;
      this.tpMenuUib.Text = "Menu Uib";
      this.tpMenuUib.UseVisualStyleBackColor = true;
      // 
      // ucMenusUibEditor1
      // 
      this.ucMenusUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMenusUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucMenusUibEditor1.Name = "ucMenusUibEditor1";
      this.ucMenusUibEditor1.Size = new System.Drawing.Size(923, 461);
      this.ucMenusUibEditor1.TabIndex = 0;
      // 
      // tpCampaignUib
      // 
      this.tpCampaignUib.Controls.Add(this.ucCampaignUibEditor1);
      this.tpCampaignUib.Location = new System.Drawing.Point(4, 22);
      this.tpCampaignUib.Name = "tpCampaignUib";
      this.tpCampaignUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpCampaignUib.Size = new System.Drawing.Size(929, 467);
      this.tpCampaignUib.TabIndex = 3;
      this.tpCampaignUib.Text = "Campaign Uib";
      this.tpCampaignUib.UseVisualStyleBackColor = true;
      // 
      // ucCampaignUibEditor1
      // 
      this.ucCampaignUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucCampaignUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucCampaignUibEditor1.Name = "ucCampaignUibEditor1";
      this.ucCampaignUibEditor1.Size = new System.Drawing.Size(923, 461);
      this.ucCampaignUibEditor1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
      this.label1.ForeColor = System.Drawing.Color.Red;
      this.label1.Location = new System.Drawing.Point(13, 4);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(539, 24);
      this.label1.TabIndex = 2;
      this.label1.Text = "Test version. Make a backup of your files before experimenting.";
      // 
      // MainEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(961, 602);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tcMain);
      this.Name = "MainEditor";
      this.Text = "Dune 2000 Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
      this.tcMain.ResumeLayout(false);
      this.tpTextUib.ResumeLayout(false);
      this.tpColourUib.ResumeLayout(false);
      this.tpMenuUib.ResumeLayout(false);
      this.tpCampaignUib.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpTextUib;
    private UserControls.ucTextUibEditor ucTextUibEditor1;
    private System.Windows.Forms.TabPage tpColourUib;
    private UserControls.ucColourUibEditor ucColourUibEditor1;
    private System.Windows.Forms.TabPage tpMenuUib;
    private UserControls.ucMenusUibEditor ucMenusUibEditor1;
    private System.Windows.Forms.TabPage tpCampaignUib;
    private UserControls.ucCampaignUibEditor ucCampaignUibEditor1;
    private System.Windows.Forms.Label label1;
  }
}