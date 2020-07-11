namespace Dune2000.Editor.UI.Editors
{
  partial class ucEditorController
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEditorController));
      this.dOpen = new System.Windows.Forms.OpenFileDialog();
      this.dSave = new System.Windows.Forms.SaveFileDialog();
      this.lblFileName = new System.Windows.Forms.Label();
      this.tsMain = new System.Windows.Forms.ToolStrip();
      this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.unloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsbOpen = new System.Windows.Forms.ToolStripButton();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.tsbReload = new System.Windows.Forms.ToolStripButton();
      this.tsbUnload = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbSearch = new System.Windows.Forms.ToolStripButton();
      this.tsSearch = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.tscbKeyValue = new System.Windows.Forms.ToolStripComboBox();
      this.tstbSearch = new System.Windows.Forms.ToolStripTextBox();
      this.tscbComparer = new System.Windows.Forms.ToolStripComboBox();
      this.tsbSearchPrev = new System.Windows.Forms.ToolStripButton();
      this.tsbSearchNext = new System.Windows.Forms.ToolStripButton();
      this.tsMain.SuspendLayout();
      this.tsSearch.SuspendLayout();
      this.SuspendLayout();
      // 
      // dOpen
      // 
      this.dOpen.Filter = "UI table files|*.uib|All files|*.*";
      // 
      // dSave
      // 
      this.dSave.Filter = "UI table files|*.uib|All files|*.*";
      // 
      // lblFileName
      // 
      this.lblFileName.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.lblFileName.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblFileName.ForeColor = System.Drawing.Color.White;
      this.lblFileName.Location = new System.Drawing.Point(0, 0);
      this.lblFileName.Name = "lblFileName";
      this.lblFileName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.lblFileName.Size = new System.Drawing.Size(789, 20);
      this.lblFileName.TabIndex = 4;
      this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tsMain
      // 
      this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tsbOpen,
            this.tsbSave,
            this.tsbReload,
            this.tsbUnload,
            this.toolStripSeparator1,
            this.tsbSearch});
      this.tsMain.Location = new System.Drawing.Point(0, 20);
      this.tsMain.Name = "tsMain";
      this.tsMain.Size = new System.Drawing.Size(789, 39);
      this.tsMain.TabIndex = 5;
      this.tsMain.Text = "toolStrip1";
      // 
      // toolStripDropDownButton1
      // 
      this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.unloadToolStripMenuItem});
      this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
      this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 36);
      this.toolStripDropDownButton1.Text = "File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = global::Dune2000.Editor.Properties.Resources.Open_32x32;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.openToolStripMenuItem.Text = "Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = global::Dune2000.Editor.Properties.Resources.Save_32x32;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.saveAsToolStripMenuItem.Text = "Save As";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
      // 
      // reloadToolStripMenuItem
      // 
      this.reloadToolStripMenuItem.Image = global::Dune2000.Editor.Properties.Resources.Refresh_32x32;
      this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
      this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.reloadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.reloadToolStripMenuItem.Text = "Reload";
      this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
      // 
      // unloadToolStripMenuItem
      // 
      this.unloadToolStripMenuItem.Image = global::Dune2000.Editor.Properties.Resources.Log_Out_32x32;
      this.unloadToolStripMenuItem.Name = "unloadToolStripMenuItem";
      this.unloadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.unloadToolStripMenuItem.Text = "Unload";
      this.unloadToolStripMenuItem.Click += new System.EventHandler(this.UnloadToolStripMenuItem_Click);
      // 
      // tsbOpen
      // 
      this.tsbOpen.AutoSize = false;
      this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbOpen.Image = global::Dune2000.Editor.Properties.Resources.Open_32x32;
      this.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbOpen.Name = "tsbOpen";
      this.tsbOpen.Size = new System.Drawing.Size(40, 36);
      this.tsbOpen.Text = "toolStripButton1";
      this.tsbOpen.ToolTipText = "Open";
      this.tsbOpen.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // tsbSave
      // 
      this.tsbSave.AutoSize = false;
      this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSave.Image = global::Dune2000.Editor.Properties.Resources.Save_32x32;
      this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(40, 36);
      this.tsbSave.Text = "toolStripButton2";
      this.tsbSave.ToolTipText = "Save";
      this.tsbSave.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
      // 
      // tsbReload
      // 
      this.tsbReload.AutoSize = false;
      this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbReload.Image = global::Dune2000.Editor.Properties.Resources.Refresh_32x32;
      this.tsbReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbReload.Name = "tsbReload";
      this.tsbReload.Size = new System.Drawing.Size(40, 36);
      this.tsbReload.Text = "toolStripButton3";
      this.tsbReload.ToolTipText = "Reload";
      this.tsbReload.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
      // 
      // tsbUnload
      // 
      this.tsbUnload.AutoSize = false;
      this.tsbUnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbUnload.Image = global::Dune2000.Editor.Properties.Resources.Log_Out_32x32;
      this.tsbUnload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbUnload.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbUnload.Name = "tsbUnload";
      this.tsbUnload.Size = new System.Drawing.Size(40, 36);
      this.tsbUnload.Text = "toolStripButton4";
      this.tsbUnload.ToolTipText = "Unload";
      this.tsbUnload.Click += new System.EventHandler(this.UnloadToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
      // 
      // tsbSearch
      // 
      this.tsbSearch.AutoSize = false;
      this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSearch.Image = global::Dune2000.Editor.Properties.Resources.Search_32x32;
      this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSearch.Name = "tsbSearch";
      this.tsbSearch.Size = new System.Drawing.Size(40, 36);
      this.tsbSearch.Text = "toolStripButton5";
      this.tsbSearch.ToolTipText = "Toggles search";
      this.tsbSearch.Click += new System.EventHandler(this.TsmiSearch_Click);
      // 
      // tsSearch
      // 
      this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbKeyValue,
            this.tscbComparer,
            this.tstbSearch,
            this.tsbSearchPrev,
            this.tsbSearchNext});
      this.tsSearch.Location = new System.Drawing.Point(0, 59);
      this.tsSearch.Name = "tsSearch";
      this.tsSearch.Size = new System.Drawing.Size(789, 25);
      this.tsSearch.TabIndex = 6;
      this.tsSearch.Text = "toolStrip2";
      this.tsSearch.Visible = false;
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripLabel1.Image = global::Dune2000.Editor.Properties.Resources.Search_32x32;
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
      this.toolStripLabel1.Text = "toolStripLabel1";
      // 
      // tscbKeyValue
      // 
      this.tscbKeyValue.Name = "tscbKeyValue";
      this.tscbKeyValue.Size = new System.Drawing.Size(120, 25);
      this.tscbKeyValue.SelectedIndexChanged += new System.EventHandler(this.SearchColumnChanged);
      // 
      // tstbSearch
      // 
      this.tstbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.tstbSearch.Name = "tstbSearch";
      this.tstbSearch.Size = new System.Drawing.Size(180, 25);
      this.tstbSearch.TextChanged += new System.EventHandler(this.SearchOptionsChanged);
      // 
      // tscbComparer
      // 
      this.tscbComparer.Name = "tscbComparer";
      this.tscbComparer.Size = new System.Drawing.Size(180, 25);
      this.tscbComparer.SelectedIndexChanged += new System.EventHandler(this.SearchOptionsChanged);
      // 
      // tsbSearchPrev
      // 
      this.tsbSearchPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSearchPrev.Enabled = false;
      this.tsbSearchPrev.Image = global::Dune2000.Editor.Properties.Resources.Previous_32x32;
      this.tsbSearchPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSearchPrev.Name = "tsbSearchPrev";
      this.tsbSearchPrev.Size = new System.Drawing.Size(23, 22);
      this.tsbSearchPrev.Text = "toolStripButton1";
      this.tsbSearchPrev.Click += new System.EventHandler(this.TsmiSearchPrev_Click);
      // 
      // tsbSearchNext
      // 
      this.tsbSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSearchNext.Enabled = false;
      this.tsbSearchNext.Image = global::Dune2000.Editor.Properties.Resources.Next_32x32;
      this.tsbSearchNext.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSearchNext.Name = "tsbSearchNext";
      this.tsbSearchNext.Size = new System.Drawing.Size(23, 22);
      this.tsbSearchNext.Text = "toolStripButton2";
      this.tsbSearchNext.Click += new System.EventHandler(this.TsmiSearchNext_Click);
      // 
      // ucEditorController
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tsSearch);
      this.Controls.Add(this.tsMain);
      this.Controls.Add(this.lblFileName);
      this.Name = "ucEditorController";
      this.Size = new System.Drawing.Size(789, 171);
      this.tsMain.ResumeLayout(false);
      this.tsMain.PerformLayout();
      this.tsSearch.ResumeLayout(false);
      this.tsSearch.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.OpenFileDialog dOpen;
    private System.Windows.Forms.SaveFileDialog dSave;
    private System.Windows.Forms.Label lblFileName;
    private System.Windows.Forms.ToolStrip tsMain;
    private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    private System.Windows.Forms.ToolStripButton tsbOpen;
    private System.Windows.Forms.ToolStripButton tsbSave;
    private System.Windows.Forms.ToolStripButton tsbReload;
    private System.Windows.Forms.ToolStripButton tsbUnload;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbSearch;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem unloadToolStripMenuItem;
    private System.Windows.Forms.ToolStrip tsSearch;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripComboBox tscbKeyValue;
    private System.Windows.Forms.ToolStripComboBox tscbComparer;
    private System.Windows.Forms.ToolStripTextBox tstbSearch;
    private System.Windows.Forms.ToolStripButton tsbSearchPrev;
    private System.Windows.Forms.ToolStripButton tsbSearchNext;
  }
}
