namespace Dune2000.Editor.UI.Editors.Uib.Campaign
{
  partial class ucCampaignUibEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCampaignUibEditor));
      this.panel1 = new System.Windows.Forms.Panel();
      this.pPreview = new System.Windows.Forms.Panel();
      this.label26 = new System.Windows.Forms.Label();
      this.pbPreview = new System.Windows.Forms.PictureBox();
      this.bBefAnim = new System.Windows.Forms.Button();
      this.bAnim1 = new System.Windows.Forms.Button();
      this.bFinal = new System.Windows.Forms.Button();
      this.bAnim2 = new System.Windows.Forms.Button();
      this.bAnim3 = new System.Windows.Forms.Button();
      this.cRegionPanel = new CampaignRegionPanel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.llblPreview = new System.Windows.Forms.LinkLabel();
      this.llblCommon = new System.Windows.Forms.LinkLabel();
      this.llblRegion = new System.Windows.Forms.LinkLabel();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbScenario = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.cCommonPanel = new CampaignCommonPanel();
      this.panel1.SuspendLayout();
      this.pPreview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pPreview);
      this.panel1.Controls.Add(this.cCommonPanel);
      this.panel1.Controls.Add(this.cRegionPanel);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(960, 1095);
      this.panel1.TabIndex = 5;
      // 
      // pPreview
      // 
      this.pPreview.Controls.Add(this.label26);
      this.pPreview.Controls.Add(this.pbPreview);
      this.pPreview.Controls.Add(this.bBefAnim);
      this.pPreview.Controls.Add(this.bAnim1);
      this.pPreview.Controls.Add(this.bFinal);
      this.pPreview.Controls.Add(this.bAnim2);
      this.pPreview.Controls.Add(this.bAnim3);
      this.pPreview.Dock = System.Windows.Forms.DockStyle.Top;
      this.pPreview.Location = new System.Drawing.Point(0, 547);
      this.pPreview.Name = "pPreview";
      this.pPreview.Size = new System.Drawing.Size(960, 455);
      this.pPreview.TabIndex = 65;
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(16, 30);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(45, 13);
      this.label26.TabIndex = 56;
      this.label26.Text = "Preview";
      this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // pbPreview
      // 
      this.pbPreview.BackColor = System.Drawing.Color.Black;
      this.pbPreview.Location = new System.Drawing.Point(19, 46);
      this.pbPreview.Name = "pbPreview";
      this.pbPreview.Size = new System.Drawing.Size(640, 400);
      this.pbPreview.TabIndex = 55;
      this.pbPreview.TabStop = false;
      // 
      // bBefAnim
      // 
      this.bBefAnim.Location = new System.Drawing.Point(67, 12);
      this.bBefAnim.Name = "bBefAnim";
      this.bBefAnim.Size = new System.Drawing.Size(118, 31);
      this.bBefAnim.TabIndex = 57;
      this.bBefAnim.Text = "Before Animations";
      this.bBefAnim.UseVisualStyleBackColor = true;
      this.bBefAnim.Click += new System.EventHandler(this.bBefAnim_Click);
      // 
      // bAnim1
      // 
      this.bAnim1.Location = new System.Drawing.Point(191, 12);
      this.bAnim1.Name = "bAnim1";
      this.bAnim1.Size = new System.Drawing.Size(118, 31);
      this.bAnim1.TabIndex = 58;
      this.bAnim1.Text = "After 1st SFX/Anim";
      this.bAnim1.UseVisualStyleBackColor = true;
      this.bAnim1.Click += new System.EventHandler(this.bAnim1_Click);
      // 
      // bFinal
      // 
      this.bFinal.Location = new System.Drawing.Point(563, 12);
      this.bFinal.Name = "bFinal";
      this.bFinal.Size = new System.Drawing.Size(96, 31);
      this.bFinal.TabIndex = 61;
      this.bFinal.Text = "Player Select";
      this.bFinal.UseVisualStyleBackColor = true;
      this.bFinal.Click += new System.EventHandler(this.bFinal_Click);
      // 
      // bAnim2
      // 
      this.bAnim2.Location = new System.Drawing.Point(315, 12);
      this.bAnim2.Name = "bAnim2";
      this.bAnim2.Size = new System.Drawing.Size(118, 31);
      this.bAnim2.TabIndex = 59;
      this.bAnim2.Text = "After 2nd SFX/Anim";
      this.bAnim2.UseVisualStyleBackColor = true;
      this.bAnim2.Click += new System.EventHandler(this.bAnim2_Click);
      // 
      // bAnim3
      // 
      this.bAnim3.Location = new System.Drawing.Point(439, 12);
      this.bAnim3.Name = "bAnim3";
      this.bAnim3.Size = new System.Drawing.Size(118, 31);
      this.bAnim3.TabIndex = 60;
      this.bAnim3.Text = "After 3rd SFX/Anim";
      this.bAnim3.UseVisualStyleBackColor = true;
      this.bAnim3.Click += new System.EventHandler(this.bAnim3_Click);
      // 
      // cRegionPanel
      // 
      this.cRegionPanel.Direction1 = -1;
      this.cRegionPanel.Direction2 = -1;
      this.cRegionPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.cRegionPanel.Icon1X = 0;
      this.cRegionPanel.Icon1Y = 0;
      this.cRegionPanel.Icon2X = 0;
      this.cRegionPanel.Icon2Y = 0;
      this.cRegionPanel.Location = new System.Drawing.Point(0, 50);
      this.cRegionPanel.MissionFile1 = "";
      this.cRegionPanel.MissionFile2 = "";
      this.cRegionPanel.Name = "cRegionPanel";
      this.cRegionPanel.RegionID1 = ((byte)(0));
      this.cRegionPanel.RegionID2 = ((byte)(0));
      this.cRegionPanel.Size = new System.Drawing.Size(960, 182);
      this.cRegionPanel.TabIndex = 55;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.llblPreview);
      this.panel3.Controls.Add(this.llblCommon);
      this.panel3.Controls.Add(this.llblRegion);
      this.panel3.Controls.Add(this.cbHouse);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.cbScenario);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(960, 50);
      this.panel3.TabIndex = 62;
      // 
      // llblPreview
      // 
      this.llblPreview.AutoSize = true;
      this.llblPreview.Location = new System.Drawing.Point(312, 30);
      this.llblPreview.Name = "llblPreview";
      this.llblPreview.Size = new System.Drawing.Size(102, 13);
      this.llblPreview.TabIndex = 57;
      this.llblPreview.TabStop = true;
      this.llblPreview.Text = "Show/Hide Preview";
      this.llblPreview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPreview_LinkClicked);
      // 
      // llblCommon
      // 
      this.llblCommon.AutoSize = true;
      this.llblCommon.Location = new System.Drawing.Point(188, 30);
      this.llblCommon.Name = "llblCommon";
      this.llblCommon.Size = new System.Drawing.Size(105, 13);
      this.llblCommon.TabIndex = 56;
      this.llblCommon.TabStop = true;
      this.llblCommon.Text = "Show/Hide Common";
      this.llblCommon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCommon_LinkClicked);
      // 
      // llblRegion
      // 
      this.llblRegion.AutoSize = true;
      this.llblRegion.Location = new System.Drawing.Point(66, 30);
      this.llblRegion.Name = "llblRegion";
      this.llblRegion.Size = new System.Drawing.Size(103, 13);
      this.llblRegion.TabIndex = 55;
      this.llblRegion.TabStop = true;
      this.llblRegion.Text = "Show/Hide Regions";
      this.llblRegion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRegion_LinkClicked);
      // 
      // cbHouse
      // 
      this.cbHouse.FormattingEnabled = true;
      this.cbHouse.Location = new System.Drawing.Point(67, 6);
      this.cbHouse.Name = "cbHouse";
      this.cbHouse.Size = new System.Drawing.Size(201, 21);
      this.cbHouse.TabIndex = 0;
      this.cbHouse.SelectedIndexChanged += new System.EventHandler(this.cbHouse_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "House";
      // 
      // cbScenario
      // 
      this.cbScenario.FormattingEnabled = true;
      this.cbScenario.Location = new System.Drawing.Point(379, 6);
      this.cbScenario.Name = "cbScenario";
      this.cbScenario.Size = new System.Drawing.Size(288, 21);
      this.cbScenario.TabIndex = 2;
      this.cbScenario.SelectedIndexChanged += new System.EventHandler(this.cbScenario_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(274, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(99, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Campaign Scenario";
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Gainsboro;
      this.panel2.Controls.Add(this.label22);
      this.panel2.Controls.Add(this.label23);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(960, 60);
      this.panel2.TabIndex = 53;
      // 
      // label22
      // 
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
      this.label22.Location = new System.Drawing.Point(3, 7);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(179, 30);
      this.label22.TabIndex = 1;
      this.label22.Text = "Campaign UI Binary";
      // 
      // label23
      // 
      this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label23.Location = new System.Drawing.Point(188, 7);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(769, 50);
      this.label23.TabIndex = 0;
      this.label23.Text = resources.GetString("label23.Text");
      // 
      // cCommonPanel
      // 
      this.cCommonPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.cCommonPanel.EnemyHouse = -1;
      this.cCommonPanel.Location = new System.Drawing.Point(0, 232);
      this.cCommonPanel.Name = "cCommonPanel";
      this.cCommonPanel.RegionAnim_House1 = -1;
      this.cCommonPanel.RegionAnim_House2 = -1;
      this.cCommonPanel.RegionAnim_House3 = -1;
      this.cCommonPanel.RegionToAtreides1 = ((byte)(0));
      this.cCommonPanel.RegionToAtreides2 = ((byte)(0));
      this.cCommonPanel.RegionToAtreides3 = ((byte)(0));
      this.cCommonPanel.RegionToHarkonnen1 = ((byte)(0));
      this.cCommonPanel.RegionToHarkonnen2 = ((byte)(0));
      this.cCommonPanel.RegionToHarkonnen3 = ((byte)(0));
      this.cCommonPanel.RegionToOrdos1 = ((byte)(0));
      this.cCommonPanel.RegionToOrdos2 = ((byte)(0));
      this.cCommonPanel.RegionToOrdos3 = ((byte)(0));
      this.cCommonPanel.ScoreMultiplier = 0F;
      this.cCommonPanel.SFX1 = "";
      this.cCommonPanel.SFX2 = "";
      this.cCommonPanel.SFX3 = "";
      this.cCommonPanel.Size = new System.Drawing.Size(960, 315);
      this.cCommonPanel.TabIndex = 54;
      this.cCommonPanel.Theme = "";
      // 
      // ucCampaignUibEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucCampaignUibEditor";
      this.Size = new System.Drawing.Size(960, 1155);
      this.panel1.ResumeLayout(false);
      this.pPreview.ResumeLayout(false);
      this.pPreview.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbScenario;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbHouse;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Button bFinal;
    private System.Windows.Forms.Button bAnim3;
    private System.Windows.Forms.Button bAnim2;
    private System.Windows.Forms.Button bAnim1;
    private System.Windows.Forms.Button bBefAnim;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.PictureBox pbPreview;
    private System.Windows.Forms.Panel pPreview;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.LinkLabel llblPreview;
    private System.Windows.Forms.LinkLabel llblCommon;
    private System.Windows.Forms.LinkLabel llblRegion;
    private CampaignRegionPanel cRegionPanel;
    private CampaignCommonPanel cCommonPanel;
  }
}
