namespace Dune2000.Editor.UI.Editors.Resources
{
  partial class ExportDataResourceForm
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
      this.lboxItems = new System.Windows.Forms.ListBox();
      this.tbFilepath = new System.Windows.Forms.TextBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bFilepath = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.gEntries = new System.Windows.Forms.GroupBox();
      this.cboxHousePal = new System.Windows.Forms.CheckBox();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.cbTransparency = new System.Windows.Forms.CheckBox();
      this.pbPreview = new Dune2000.Editor.UI.Objects.ResourcePreview();
      this.cbSelectAll = new System.Windows.Forms.CheckBox();
      this.sfdExport = new System.Windows.Forms.SaveFileDialog();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblProgress = new System.Windows.Forms.Label();
      this.pbarProgress = new System.Windows.Forms.ProgressBar();
      this.gEntries.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
      this.SuspendLayout();
      // 
      // lboxItems
      // 
      this.lboxItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lboxItems.FormattingEnabled = true;
      this.lboxItems.Location = new System.Drawing.Point(3, 16);
      this.lboxItems.Name = "lboxItems";
      this.lboxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.lboxItems.Size = new System.Drawing.Size(183, 292);
      this.lboxItems.TabIndex = 58;
      this.lboxItems.SelectedIndexChanged += new System.EventHandler(this.lboxItems_SelectedIndexChanged);
      // 
      // tbFilepath
      // 
      this.tbFilepath.Location = new System.Drawing.Point(100, 19);
      this.tbFilepath.Name = "tbFilepath";
      this.tbFilepath.Size = new System.Drawing.Size(459, 20);
      this.tbFilepath.TabIndex = 60;
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(454, 395);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(76, 34);
      this.bOK.TabIndex = 61;
      this.bOK.Text = "Begin Export";
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bFilepath
      // 
      this.bFilepath.Location = new System.Drawing.Point(565, 19);
      this.bFilepath.Name = "bFilepath";
      this.bFilepath.Size = new System.Drawing.Size(47, 20);
      this.bFilepath.TabIndex = 62;
      this.bFilepath.Text = "...";
      this.bFilepath.UseVisualStyleBackColor = true;
      this.bFilepath.Click += new System.EventHandler(this.bFilepath_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(68, 13);
      this.label1.TabIndex = 63;
      this.label1.Text = "Export to File";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(536, 395);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(76, 34);
      this.button1.TabIndex = 65;
      this.button1.Text = "Close";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.bClose_Click);
      // 
      // gEntries
      // 
      this.gEntries.Controls.Add(this.lboxItems);
      this.gEntries.Location = new System.Drawing.Point(15, 77);
      this.gEntries.Name = "gEntries";
      this.gEntries.Size = new System.Drawing.Size(189, 311);
      this.gEntries.TabIndex = 66;
      this.gEntries.TabStop = false;
      this.gEntries.Text = "Entries";
      // 
      // cboxHousePal
      // 
      this.cboxHousePal.AutoSize = true;
      this.cboxHousePal.Location = new System.Drawing.Point(258, 104);
      this.cboxHousePal.Name = "cboxHousePal";
      this.cboxHousePal.Size = new System.Drawing.Size(93, 17);
      this.cboxHousePal.TabIndex = 73;
      this.cboxHousePal.Text = "House Palette";
      this.cboxHousePal.UseVisualStyleBackColor = true;
      this.cboxHousePal.CheckedChanged += new System.EventHandler(this.cboxHousePal_CheckedChanged);
      // 
      // cbHouse
      // 
      this.cbHouse.Enabled = false;
      this.cbHouse.FormattingEnabled = true;
      this.cbHouse.Location = new System.Drawing.Point(357, 102);
      this.cbHouse.Name = "cbHouse";
      this.cbHouse.Size = new System.Drawing.Size(127, 21);
      this.cbHouse.TabIndex = 72;
      this.cbHouse.SelectedIndexChanged += new System.EventHandler(this.cbHouse_SelectedIndexChanged);
      // 
      // cbTransparency
      // 
      this.cbTransparency.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbTransparency.AutoSize = true;
      this.cbTransparency.Location = new System.Drawing.Point(490, 100);
      this.cbTransparency.Name = "cbTransparency";
      this.cbTransparency.Size = new System.Drawing.Size(112, 23);
      this.cbTransparency.TabIndex = 75;
      this.cbTransparency.Text = "Show Transparency";
      this.cbTransparency.UseVisualStyleBackColor = true;
      this.cbTransparency.CheckedChanged += new System.EventHandler(this.cbTransparency_CheckedChanged);
      // 
      // pbPreview
      // 
      this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbPreview.BoundingBox = new System.Drawing.Rectangle(0, 0, 0, 0);
      this.pbPreview.DrawBoundingBox = false;
      this.pbPreview.FitToScreen = false;
      this.pbPreview.Location = new System.Drawing.Point(228, 129);
      this.pbPreview.Name = "pbPreview";
      this.pbPreview.Preview = null;
      this.pbPreview.Size = new System.Drawing.Size(256, 256);
      this.pbPreview.TabIndex = 59;
      this.pbPreview.TabStop = false;
      this.pbPreview.Zoom = 0F;
      // 
      // cbSelectAll
      // 
      this.cbSelectAll.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbSelectAll.AutoSize = true;
      this.cbSelectAll.Location = new System.Drawing.Point(18, 391);
      this.cbSelectAll.Name = "cbSelectAll";
      this.cbSelectAll.Size = new System.Drawing.Size(61, 23);
      this.cbSelectAll.TabIndex = 70;
      this.cbSelectAll.Text = "Select All";
      this.cbSelectAll.UseVisualStyleBackColor = true;
      this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
      // 
      // sfdExport
      // 
      this.sfdExport.Filter = "Export file|*.ini";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(97, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(351, 13);
      this.label2.TabIndex = 76;
      this.label2.Text = "Exported images and palettes will be created relative to this file\'s location.";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(97, 61);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(496, 13);
      this.label3.TabIndex = 77;
      this.label3.Text = "Exported images will not be colored by the house palette. Use the Export Image(s)" +
    " option for this feature.";
      // 
      // lblProgress
      // 
      this.lblProgress.AutoSize = true;
      this.lblProgress.Location = new System.Drawing.Point(85, 401);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(10, 13);
      this.lblProgress.TabIndex = 82;
      this.lblProgress.Text = " ";
      // 
      // pbarProgress
      // 
      this.pbarProgress.Location = new System.Drawing.Point(88, 419);
      this.pbarProgress.Name = "pbarProgress";
      this.pbarProgress.Size = new System.Drawing.Size(360, 10);
      this.pbarProgress.TabIndex = 81;
      // 
      // ExportDataResourceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.Controls.Add(this.lblProgress);
      this.Controls.Add(this.pbarProgress);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbTransparency);
      this.Controls.Add(this.cboxHousePal);
      this.Controls.Add(this.cbHouse);
      this.Controls.Add(this.cbSelectAll);
      this.Controls.Add(this.gEntries);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bFilepath);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.tbFilepath);
      this.Controls.Add(this.pbPreview);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "ExportDataResourceForm";
      this.Text = "Dune 2000 Editor";
      this.gEntries.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Objects.ResourcePreview pbPreview;
    private System.Windows.Forms.ListBox lboxItems;
    private System.Windows.Forms.TextBox tbFilepath;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bFilepath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox gEntries;
    private System.Windows.Forms.CheckBox cboxHousePal;
    private System.Windows.Forms.ComboBox cbHouse;
    private System.Windows.Forms.CheckBox cbTransparency;
    private System.Windows.Forms.CheckBox cbSelectAll;
    private System.Windows.Forms.SaveFileDialog sfdExport;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.ProgressBar pbarProgress;
  }
}