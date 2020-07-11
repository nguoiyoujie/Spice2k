namespace Dune2000.Editor.UI.Editors
{
  partial class ucEditorSelector
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEditorSelector));
      this.tsUib = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.tsbTextUib = new System.Windows.Forms.ToolStripButton();
      this.tsbColoursUib = new System.Windows.Forms.ToolStripButton();
      this.tsbMenuUib = new System.Windows.Forms.ToolStripButton();
      this.tsbCampaignUib = new System.Windows.Forms.ToolStripButton();
      this.tsRes = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.tsbR8R16 = new System.Windows.Forms.ToolStripButton();
      this.tsbRS = new System.Windows.Forms.ToolStripButton();
      this.tsBin = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
      this.tsbTemplatesBin = new System.Windows.Forms.ToolStripButton();
      this.tsbPaletteBin = new System.Windows.Forms.ToolStripButton();
      this.tsbColoursBin = new System.Windows.Forms.ToolStripButton();
      this.tsbCirclesBin = new System.Windows.Forms.ToolStripButton();
      this.tsUib.SuspendLayout();
      this.tsRes.SuspendLayout();
      this.tsBin.SuspendLayout();
      this.SuspendLayout();
      // 
      // tsUib
      // 
      this.tsUib.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbTextUib,
            this.tsbColoursUib,
            this.tsbMenuUib,
            this.tsbCampaignUib});
      this.tsUib.Location = new System.Drawing.Point(0, 0);
      this.tsUib.Name = "tsUib";
      this.tsUib.Size = new System.Drawing.Size(789, 38);
      this.tsUib.TabIndex = 5;
      this.tsUib.Text = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(53, 35);
      this.toolStripLabel1.Text = "UI Tables";
      // 
      // tsbTextUib
      // 
      this.tsbTextUib.Enabled = false;
      this.tsbTextUib.Image = ((System.Drawing.Image)(resources.GetObject("tsbTextUib.Image")));
      this.tsbTextUib.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbTextUib.Name = "tsbTextUib";
      this.tsbTextUib.Size = new System.Drawing.Size(53, 35);
      this.tsbTextUib.Text = "Text UIB";
      this.tsbTextUib.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbTextUib.Click += new System.EventHandler(this.Select);
      // 
      // tsbColoursUib
      // 
      this.tsbColoursUib.Enabled = false;
      this.tsbColoursUib.Image = ((System.Drawing.Image)(resources.GetObject("tsbColoursUib.Image")));
      this.tsbColoursUib.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbColoursUib.Name = "tsbColoursUib";
      this.tsbColoursUib.Size = new System.Drawing.Size(73, 35);
      this.tsbColoursUib.Text = "Colours UIB";
      this.tsbColoursUib.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbColoursUib.Click += new System.EventHandler(this.Select);
      // 
      // tsbMenuUib
      // 
      this.tsbMenuUib.Enabled = false;
      this.tsbMenuUib.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuUib.Image")));
      this.tsbMenuUib.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMenuUib.Name = "tsbMenuUib";
      this.tsbMenuUib.Size = new System.Drawing.Size(63, 35);
      this.tsbMenuUib.Text = "Menu UIB";
      this.tsbMenuUib.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbMenuUib.Click += new System.EventHandler(this.Select);
      // 
      // tsbCampaignUib
      // 
      this.tsbCampaignUib.Enabled = false;
      this.tsbCampaignUib.Image = ((System.Drawing.Image)(resources.GetObject("tsbCampaignUib.Image")));
      this.tsbCampaignUib.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCampaignUib.Name = "tsbCampaignUib";
      this.tsbCampaignUib.Size = new System.Drawing.Size(87, 35);
      this.tsbCampaignUib.Text = "Campaign UIB";
      this.tsbCampaignUib.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbCampaignUib.Click += new System.EventHandler(this.Select);
      // 
      // tsRes
      // 
      this.tsRes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tsbR8R16,
            this.tsbRS});
      this.tsRes.Location = new System.Drawing.Point(0, 38);
      this.tsRes.Name = "tsRes";
      this.tsRes.Size = new System.Drawing.Size(789, 38);
      this.tsRes.TabIndex = 6;
      this.tsRes.Text = "toolStrip1";
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(60, 35);
      this.toolStripLabel2.Text = "Resources";
      // 
      // tsbR8R16
      // 
      this.tsbR8R16.Enabled = false;
      this.tsbR8R16.Image = ((System.Drawing.Image)(resources.GetObject("tsbR8R16.Image")));
      this.tsbR8R16.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbR8R16.Name = "tsbR8R16";
      this.tsbR8R16.Size = new System.Drawing.Size(103, 35);
      this.tsbR8R16.Text = "R8 / R16 (Images)";
      this.tsbR8R16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbR8R16.Click += new System.EventHandler(this.Select);
      // 
      // tsbRS
      // 
      this.tsbRS.Enabled = false;
      this.tsbRS.Image = ((System.Drawing.Image)(resources.GetObject("tsbRS.Image")));
      this.tsbRS.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbRS.Name = "tsbRS";
      this.tsbRS.Size = new System.Drawing.Size(74, 35);
      this.tsbRS.Text = "RS (Sounds)";
      this.tsbRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbRS.Click += new System.EventHandler(this.Select);
      // 
      // tsBin
      // 
      this.tsBin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tsbTemplatesBin,
            this.tsbPaletteBin,
            this.tsbColoursBin,
            this.tsbCirclesBin});
      this.tsBin.Location = new System.Drawing.Point(0, 76);
      this.tsBin.Name = "tsBin";
      this.tsBin.Size = new System.Drawing.Size(789, 38);
      this.tsBin.TabIndex = 7;
      this.tsBin.Text = "toolStrip1";
      // 
      // toolStripLabel3
      // 
      this.toolStripLabel3.Name = "toolStripLabel3";
      this.toolStripLabel3.Size = new System.Drawing.Size(48, 35);
      this.toolStripLabel3.Text = "Binaries";
      // 
      // tsbTemplatesBin
      // 
      this.tsbTemplatesBin.Enabled = false;
      this.tsbTemplatesBin.Image = ((System.Drawing.Image)(resources.GetObject("tsbTemplatesBin.Image")));
      this.tsbTemplatesBin.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbTemplatesBin.Name = "tsbTemplatesBin";
      this.tsbTemplatesBin.Size = new System.Drawing.Size(84, 35);
      this.tsbTemplatesBin.Text = "Templates Bin";
      this.tsbTemplatesBin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbTemplatesBin.Click += new System.EventHandler(this.Select);
      // 
      // tsbPaletteBin
      // 
      this.tsbPaletteBin.Enabled = false;
      this.tsbPaletteBin.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaletteBin.Image")));
      this.tsbPaletteBin.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbPaletteBin.Name = "tsbPaletteBin";
      this.tsbPaletteBin.Size = new System.Drawing.Size(47, 35);
      this.tsbPaletteBin.Text = "Palette";
      this.tsbPaletteBin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbPaletteBin.Click += new System.EventHandler(this.Select);
      // 
      // tsbColoursBin
      // 
      this.tsbColoursBin.Enabled = false;
      this.tsbColoursBin.Image = ((System.Drawing.Image)(resources.GetObject("tsbColoursBin.Image")));
      this.tsbColoursBin.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbColoursBin.Name = "tsbColoursBin";
      this.tsbColoursBin.Size = new System.Drawing.Size(52, 35);
      this.tsbColoursBin.Text = "Colours";
      this.tsbColoursBin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbColoursBin.Click += new System.EventHandler(this.Select);
      // 
      // tsbCirclesBin
      // 
      this.tsbCirclesBin.Enabled = false;
      this.tsbCirclesBin.Image = ((System.Drawing.Image)(resources.GetObject("tsbCirclesBin.Image")));
      this.tsbCirclesBin.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCirclesBin.Name = "tsbCirclesBin";
      this.tsbCirclesBin.Size = new System.Drawing.Size(46, 35);
      this.tsbCirclesBin.Text = "Circles";
      this.tsbCirclesBin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.tsbCirclesBin.Click += new System.EventHandler(this.Select);
      // 
      // ucEditorSelector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tsBin);
      this.Controls.Add(this.tsRes);
      this.Controls.Add(this.tsUib);
      this.Name = "ucEditorSelector";
      this.Size = new System.Drawing.Size(789, 141);
      this.tsUib.ResumeLayout(false);
      this.tsUib.PerformLayout();
      this.tsRes.ResumeLayout(false);
      this.tsRes.PerformLayout();
      this.tsBin.ResumeLayout(false);
      this.tsBin.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolStrip tsUib;
    private System.Windows.Forms.ToolStripButton tsbTextUib;
    private System.Windows.Forms.ToolStripButton tsbMenuUib;
    private System.Windows.Forms.ToolStripButton tsbCampaignUib;
    private System.Windows.Forms.ToolStripButton tsbColoursUib;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStrip tsRes;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.ToolStripButton tsbR8R16;
    private System.Windows.Forms.ToolStripButton tsbRS;
    private System.Windows.Forms.ToolStrip tsBin;
    private System.Windows.Forms.ToolStripLabel toolStripLabel3;
    private System.Windows.Forms.ToolStripButton tsbTemplatesBin;
    private System.Windows.Forms.ToolStripButton tsbPaletteBin;
    private System.Windows.Forms.ToolStripButton tsbColoursBin;
    private System.Windows.Forms.ToolStripButton tsbCirclesBin;
  }
}
