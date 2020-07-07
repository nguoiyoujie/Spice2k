namespace Dune2000.Editor.UI.UserControls
{
  partial class ucResourceEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucResourceEditor));
      this.panel1 = new System.Windows.Forms.Panel();
      this.pPreview = new System.Windows.Forms.Panel();
      this.gImage = new System.Windows.Forms.GroupBox();
      this.pbPreview = new Dune2000.Editor.UI.Objects.ResourcePreview();
      this.panel8 = new System.Windows.Forms.Panel();
      this.cbTransparency = new System.Windows.Forms.CheckBox();
      this.cbFrame = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.nudZoom = new System.Windows.Forms.NumericUpDown();
      this.cbFitToScreen = new System.Windows.Forms.CheckBox();
      this.cboxHousePal = new System.Windows.Forms.CheckBox();
      this.cbHouse = new System.Windows.Forms.ComboBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.gInfo = new System.Windows.Forms.GroupBox();
      this.bPalette = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.tbPalHandle = new System.Windows.Forms.TextBox();
      this.tbImageHandle = new System.Windows.Forms.TextBox();
      this.tbAlignment = new System.Windows.Forms.TextBox();
      this.tbBitsPerPixel = new System.Windows.Forms.TextBox();
      this.tbImageOffset = new System.Windows.Forms.TextBox();
      this.tbFrameSize = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.tbImageSize = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.tbType = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.pRegion = new System.Windows.Forms.Panel();
      this.gEntries = new System.Windows.Forms.GroupBox();
      this.lboxItems = new System.Windows.Forms.ListBox();
      this.panel7 = new System.Windows.Forms.Panel();
      this.bMoveDown = new System.Windows.Forms.Button();
      this.bMoveUp = new System.Windows.Forms.Button();
      this.bRemove = new System.Windows.Forms.Button();
      this.bAdd = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.bExportEntries = new System.Windows.Forms.Button();
      this.bExportAll = new System.Windows.Forms.Button();
      this.panel6 = new System.Windows.Forms.Panel();
      this.lblHouseColor = new System.Windows.Forms.Label();
      this.bLinkHouseColor = new System.Windows.Forms.Button();
      this.panel5 = new System.Windows.Forms.Panel();
      this.lblPalette = new System.Windows.Forms.Label();
      this.bLinkPalette = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.ofdPalette = new System.Windows.Forms.OpenFileDialog();
      this.ofdHousePalette = new System.Windows.Forms.OpenFileDialog();
      this.panel1.SuspendLayout();
      this.pPreview.SuspendLayout();
      this.gImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
      this.panel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
      this.panel4.SuspendLayout();
      this.gInfo.SuspendLayout();
      this.pRegion.SuspendLayout();
      this.gEntries.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel6.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pPreview);
      this.panel1.Controls.Add(this.panel4);
      this.panel1.Controls.Add(this.pRegion);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel6);
      this.panel1.Controls.Add(this.panel5);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(960, 648);
      this.panel1.TabIndex = 5;
      // 
      // pPreview
      // 
      this.pPreview.Controls.Add(this.gImage);
      this.pPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pPreview.Location = new System.Drawing.Point(150, 85);
      this.pPreview.Name = "pPreview";
      this.pPreview.Size = new System.Drawing.Size(570, 563);
      this.pPreview.TabIndex = 65;
      // 
      // gImage
      // 
      this.gImage.Controls.Add(this.pbPreview);
      this.gImage.Controls.Add(this.panel8);
      this.gImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gImage.Location = new System.Drawing.Point(0, 0);
      this.gImage.MinimumSize = new System.Drawing.Size(570, 100);
      this.gImage.Name = "gImage";
      this.gImage.Size = new System.Drawing.Size(570, 563);
      this.gImage.TabIndex = 59;
      this.gImage.TabStop = false;
      this.gImage.Text = "Entry Image";
      // 
      // pbPreview
      // 
      this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbPreview.BoundingBox = new System.Drawing.Rectangle(0, 0, 0, 0);
      this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pbPreview.DrawBoundingBox = false;
      this.pbPreview.FitToScreen = false;
      this.pbPreview.Location = new System.Drawing.Point(3, 74);
      this.pbPreview.Name = "pbPreview";
      this.pbPreview.Preview = null;
      this.pbPreview.Size = new System.Drawing.Size(564, 486);
      this.pbPreview.TabIndex = 57;
      this.pbPreview.TabStop = false;
      this.pbPreview.Zoom = 0F;
      // 
      // panel8
      // 
      this.panel8.Controls.Add(this.cbTransparency);
      this.panel8.Controls.Add(this.cbFrame);
      this.panel8.Controls.Add(this.label1);
      this.panel8.Controls.Add(this.nudZoom);
      this.panel8.Controls.Add(this.cbFitToScreen);
      this.panel8.Controls.Add(this.cboxHousePal);
      this.panel8.Controls.Add(this.cbHouse);
      this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel8.Location = new System.Drawing.Point(3, 16);
      this.panel8.Name = "panel8";
      this.panel8.Size = new System.Drawing.Size(564, 58);
      this.panel8.TabIndex = 56;
      // 
      // cbTransparency
      // 
      this.cbTransparency.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbTransparency.AutoSize = true;
      this.cbTransparency.Location = new System.Drawing.Point(411, 5);
      this.cbTransparency.Name = "cbTransparency";
      this.cbTransparency.Size = new System.Drawing.Size(112, 23);
      this.cbTransparency.TabIndex = 74;
      this.cbTransparency.Text = "Show Transparency";
      this.cbTransparency.UseVisualStyleBackColor = true;
      this.cbTransparency.CheckedChanged += new System.EventHandler(this.cbTransparency_CheckedChanged);
      // 
      // cbFrame
      // 
      this.cbFrame.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbFrame.AutoSize = true;
      this.cbFrame.Location = new System.Drawing.Point(329, 5);
      this.cbFrame.Name = "cbFrame";
      this.cbFrame.Size = new System.Drawing.Size(76, 23);
      this.cbFrame.TabIndex = 73;
      this.cbFrame.Text = "Show Frame";
      this.cbFrame.UseVisualStyleBackColor = true;
      this.cbFrame.CheckedChanged += new System.EventHandler(this.cbFrame_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(108, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 72;
      this.label1.Text = "Zoom";
      // 
      // nudZoom
      // 
      this.nudZoom.Location = new System.Drawing.Point(148, 33);
      this.nudZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoom.Name = "nudZoom";
      this.nudZoom.Size = new System.Drawing.Size(89, 20);
      this.nudZoom.TabIndex = 71;
      this.nudZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoom.ValueChanged += new System.EventHandler(this.nudZoom_ValueChanged);
      // 
      // cbFitToScreen
      // 
      this.cbFitToScreen.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbFitToScreen.AutoSize = true;
      this.cbFitToScreen.Location = new System.Drawing.Point(244, 5);
      this.cbFitToScreen.Name = "cbFitToScreen";
      this.cbFitToScreen.Size = new System.Drawing.Size(81, 23);
      this.cbFitToScreen.TabIndex = 70;
      this.cbFitToScreen.Text = "Fit To Screen";
      this.cbFitToScreen.UseVisualStyleBackColor = true;
      this.cbFitToScreen.CheckedChanged += new System.EventHandler(this.cbFitToScreen_CheckedChanged);
      // 
      // cboxHousePal
      // 
      this.cboxHousePal.AutoSize = true;
      this.cboxHousePal.Location = new System.Drawing.Point(12, 9);
      this.cboxHousePal.Name = "cboxHousePal";
      this.cboxHousePal.Size = new System.Drawing.Size(93, 17);
      this.cboxHousePal.TabIndex = 69;
      this.cboxHousePal.Text = "House Palette";
      this.cboxHousePal.UseVisualStyleBackColor = true;
      this.cboxHousePal.CheckedChanged += new System.EventHandler(this.cboxHousePal_CheckedChanged);
      // 
      // cbHouse
      // 
      this.cbHouse.Enabled = false;
      this.cbHouse.FormattingEnabled = true;
      this.cbHouse.Location = new System.Drawing.Point(111, 7);
      this.cbHouse.Name = "cbHouse";
      this.cbHouse.Size = new System.Drawing.Size(127, 21);
      this.cbHouse.TabIndex = 66;
      this.cbHouse.SelectedIndexChanged += new System.EventHandler(this.cbHouse_SelectedIndexChanged);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.gInfo);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel4.Location = new System.Drawing.Point(720, 85);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(240, 563);
      this.panel4.TabIndex = 64;
      // 
      // gInfo
      // 
      this.gInfo.Controls.Add(this.bPalette);
      this.gInfo.Controls.Add(this.label3);
      this.gInfo.Controls.Add(this.tbPalHandle);
      this.gInfo.Controls.Add(this.tbImageHandle);
      this.gInfo.Controls.Add(this.tbAlignment);
      this.gInfo.Controls.Add(this.tbBitsPerPixel);
      this.gInfo.Controls.Add(this.tbImageOffset);
      this.gInfo.Controls.Add(this.tbFrameSize);
      this.gInfo.Controls.Add(this.label9);
      this.gInfo.Controls.Add(this.tbImageSize);
      this.gInfo.Controls.Add(this.label8);
      this.gInfo.Controls.Add(this.label7);
      this.gInfo.Controls.Add(this.label6);
      this.gInfo.Controls.Add(this.label5);
      this.gInfo.Controls.Add(this.label4);
      this.gInfo.Controls.Add(this.tbType);
      this.gInfo.Controls.Add(this.label2);
      this.gInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gInfo.Location = new System.Drawing.Point(0, 0);
      this.gInfo.Name = "gInfo";
      this.gInfo.Size = new System.Drawing.Size(240, 563);
      this.gInfo.TabIndex = 58;
      this.gInfo.TabStop = false;
      this.gInfo.Text = "Entry Details";
      // 
      // bPalette
      // 
      this.bPalette.Enabled = false;
      this.bPalette.Location = new System.Drawing.Point(108, 255);
      this.bPalette.Name = "bPalette";
      this.bPalette.Size = new System.Drawing.Size(100, 35);
      this.bPalette.TabIndex = 71;
      this.bPalette.Text = "Inspect Palette";
      this.bPalette.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(25, 232);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(77, 13);
      this.label3.TabIndex = 70;
      this.label3.Text = "Palette Handle";
      // 
      // tbPalHandle
      // 
      this.tbPalHandle.Location = new System.Drawing.Point(108, 229);
      this.tbPalHandle.Name = "tbPalHandle";
      this.tbPalHandle.ReadOnly = true;
      this.tbPalHandle.Size = new System.Drawing.Size(100, 20);
      this.tbPalHandle.TabIndex = 69;
      // 
      // tbImageHandle
      // 
      this.tbImageHandle.Location = new System.Drawing.Point(108, 203);
      this.tbImageHandle.Name = "tbImageHandle";
      this.tbImageHandle.ReadOnly = true;
      this.tbImageHandle.Size = new System.Drawing.Size(100, 20);
      this.tbImageHandle.TabIndex = 68;
      // 
      // tbAlignment
      // 
      this.tbAlignment.Location = new System.Drawing.Point(108, 158);
      this.tbAlignment.Name = "tbAlignment";
      this.tbAlignment.ReadOnly = true;
      this.tbAlignment.Size = new System.Drawing.Size(100, 20);
      this.tbAlignment.TabIndex = 67;
      // 
      // tbBitsPerPixel
      // 
      this.tbBitsPerPixel.Location = new System.Drawing.Point(108, 132);
      this.tbBitsPerPixel.Name = "tbBitsPerPixel";
      this.tbBitsPerPixel.ReadOnly = true;
      this.tbBitsPerPixel.Size = new System.Drawing.Size(100, 20);
      this.tbBitsPerPixel.TabIndex = 66;
      // 
      // tbImageOffset
      // 
      this.tbImageOffset.Location = new System.Drawing.Point(108, 106);
      this.tbImageOffset.Name = "tbImageOffset";
      this.tbImageOffset.ReadOnly = true;
      this.tbImageOffset.Size = new System.Drawing.Size(100, 20);
      this.tbImageOffset.TabIndex = 65;
      // 
      // tbFrameSize
      // 
      this.tbFrameSize.Location = new System.Drawing.Point(108, 80);
      this.tbFrameSize.Name = "tbFrameSize";
      this.tbFrameSize.ReadOnly = true;
      this.tbFrameSize.Size = new System.Drawing.Size(100, 20);
      this.tbFrameSize.TabIndex = 64;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(35, 135);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(67, 13);
      this.label9.TabIndex = 63;
      this.label9.Text = "Bits per Pixel";
      // 
      // tbImageSize
      // 
      this.tbImageSize.Location = new System.Drawing.Point(108, 54);
      this.tbImageSize.Name = "tbImageSize";
      this.tbImageSize.ReadOnly = true;
      this.tbImageSize.Size = new System.Drawing.Size(100, 20);
      this.tbImageSize.TabIndex = 62;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(44, 57);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(59, 13);
      this.label8.TabIndex = 61;
      this.label8.Text = "Image Size";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(36, 109);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(67, 13);
      this.label7.TabIndex = 60;
      this.label7.Text = "Image Offset";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(44, 83);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 13);
      this.label6.TabIndex = 59;
      this.label6.Text = "Frame Size";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(49, 161);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 13);
      this.label5.TabIndex = 58;
      this.label5.Text = "Alignment";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(30, 206);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 13);
      this.label4.TabIndex = 57;
      this.label4.Text = "Image Handle";
      // 
      // tbType
      // 
      this.tbType.Location = new System.Drawing.Point(108, 28);
      this.tbType.Name = "tbType";
      this.tbType.ReadOnly = true;
      this.tbType.Size = new System.Drawing.Size(100, 20);
      this.tbType.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(71, 31);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 13);
      this.label2.TabIndex = 56;
      this.label2.Text = "Type";
      // 
      // pRegion
      // 
      this.pRegion.Controls.Add(this.gEntries);
      this.pRegion.Dock = System.Windows.Forms.DockStyle.Left;
      this.pRegion.Location = new System.Drawing.Point(0, 85);
      this.pRegion.Name = "pRegion";
      this.pRegion.Size = new System.Drawing.Size(150, 563);
      this.pRegion.TabIndex = 63;
      // 
      // gEntries
      // 
      this.gEntries.Controls.Add(this.lboxItems);
      this.gEntries.Controls.Add(this.panel7);
      this.gEntries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gEntries.Location = new System.Drawing.Point(0, 0);
      this.gEntries.Name = "gEntries";
      this.gEntries.Size = new System.Drawing.Size(150, 563);
      this.gEntries.TabIndex = 57;
      this.gEntries.TabStop = false;
      this.gEntries.Text = "Entries";
      // 
      // lboxItems
      // 
      this.lboxItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lboxItems.FormattingEnabled = true;
      this.lboxItems.Location = new System.Drawing.Point(3, 48);
      this.lboxItems.Name = "lboxItems";
      this.lboxItems.Size = new System.Drawing.Size(144, 512);
      this.lboxItems.TabIndex = 0;
      this.lboxItems.SelectedIndexChanged += new System.EventHandler(this.lboxItems_SelectedIndexChanged);
      // 
      // panel7
      // 
      this.panel7.Controls.Add(this.bMoveDown);
      this.panel7.Controls.Add(this.bMoveUp);
      this.panel7.Controls.Add(this.bRemove);
      this.panel7.Controls.Add(this.bAdd);
      this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel7.Location = new System.Drawing.Point(3, 16);
      this.panel7.Name = "panel7";
      this.panel7.Size = new System.Drawing.Size(144, 32);
      this.panel7.TabIndex = 1;
      // 
      // bMoveDown
      // 
      this.bMoveDown.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Down_32x32;
      this.bMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bMoveDown.Dock = System.Windows.Forms.DockStyle.Right;
      this.bMoveDown.Enabled = false;
      this.bMoveDown.Location = new System.Drawing.Point(80, 0);
      this.bMoveDown.Name = "bMoveDown";
      this.bMoveDown.Size = new System.Drawing.Size(32, 32);
      this.bMoveDown.TabIndex = 2;
      // 
      // bMoveUp
      // 
      this.bMoveUp.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Up_32x32;
      this.bMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bMoveUp.Dock = System.Windows.Forms.DockStyle.Right;
      this.bMoveUp.Enabled = false;
      this.bMoveUp.Location = new System.Drawing.Point(112, 0);
      this.bMoveUp.Name = "bMoveUp";
      this.bMoveUp.Size = new System.Drawing.Size(32, 32);
      this.bMoveUp.TabIndex = 2;
      // 
      // bRemove
      // 
      this.bRemove.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Subtract_32x32;
      this.bRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bRemove.Dock = System.Windows.Forms.DockStyle.Left;
      this.bRemove.Enabled = false;
      this.bRemove.Location = new System.Drawing.Point(32, 0);
      this.bRemove.Name = "bRemove";
      this.bRemove.Size = new System.Drawing.Size(32, 32);
      this.bRemove.TabIndex = 1;
      // 
      // bAdd
      // 
      this.bAdd.BackgroundImage = global::Dune2000.Editor.Properties.Resources.Add_32x32;
      this.bAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.bAdd.Dock = System.Windows.Forms.DockStyle.Left;
      this.bAdd.Enabled = false;
      this.bAdd.Location = new System.Drawing.Point(0, 0);
      this.bAdd.Name = "bAdd";
      this.bAdd.Size = new System.Drawing.Size(32, 32);
      this.bAdd.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.bExportEntries);
      this.panel3.Controls.Add(this.bExportAll);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 50);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(960, 35);
      this.panel3.TabIndex = 62;
      // 
      // bExportEntries
      // 
      this.bExportEntries.Dock = System.Windows.Forms.DockStyle.Left;
      this.bExportEntries.Enabled = false;
      this.bExportEntries.Location = new System.Drawing.Point(100, 0);
      this.bExportEntries.Name = "bExportEntries";
      this.bExportEntries.Size = new System.Drawing.Size(100, 35);
      this.bExportEntries.TabIndex = 64;
      this.bExportEntries.Text = "Export Entries";
      this.bExportEntries.UseVisualStyleBackColor = true;
      // 
      // bExportAll
      // 
      this.bExportAll.Dock = System.Windows.Forms.DockStyle.Left;
      this.bExportAll.Enabled = false;
      this.bExportAll.Location = new System.Drawing.Point(0, 0);
      this.bExportAll.Name = "bExportAll";
      this.bExportAll.Size = new System.Drawing.Size(100, 35);
      this.bExportAll.TabIndex = 57;
      this.bExportAll.Text = "Export All";
      this.bExportAll.UseVisualStyleBackColor = true;
      // 
      // panel6
      // 
      this.panel6.Controls.Add(this.lblHouseColor);
      this.panel6.Controls.Add(this.bLinkHouseColor);
      this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel6.Location = new System.Drawing.Point(0, 25);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(960, 25);
      this.panel6.TabIndex = 66;
      // 
      // lblHouseColor
      // 
      this.lblHouseColor.AutoSize = true;
      this.lblHouseColor.Location = new System.Drawing.Point(209, 6);
      this.lblHouseColor.Name = "lblHouseColor";
      this.lblHouseColor.Size = new System.Drawing.Size(58, 13);
      this.lblHouseColor.TabIndex = 1;
      this.lblHouseColor.Text = "(no file set)";
      // 
      // bLinkHouseColor
      // 
      this.bLinkHouseColor.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLinkHouseColor.Location = new System.Drawing.Point(0, 0);
      this.bLinkHouseColor.Name = "bLinkHouseColor";
      this.bLinkHouseColor.Size = new System.Drawing.Size(200, 25);
      this.bLinkHouseColor.TabIndex = 0;
      this.bLinkHouseColor.Text = "Link House Color File";
      this.bLinkHouseColor.UseVisualStyleBackColor = true;
      this.bLinkHouseColor.Click += new System.EventHandler(this.bLinkHouseColor_Click);
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.lblPalette);
      this.panel5.Controls.Add(this.bLinkPalette);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel5.Location = new System.Drawing.Point(0, 0);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(960, 25);
      this.panel5.TabIndex = 65;
      // 
      // lblPalette
      // 
      this.lblPalette.AutoSize = true;
      this.lblPalette.Location = new System.Drawing.Point(209, 6);
      this.lblPalette.Name = "lblPalette";
      this.lblPalette.Size = new System.Drawing.Size(58, 13);
      this.lblPalette.TabIndex = 1;
      this.lblPalette.Text = "(no file set)";
      // 
      // bLinkPalette
      // 
      this.bLinkPalette.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLinkPalette.Location = new System.Drawing.Point(0, 0);
      this.bLinkPalette.Name = "bLinkPalette";
      this.bLinkPalette.Size = new System.Drawing.Size(200, 25);
      this.bLinkPalette.TabIndex = 0;
      this.bLinkPalette.Text = "Link Palette File";
      this.bLinkPalette.UseVisualStyleBackColor = true;
      this.bLinkPalette.Click += new System.EventHandler(this.bLinkPalette_Click);
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
      this.label22.Text = "Image Resources";
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
      // ofdPalette
      // 
      this.ofdPalette.Filter = "Dune 2000 palette bin file|palette.bin|Dune 2000 bin file|*.bin|All files|*.*";
      // 
      // ofdHousePalette
      // 
      this.ofdHousePalette.Filter = "Dune 2000 colours bin file|colours.bin|Dune 2000 bin file|*.bin|All files|*.*";
      // 
      // ucResourceEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucResourceEditor";
      this.Size = new System.Drawing.Size(960, 708);
      this.panel1.ResumeLayout(false);
      this.pPreview.ResumeLayout(false);
      this.gImage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
      this.panel4.ResumeLayout(false);
      this.gInfo.ResumeLayout(false);
      this.gInfo.PerformLayout();
      this.pRegion.ResumeLayout(false);
      this.gEntries.ResumeLayout(false);
      this.panel7.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Button bExportAll;
    private System.Windows.Forms.Panel pPreview;
    private System.Windows.Forms.Panel pRegion;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbType;
    private System.Windows.Forms.GroupBox gEntries;
    private System.Windows.Forms.ListBox lboxItems;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.Label lblHouseColor;
    private System.Windows.Forms.Button bLinkHouseColor;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Label lblPalette;
    private System.Windows.Forms.Button bLinkPalette;
    private System.Windows.Forms.GroupBox gImage;
    private System.Windows.Forms.GroupBox gInfo;
    private System.Windows.Forms.TextBox tbAlignment;
    private System.Windows.Forms.TextBox tbBitsPerPixel;
    private System.Windows.Forms.TextBox tbImageOffset;
    private System.Windows.Forms.TextBox tbFrameSize;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox tbImageSize;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel7;
    private System.Windows.Forms.Button bAdd;
    private System.Windows.Forms.Button bExportEntries;
    private System.Windows.Forms.Button bMoveDown;
    private System.Windows.Forms.Button bMoveUp;
    private System.Windows.Forms.Button bRemove;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbPalHandle;
    private System.Windows.Forms.TextBox tbImageHandle;
    private System.Windows.Forms.Button bPalette;
    private System.Windows.Forms.OpenFileDialog ofdPalette;
    private System.Windows.Forms.OpenFileDialog ofdHousePalette;
    private System.Windows.Forms.ComboBox cbHouse;
    private System.Windows.Forms.Panel panel8;
    private System.Windows.Forms.CheckBox cboxHousePal;
    private Objects.ResourcePreview pbPreview;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown nudZoom;
    private System.Windows.Forms.CheckBox cbFitToScreen;
    private System.Windows.Forms.CheckBox cbTransparency;
    private System.Windows.Forms.CheckBox cbFrame;
  }
}
