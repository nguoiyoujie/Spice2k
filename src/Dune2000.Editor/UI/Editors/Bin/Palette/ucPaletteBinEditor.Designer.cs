namespace Dune2000.Editor.UI.Editors.Bin.Palette
{
  partial class ucPaletteBinEditor
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.pPreview = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.pbPalette = new Dune2000.Editor.UI.Objects.PaletteView();
      this.label1 = new System.Windows.Forms.Label();
      this.tbText = new System.Windows.Forms.TextBox();
      this.nudEnd = new System.Windows.Forms.NumericUpDown();
      this.bFromText = new System.Windows.Forms.Button();
      this.nudStart = new System.Windows.Forms.NumericUpDown();
      this.bToText = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.bImport = new System.Windows.Forms.Button();
      this.bExport = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.sfdExportPalette = new System.Windows.Forms.SaveFileDialog();
      this.ofdImportPalette = new System.Windows.Forms.OpenFileDialog();
      this.panel1.SuspendLayout();
      this.pPreview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pPreview);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(960, 648);
      this.panel1.TabIndex = 5;
      // 
      // pPreview
      // 
      this.pPreview.AutoScroll = true;
      this.pPreview.Controls.Add(this.label3);
      this.pPreview.Controls.Add(this.label2);
      this.pPreview.Controls.Add(this.pbPalette);
      this.pPreview.Controls.Add(this.label1);
      this.pPreview.Controls.Add(this.tbText);
      this.pPreview.Controls.Add(this.nudEnd);
      this.pPreview.Controls.Add(this.bFromText);
      this.pPreview.Controls.Add(this.nudStart);
      this.pPreview.Controls.Add(this.bToText);
      this.pPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pPreview.Location = new System.Drawing.Point(0, 35);
      this.pPreview.Name = "pPreview";
      this.pPreview.Size = new System.Drawing.Size(960, 613);
      this.pPreview.TabIndex = 65;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(713, 24);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(54, 13);
      this.label3.TabIndex = 80;
      this.label3.Text = "(inclusive)";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(560, 6);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 13);
      this.label2.TabIndex = 79;
      this.label2.Text = "Copy as Text";
      // 
      // pbPalette
      // 
      this.pbPalette.BackColor = System.Drawing.Color.Black;
      this.pbPalette.Location = new System.Drawing.Point(7, 6);
      this.pbPalette.Name = "pbPalette";
      this.pbPalette.Palette = null;
      this.pbPalette.SelectedIndices = null;
      this.pbPalette.Size = new System.Drawing.Size(512, 512);
      this.pbPalette.TabIndex = 72;
      this.pbPalette.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(627, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(16, 13);
      this.label1.TabIndex = 78;
      this.label1.Text = "to";
      // 
      // tbText
      // 
      this.tbText.Location = new System.Drawing.Point(563, 48);
      this.tbText.Multiline = true;
      this.tbText.Name = "tbText";
      this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbText.Size = new System.Drawing.Size(213, 470);
      this.tbText.TabIndex = 73;
      // 
      // nudEnd
      // 
      this.nudEnd.Location = new System.Drawing.Point(649, 22);
      this.nudEnd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudEnd.Name = "nudEnd";
      this.nudEnd.Size = new System.Drawing.Size(58, 20);
      this.nudEnd.TabIndex = 77;
      this.nudEnd.ValueChanged += new System.EventHandler(this.nudEnd_ValueChanged);
      // 
      // bFromText
      // 
      this.bFromText.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Left_32x32;
      this.bFromText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bFromText.Location = new System.Drawing.Point(525, 86);
      this.bFromText.Name = "bFromText";
      this.bFromText.Size = new System.Drawing.Size(32, 32);
      this.bFromText.TabIndex = 75;
      this.bFromText.Click += new System.EventHandler(this.bFromText_Click);
      // 
      // nudStart
      // 
      this.nudStart.Location = new System.Drawing.Point(563, 22);
      this.nudStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudStart.Name = "nudStart";
      this.nudStart.Size = new System.Drawing.Size(58, 20);
      this.nudStart.TabIndex = 76;
      this.nudStart.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
      // 
      // bToText
      // 
      this.bToText.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Right_32x32;
      this.bToText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bToText.Location = new System.Drawing.Point(525, 48);
      this.bToText.Name = "bToText";
      this.bToText.Size = new System.Drawing.Size(32, 32);
      this.bToText.TabIndex = 74;
      this.bToText.Click += new System.EventHandler(this.bToText_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.bImport);
      this.panel3.Controls.Add(this.bExport);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(960, 35);
      this.panel3.TabIndex = 62;
      // 
      // bImport
      // 
      this.bImport.Dock = System.Windows.Forms.DockStyle.Left;
      this.bImport.Location = new System.Drawing.Point(100, 0);
      this.bImport.Name = "bImport";
      this.bImport.Size = new System.Drawing.Size(100, 35);
      this.bImport.TabIndex = 58;
      this.bImport.Text = "Import from Image";
      this.bImport.UseVisualStyleBackColor = true;
      this.bImport.Click += new System.EventHandler(this.bImport_Click);
      // 
      // bExport
      // 
      this.bExport.Dock = System.Windows.Forms.DockStyle.Left;
      this.bExport.Location = new System.Drawing.Point(0, 0);
      this.bExport.Name = "bExport";
      this.bExport.Size = new System.Drawing.Size(100, 35);
      this.bExport.TabIndex = 57;
      this.bExport.Text = "Export to Image";
      this.bExport.UseVisualStyleBackColor = true;
      this.bExport.Click += new System.EventHandler(this.bExport_Click);
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
      this.label22.Text = "Palette Binary";
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
      this.label23.Text = "The base palette file (PALETTE.BIN) stores 256 colors for the game to render 8-bi" +
    "t images. The color data in this binary is the 24-bit True Color format.";
      // 
      // sfdExportPalette
      // 
      this.sfdExportPalette.Filter = "Bitmap file|*.bmp|Portable Network Graphics file|*.png|All files|*.*";
      // 
      // ofdImportPalette
      // 
      this.ofdImportPalette.Filter = "Bitmap file|*.bmp|Portable Network Graphics file|*.png|All files|*.*";
      // 
      // ucPaletteBinEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucPaletteBinEditor";
      this.Size = new System.Drawing.Size(960, 708);
      this.panel1.ResumeLayout(false);
      this.pPreview.ResumeLayout(false);
      this.pPreview.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Button bExport;
    private System.Windows.Forms.Panel pPreview;
    private System.Windows.Forms.Panel panel3;
    private Objects.PaletteView pbPalette;
    private System.Windows.Forms.SaveFileDialog sfdExportPalette;
    private System.Windows.Forms.OpenFileDialog ofdImportPalette;
    private System.Windows.Forms.TextBox tbText;
    private System.Windows.Forms.Button bImport;
    private System.Windows.Forms.Button bToText;
    private System.Windows.Forms.Button bFromText;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown nudEnd;
    private System.Windows.Forms.NumericUpDown nudStart;
    private System.Windows.Forms.Label label3;
  }
}
