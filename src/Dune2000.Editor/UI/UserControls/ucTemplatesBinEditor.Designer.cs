namespace Dune2000.Editor.UI.UserControls
{
  partial class ucTemplatesBinEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemplatesBinEditor));
      this.panel1 = new System.Windows.Forms.Panel();
      this.pEditable = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbScenario = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.lblSound = new System.Windows.Forms.Label();
      this.bSound = new System.Windows.Forms.Button();
      this.panel5 = new System.Windows.Forms.Panel();
      this.lblResource = new System.Windows.Forms.Label();
      this.bLinkResource = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pEditable);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel4);
      this.panel1.Controls.Add(this.panel5);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 127);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(960, 466);
      this.panel1.TabIndex = 5;
      // 
      // pEditable
      // 
      this.pEditable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pEditable.Location = new System.Drawing.Point(0, 100);
      this.pEditable.Name = "pEditable";
      this.pEditable.Size = new System.Drawing.Size(960, 366);
      this.pEditable.TabIndex = 63;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.cbHouse);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.cbScenario);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 50);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(960, 50);
      this.panel3.TabIndex = 62;
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
      this.label1.Location = new System.Drawing.Point(18, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Section";
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
      // panel4
      // 
      this.panel4.Controls.Add(this.lblSound);
      this.panel4.Controls.Add(this.bSound);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(0, 25);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(960, 25);
      this.panel4.TabIndex = 65;
      // 
      // lblSound
      // 
      this.lblSound.AutoSize = true;
      this.lblSound.Location = new System.Drawing.Point(209, 6);
      this.lblSound.Name = "lblSound";
      this.lblSound.Size = new System.Drawing.Size(58, 13);
      this.lblSound.TabIndex = 1;
      this.lblSound.Text = "(no file set)";
      // 
      // bSound
      // 
      this.bSound.Dock = System.Windows.Forms.DockStyle.Left;
      this.bSound.Location = new System.Drawing.Point(0, 0);
      this.bSound.Name = "bSound";
      this.bSound.Size = new System.Drawing.Size(200, 25);
      this.bSound.TabIndex = 0;
      this.bSound.Text = "Link Sound Sample UI Block File";
      this.bSound.UseVisualStyleBackColor = true;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.lblResource);
      this.panel5.Controls.Add(this.bLinkResource);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel5.Location = new System.Drawing.Point(0, 0);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(960, 25);
      this.panel5.TabIndex = 64;
      // 
      // lblResource
      // 
      this.lblResource.AutoSize = true;
      this.lblResource.Location = new System.Drawing.Point(209, 6);
      this.lblResource.Name = "lblResource";
      this.lblResource.Size = new System.Drawing.Size(58, 13);
      this.lblResource.TabIndex = 1;
      this.lblResource.Text = "(no file set)";
      // 
      // bLinkResource
      // 
      this.bLinkResource.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLinkResource.Location = new System.Drawing.Point(0, 0);
      this.bLinkResource.Name = "bLinkResource";
      this.bLinkResource.Size = new System.Drawing.Size(200, 25);
      this.bLinkResource.TabIndex = 0;
      this.bLinkResource.Text = "Link Resource File";
      this.bLinkResource.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Gainsboro;
      this.panel2.Controls.Add(this.label22);
      this.panel2.Controls.Add(this.label23);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 67);
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
      this.label22.Text = "Templates Binary";
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
      // ucTemplatesBinEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucTemplatesBinEditor";
      this.Size = new System.Drawing.Size(960, 593);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.Panel pEditable;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label lblSound;
    private System.Windows.Forms.Button bSound;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Label lblResource;
    private System.Windows.Forms.Button bLinkResource;
  }
}
