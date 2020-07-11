namespace Dune2000.Editor.UI.Editors.Resources
{
  partial class ExportResourceForm
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
      this.tbDirectory = new System.Windows.Forms.TextBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bDirectory = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.gEntries = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbFormat = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbSelectAll = new System.Windows.Forms.CheckBox();
      this.lblFormat = new System.Windows.Forms.Label();
      this.fbdExport = new System.Windows.Forms.FolderBrowserDialog();
      this.cboxHousePal = new System.Windows.Forms.CheckBox();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.cbTransparency = new System.Windows.Forms.CheckBox();
      this.pbPreview = new Dune2000.Editor.UI.Objects.ResourcePreview();
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
      // tbDirectory
      // 
      this.tbDirectory.Location = new System.Drawing.Point(100, 19);
      this.tbDirectory.Name = "tbDirectory";
      this.tbDirectory.Size = new System.Drawing.Size(459, 20);
      this.tbDirectory.TabIndex = 60;
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
      // bDirectory
      // 
      this.bDirectory.Location = new System.Drawing.Point(565, 19);
      this.bDirectory.Name = "bDirectory";
      this.bDirectory.Size = new System.Drawing.Size(47, 20);
      this.bDirectory.TabIndex = 62;
      this.bDirectory.Text = "...";
      this.bDirectory.UseVisualStyleBackColor = true;
      this.bDirectory.Click += new System.EventHandler(this.bDirectory_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 13);
      this.label1.TabIndex = 63;
      this.label1.Text = "Export Directory";
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(225, 68);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 67;
      this.label2.Text = "Export As:";
      // 
      // tbFormat
      // 
      this.tbFormat.Location = new System.Drawing.Point(131, 45);
      this.tbFormat.MaxLength = 100;
      this.tbFormat.Name = "tbFormat";
      this.tbFormat.Size = new System.Drawing.Size(428, 20);
      this.tbFormat.TabIndex = 68;
      this.tbFormat.Text = "image_{0:0000}.png";
      this.tbFormat.TextChanged += new System.EventHandler(this.tbFormat_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 48);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(91, 13);
      this.label3.TabIndex = 69;
      this.label3.Text = "File Name Pattern";
      // 
      // cbSelectAll
      // 
      this.cbSelectAll.AutoSize = true;
      this.cbSelectAll.Location = new System.Drawing.Point(18, 394);
      this.cbSelectAll.Name = "cbSelectAll";
      this.cbSelectAll.Size = new System.Drawing.Size(70, 17);
      this.cbSelectAll.TabIndex = 70;
      this.cbSelectAll.Text = "Export All";
      this.cbSelectAll.ThreeState = true;
      this.cbSelectAll.UseVisualStyleBackColor = true;
      this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
      // 
      // lblFormat
      // 
      this.lblFormat.Location = new System.Drawing.Point(286, 68);
      this.lblFormat.Name = "lblFormat";
      this.lblFormat.Size = new System.Drawing.Size(335, 13);
      this.lblFormat.TabIndex = 71;
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
      // ExportResourceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.Controls.Add(this.cbTransparency);
      this.Controls.Add(this.cboxHousePal);
      this.Controls.Add(this.cbHouse);
      this.Controls.Add(this.lblFormat);
      this.Controls.Add(this.cbSelectAll);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tbFormat);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.gEntries);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bDirectory);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.tbDirectory);
      this.Controls.Add(this.pbPreview);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "ExportResourceForm";
      this.Text = "Dune 2000 Editor";
      this.gEntries.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Objects.ResourcePreview pbPreview;
    private System.Windows.Forms.ListBox lboxItems;
    private System.Windows.Forms.TextBox tbDirectory;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bDirectory;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox gEntries;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbFormat;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox cbSelectAll;
    private System.Windows.Forms.Label lblFormat;
    private System.Windows.Forms.FolderBrowserDialog fbdExport;
    private System.Windows.Forms.CheckBox cboxHousePal;
    private System.Windows.Forms.ComboBox cbHouse;
    private System.Windows.Forms.CheckBox cbTransparency;
  }
}