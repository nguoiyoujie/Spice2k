namespace Dune2000.Editor.UI.Editors.Resources
{
  partial class ImportResourceForm
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
      this.bOK = new System.Windows.Forms.Button();
      this.bOpenImage = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.cboxHousePal = new System.Windows.Forms.CheckBox();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.cbTransparency = new System.Windows.Forms.CheckBox();
      this.bImportPalette = new System.Windows.Forms.Button();
      this.pbPalette = new Dune2000.Editor.UI.Objects.PaletteView();
      this.pbPreview = new Dune2000.Editor.UI.Objects.ResourcePreview();
      this.bBasePalette = new System.Windows.Forms.Button();
      this.bResetPalette = new System.Windows.Forms.Button();
      this.cb8Bit = new System.Windows.Forms.CheckBox();
      this.ofdImportPalette = new System.Windows.Forms.OpenFileDialog();
      this.ofdImage = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
      this.SuspendLayout();
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(454, 362);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(76, 34);
      this.bOK.TabIndex = 61;
      this.bOK.Text = "Apply";
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bOpenImage
      // 
      this.bOpenImage.Location = new System.Drawing.Point(24, 12);
      this.bOpenImage.Name = "bOpenImage";
      this.bOpenImage.Size = new System.Drawing.Size(118, 26);
      this.bOpenImage.TabIndex = 62;
      this.bOpenImage.Text = "Load Image";
      this.bOpenImage.UseVisualStyleBackColor = true;
      this.bOpenImage.Click += new System.EventHandler(this.bOpenImage_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(536, 362);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(76, 34);
      this.button1.TabIndex = 65;
      this.button1.Text = "Close";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.bClose_Click);
      // 
      // cboxHousePal
      // 
      this.cboxHousePal.AutoSize = true;
      this.cboxHousePal.Location = new System.Drawing.Point(24, 46);
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
      this.cbHouse.Location = new System.Drawing.Point(123, 44);
      this.cbHouse.Name = "cbHouse";
      this.cbHouse.Size = new System.Drawing.Size(127, 21);
      this.cbHouse.TabIndex = 72;
      this.cbHouse.SelectedIndexChanged += new System.EventHandler(this.cbHouse_SelectedIndexChanged);
      // 
      // cbTransparency
      // 
      this.cbTransparency.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbTransparency.AutoSize = true;
      this.cbTransparency.Location = new System.Drawing.Point(24, 71);
      this.cbTransparency.Name = "cbTransparency";
      this.cbTransparency.Size = new System.Drawing.Size(112, 23);
      this.cbTransparency.TabIndex = 75;
      this.cbTransparency.Text = "Show Transparency";
      this.cbTransparency.UseVisualStyleBackColor = true;
      this.cbTransparency.CheckedChanged += new System.EventHandler(this.cbTransparency_CheckedChanged);
      // 
      // bImportPalette
      // 
      this.bImportPalette.Location = new System.Drawing.Point(494, 12);
      this.bImportPalette.Name = "bImportPalette";
      this.bImportPalette.Size = new System.Drawing.Size(118, 26);
      this.bImportPalette.TabIndex = 77;
      this.bImportPalette.Text = "Load Palette";
      this.bImportPalette.UseVisualStyleBackColor = true;
      this.bImportPalette.Click += new System.EventHandler(this.bImportPalette_Click);
      // 
      // pbPalette
      // 
      this.pbPalette.Location = new System.Drawing.Point(356, 100);
      this.pbPalette.Name = "pbPalette";
      this.pbPalette.Palette = null;
      this.pbPalette.SelectedIndices = null;
      this.pbPalette.Size = new System.Drawing.Size(256, 256);
      this.pbPalette.TabIndex = 76;
      this.pbPalette.TabStop = false;
      // 
      // pbPreview
      // 
      this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbPreview.BoundingBox = new System.Drawing.Rectangle(0, 0, 0, 0);
      this.pbPreview.DrawBoundingBox = false;
      this.pbPreview.FitToScreen = false;
      this.pbPreview.Location = new System.Drawing.Point(24, 100);
      this.pbPreview.Name = "pbPreview";
      this.pbPreview.Preview = null;
      this.pbPreview.Size = new System.Drawing.Size(256, 256);
      this.pbPreview.TabIndex = 59;
      this.pbPreview.TabStop = false;
      this.pbPreview.Zoom = 0F;
      // 
      // bBasePalette
      // 
      this.bBasePalette.Location = new System.Drawing.Point(494, 68);
      this.bBasePalette.Name = "bBasePalette";
      this.bBasePalette.Size = new System.Drawing.Size(118, 26);
      this.bBasePalette.TabIndex = 78;
      this.bBasePalette.Text = "Use Base Palette";
      this.bBasePalette.UseVisualStyleBackColor = true;
      this.bBasePalette.Click += new System.EventHandler(this.bBasePalette_Click);
      // 
      // bResetPalette
      // 
      this.bResetPalette.Location = new System.Drawing.Point(494, 40);
      this.bResetPalette.Name = "bResetPalette";
      this.bResetPalette.Size = new System.Drawing.Size(118, 26);
      this.bResetPalette.TabIndex = 79;
      this.bResetPalette.Text = "Reset Palette";
      this.bResetPalette.UseVisualStyleBackColor = true;
      this.bResetPalette.Click += new System.EventHandler(this.bResetPalette_Click);
      // 
      // cb8Bit
      // 
      this.cb8Bit.Appearance = System.Windows.Forms.Appearance.Button;
      this.cb8Bit.AutoSize = true;
      this.cb8Bit.Location = new System.Drawing.Point(356, 12);
      this.cb8Bit.Name = "cb8Bit";
      this.cb8Bit.Size = new System.Drawing.Size(72, 23);
      this.cb8Bit.TabIndex = 80;
      this.cb8Bit.Text = "Use Palette";
      this.cb8Bit.UseVisualStyleBackColor = true;
      this.cb8Bit.CheckedChanged += new System.EventHandler(this.cb8Bit_CheckedChanged);
      // 
      // ofdImportPalette
      // 
      this.ofdImportPalette.Filter = "Dune 2000 bin file|*.bin|All files|*.*";
      // 
      // ofdImage
      // 
      this.ofdImage.Filter = "Image file|*.bmp;*.png;*.|All files|*.*";
      // 
      // ImportResourceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 409);
      this.Controls.Add(this.cb8Bit);
      this.Controls.Add(this.bResetPalette);
      this.Controls.Add(this.bBasePalette);
      this.Controls.Add(this.bImportPalette);
      this.Controls.Add(this.pbPalette);
      this.Controls.Add(this.cbTransparency);
      this.Controls.Add(this.cboxHousePal);
      this.Controls.Add(this.cbHouse);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.bOpenImage);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.pbPreview);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "ImportResourceForm";
      this.Text = "Dune 2000 Editor";
      ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Objects.ResourcePreview pbPreview;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bOpenImage;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox cboxHousePal;
    private System.Windows.Forms.ComboBox cbHouse;
    private System.Windows.Forms.CheckBox cbTransparency;
    private Objects.PaletteView pbPalette;
    private System.Windows.Forms.Button bImportPalette;
    private System.Windows.Forms.Button bBasePalette;
    private System.Windows.Forms.Button bResetPalette;
    private System.Windows.Forms.CheckBox cb8Bit;
    private System.Windows.Forms.OpenFileDialog ofdImportPalette;
    private System.Windows.Forms.OpenFileDialog ofdImage;
  }
}