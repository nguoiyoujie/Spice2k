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
      this.tcEditorTabs = new System.Windows.Forms.TabControl();
      this.tpTextUib = new System.Windows.Forms.TabPage();
      this.tpColourUib = new System.Windows.Forms.TabPage();
      this.tpMenuUib = new System.Windows.Forms.TabPage();
      this.tpCampaignUib = new System.Windows.Forms.TabPage();
      this.ucTextUibEditor1 = new Dune2000.Editor.UI.UserControls.ucTextUibEditor();
      this.ucColourUibEditor1 = new Dune2000.Editor.UI.UserControls.ucColourUibEditor();
      this.ucMenusUibEditor1 = new Dune2000.Editor.UI.UserControls.ucMenusUibEditor();
      this.ucCampaignUibEditor1 = new Dune2000.Editor.UI.UserControls.ucCampaignUibEditor();
      this.ucEditorController = new Dune2000.Editor.UI.UserControls.ucEditor();
      this.tpResource = new System.Windows.Forms.TabPage();
      this.ucResourceEditor1 = new Dune2000.Editor.UI.UserControls.ucResourceEditor();
      this.tcEditorTabs.SuspendLayout();
      this.tpTextUib.SuspendLayout();
      this.tpColourUib.SuspendLayout();
      this.tpMenuUib.SuspendLayout();
      this.tpCampaignUib.SuspendLayout();
      this.tpResource.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcEditorTabs
      // 
      this.tcEditorTabs.Controls.Add(this.tpTextUib);
      this.tcEditorTabs.Controls.Add(this.tpColourUib);
      this.tcEditorTabs.Controls.Add(this.tpMenuUib);
      this.tcEditorTabs.Controls.Add(this.tpCampaignUib);
      this.tcEditorTabs.Controls.Add(this.tpResource);
      this.tcEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcEditorTabs.Location = new System.Drawing.Point(0, 60);
      this.tcEditorTabs.Name = "tcEditorTabs";
      this.tcEditorTabs.SelectedIndex = 0;
      this.tcEditorTabs.Size = new System.Drawing.Size(961, 542);
      this.tcEditorTabs.TabIndex = 1;
      this.tcEditorTabs.SelectedIndexChanged += new System.EventHandler(this.tcEditorTabs_SelectedIndexChanged);
      // 
      // tpTextUib
      // 
      this.tpTextUib.Controls.Add(this.ucTextUibEditor1);
      this.tpTextUib.Location = new System.Drawing.Point(4, 22);
      this.tpTextUib.Name = "tpTextUib";
      this.tpTextUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpTextUib.Size = new System.Drawing.Size(953, 516);
      this.tpTextUib.TabIndex = 0;
      this.tpTextUib.Text = "Text Uib";
      this.tpTextUib.UseVisualStyleBackColor = true;
      // 
      // tpColourUib
      // 
      this.tpColourUib.Controls.Add(this.ucColourUibEditor1);
      this.tpColourUib.Location = new System.Drawing.Point(4, 22);
      this.tpColourUib.Name = "tpColourUib";
      this.tpColourUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpColourUib.Size = new System.Drawing.Size(953, 516);
      this.tpColourUib.TabIndex = 1;
      this.tpColourUib.Text = "Colour Uib";
      this.tpColourUib.UseVisualStyleBackColor = true;
      // 
      // tpMenuUib
      // 
      this.tpMenuUib.Controls.Add(this.ucMenusUibEditor1);
      this.tpMenuUib.Location = new System.Drawing.Point(4, 22);
      this.tpMenuUib.Name = "tpMenuUib";
      this.tpMenuUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpMenuUib.Size = new System.Drawing.Size(953, 516);
      this.tpMenuUib.TabIndex = 2;
      this.tpMenuUib.Text = "Menu Uib";
      this.tpMenuUib.UseVisualStyleBackColor = true;
      // 
      // tpCampaignUib
      // 
      this.tpCampaignUib.Controls.Add(this.ucCampaignUibEditor1);
      this.tpCampaignUib.Location = new System.Drawing.Point(4, 22);
      this.tpCampaignUib.Name = "tpCampaignUib";
      this.tpCampaignUib.Padding = new System.Windows.Forms.Padding(3);
      this.tpCampaignUib.Size = new System.Drawing.Size(953, 516);
      this.tpCampaignUib.TabIndex = 3;
      this.tpCampaignUib.Text = "Campaign Uib";
      this.tpCampaignUib.UseVisualStyleBackColor = true;
      // 
      // ucTextUibEditor1
      // 
      this.ucTextUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTextUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucTextUibEditor1.Name = "ucTextUibEditor1";
      this.ucTextUibEditor1.Size = new System.Drawing.Size(947, 510);
      this.ucTextUibEditor1.TabIndex = 1;
      // 
      // ucColourUibEditor1
      // 
      this.ucColourUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucColourUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucColourUibEditor1.Name = "ucColourUibEditor1";
      this.ucColourUibEditor1.Size = new System.Drawing.Size(947, 510);
      this.ucColourUibEditor1.TabIndex = 0;
      // 
      // ucMenusUibEditor1
      // 
      this.ucMenusUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMenusUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucMenusUibEditor1.Name = "ucMenusUibEditor1";
      this.ucMenusUibEditor1.Size = new System.Drawing.Size(947, 510);
      this.ucMenusUibEditor1.TabIndex = 0;
      // 
      // ucCampaignUibEditor1
      // 
      this.ucCampaignUibEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucCampaignUibEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucCampaignUibEditor1.Name = "ucCampaignUibEditor1";
      this.ucCampaignUibEditor1.Size = new System.Drawing.Size(947, 510);
      this.ucCampaignUibEditor1.TabIndex = 0;
      // 
      // ucEditorController
      // 
      this.ucEditorController.AutoSize = true;
      this.ucEditorController.Dock = System.Windows.Forms.DockStyle.Top;
      this.ucEditorController.Location = new System.Drawing.Point(0, 0);
      this.ucEditorController.Name = "ucEditorController";
      this.ucEditorController.Size = new System.Drawing.Size(961, 60);
      this.ucEditorController.TabIndex = 3;
      // 
      // tpResource
      // 
      this.tpResource.Controls.Add(this.ucResourceEditor1);
      this.tpResource.Location = new System.Drawing.Point(4, 22);
      this.tpResource.Name = "tpResource";
      this.tpResource.Padding = new System.Windows.Forms.Padding(3);
      this.tpResource.Size = new System.Drawing.Size(953, 516);
      this.tpResource.TabIndex = 4;
      this.tpResource.Text = "Resource";
      this.tpResource.UseVisualStyleBackColor = true;
      // 
      // ucResourceEditor1
      // 
      this.ucResourceEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucResourceEditor1.Location = new System.Drawing.Point(3, 3);
      this.ucResourceEditor1.Name = "ucResourceEditor1";
      this.ucResourceEditor1.Size = new System.Drawing.Size(947, 510);
      this.ucResourceEditor1.TabIndex = 0;
      // 
      // MainEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(961, 602);
      this.Controls.Add(this.tcEditorTabs);
      this.Controls.Add(this.ucEditorController);
      this.Name = "MainEditor";
      this.Text = "Dune 2000 Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
      this.tcEditorTabs.ResumeLayout(false);
      this.tpTextUib.ResumeLayout(false);
      this.tpColourUib.ResumeLayout(false);
      this.tpMenuUib.ResumeLayout(false);
      this.tpCampaignUib.ResumeLayout(false);
      this.tpResource.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TabControl tcEditorTabs;
    private System.Windows.Forms.TabPage tpTextUib;
    private System.Windows.Forms.TabPage tpColourUib;
    private UserControls.ucColourUibEditor ucColourUibEditor1;
    private System.Windows.Forms.TabPage tpMenuUib;
    private UserControls.ucMenusUibEditor ucMenusUibEditor1;
    private System.Windows.Forms.TabPage tpCampaignUib;
    private UserControls.ucCampaignUibEditor ucCampaignUibEditor1;
    private UserControls.ucTextUibEditor ucTextUibEditor1;
    private UserControls.ucEditor ucEditorController;
    private System.Windows.Forms.TabPage tpResource;
    private UserControls.ucResourceEditor ucResourceEditor1;
  }
}