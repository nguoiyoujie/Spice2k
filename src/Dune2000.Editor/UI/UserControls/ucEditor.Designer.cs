namespace Dune2000.Editor.UI.UserControls
{
  partial class ucEditor
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
      this.dOpen = new System.Windows.Forms.OpenFileDialog();
      this.dSave = new System.Windows.Forms.SaveFileDialog();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.unloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiReload = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiUnload = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSearchBar = new System.Windows.Forms.MenuStrip();
      this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
      this.tscbKeyValue = new System.Windows.Forms.ToolStripComboBox();
      this.tscbComparer = new System.Windows.Forms.ToolStripComboBox();
      this.tstbSearch = new System.Windows.Forms.ToolStripTextBox();
      this.tsmiSearchPrev = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiSearchNext = new System.Windows.Forms.ToolStripMenuItem();
      this.lblFileName = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.menuSearchBar.SuspendLayout();
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
      // menuStrip1
      // 
      this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiReload,
            this.tsmiUnload,
            this.tsmiSearch});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(789, 40);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.unloadToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 36);
      this.fileToolStripMenuItem.Text = "File";
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
      // tsmiOpen
      // 
      this.tsmiOpen.Image = global::Dune2000.Editor.Properties.Resources.Open_32x32;
      this.tsmiOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsmiOpen.Name = "tsmiOpen";
      this.tsmiOpen.Size = new System.Drawing.Size(44, 36);
      this.tsmiOpen.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // tsmiSave
      // 
      this.tsmiSave.Image = global::Dune2000.Editor.Properties.Resources.Save_32x32;
      this.tsmiSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsmiSave.Name = "tsmiSave";
      this.tsmiSave.Size = new System.Drawing.Size(44, 36);
      this.tsmiSave.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
      // 
      // tsmiReload
      // 
      this.tsmiReload.Image = global::Dune2000.Editor.Properties.Resources.Refresh_32x32;
      this.tsmiReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsmiReload.Name = "tsmiReload";
      this.tsmiReload.Size = new System.Drawing.Size(44, 36);
      this.tsmiReload.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
      // 
      // tsmiUnload
      // 
      this.tsmiUnload.Image = global::Dune2000.Editor.Properties.Resources.Log_Out_32x32;
      this.tsmiUnload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsmiUnload.Name = "tsmiUnload";
      this.tsmiUnload.Size = new System.Drawing.Size(44, 36);
      this.tsmiUnload.Click += new System.EventHandler(this.UnloadToolStripMenuItem_Click);
      // 
      // tsmiSearch
      // 
      this.tsmiSearch.Image = global::Dune2000.Editor.Properties.Resources.Search_32x32;
      this.tsmiSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsmiSearch.Name = "tsmiSearch";
      this.tsmiSearch.Size = new System.Drawing.Size(44, 36);
      this.tsmiSearch.Click += new System.EventHandler(this.TsmiSearch_Click);
      // 
      // menuSearchBar
      // 
      this.menuSearchBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.menuSearchBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.tscbKeyValue,
            this.tscbComparer,
            this.tstbSearch,
            this.tsmiSearchPrev,
            this.tsmiSearchNext});
      this.menuSearchBar.Location = new System.Drawing.Point(0, 40);
      this.menuSearchBar.Name = "menuSearchBar";
      this.menuSearchBar.Size = new System.Drawing.Size(789, 27);
      this.menuSearchBar.TabIndex = 3;
      this.menuSearchBar.Text = "menuStrip2";
      this.menuSearchBar.Visible = false;
      // 
      // toolStripMenuItem11
      // 
      this.toolStripMenuItem11.Image = global::Dune2000.Editor.Properties.Resources.Search_32x32;
      this.toolStripMenuItem11.Name = "toolStripMenuItem11";
      this.toolStripMenuItem11.Size = new System.Drawing.Size(28, 23);
      // 
      // tscbKeyValue
      // 
      this.tscbKeyValue.Name = "tscbKeyValue";
      this.tscbKeyValue.Size = new System.Drawing.Size(120, 23);
      this.tscbKeyValue.SelectedIndexChanged += new System.EventHandler(this.SearchColumnChanged);
      // 
      // tscbComparer
      // 
      this.tscbComparer.Name = "tscbComparer";
      this.tscbComparer.Size = new System.Drawing.Size(180, 23);
      this.tscbComparer.SelectedIndexChanged += new System.EventHandler(this.SearchOptionsChanged);
      // 
      // tstbSearch
      // 
      this.tstbSearch.Name = "tstbSearch";
      this.tstbSearch.Size = new System.Drawing.Size(180, 23);
      this.tstbSearch.TextChanged += new System.EventHandler(this.SearchOptionsChanged);
      // 
      // tsmiSearchPrev
      // 
      this.tsmiSearchPrev.Enabled = false;
      this.tsmiSearchPrev.Image = global::Dune2000.Editor.Properties.Resources.Previous_32x32;
      this.tsmiSearchPrev.Name = "tsmiSearchPrev";
      this.tsmiSearchPrev.Size = new System.Drawing.Size(28, 23);
      this.tsmiSearchPrev.Click += new System.EventHandler(this.TsmiSearchPrev_Click);
      // 
      // tsmiSearchNext
      // 
      this.tsmiSearchNext.Enabled = false;
      this.tsmiSearchNext.Image = global::Dune2000.Editor.Properties.Resources.Next_32x32;
      this.tsmiSearchNext.Name = "tsmiSearchNext";
      this.tsmiSearchNext.Size = new System.Drawing.Size(28, 23);
      this.tsmiSearchNext.Click += new System.EventHandler(this.TsmiSearchNext_Click);
      // 
      // lblFileName
      // 
      this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblFileName.Location = new System.Drawing.Point(335, 0);
      this.lblFileName.Name = "lblFileName";
      this.lblFileName.Size = new System.Drawing.Size(454, 25);
      this.lblFileName.TabIndex = 4;
      this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ucEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblFileName);
      this.Controls.Add(this.menuSearchBar);
      this.Controls.Add(this.menuStrip1);
      this.Name = "ucEditor";
      this.Size = new System.Drawing.Size(789, 536);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.menuSearchBar.ResumeLayout(false);
      this.menuSearchBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.OpenFileDialog dOpen;
    private System.Windows.Forms.SaveFileDialog dSave;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem unloadToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
    private System.Windows.Forms.ToolStripMenuItem tsmiSave;
    private System.Windows.Forms.ToolStripMenuItem tsmiReload;
    private System.Windows.Forms.ToolStripMenuItem tsmiUnload;
    private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
    private System.Windows.Forms.MenuStrip menuSearchBar;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
    private System.Windows.Forms.ToolStripComboBox tscbKeyValue;
    private System.Windows.Forms.ToolStripComboBox tscbComparer;
    private System.Windows.Forms.ToolStripTextBox tstbSearch;
    private System.Windows.Forms.ToolStripMenuItem tsmiSearchPrev;
    private System.Windows.Forms.ToolStripMenuItem tsmiSearchNext;
    private System.Windows.Forms.Label lblFileName;
  }
}
