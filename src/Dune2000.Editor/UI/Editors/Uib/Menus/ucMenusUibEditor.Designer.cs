using Dune2000.Editor.UI.Objects;

namespace Dune2000.Editor.UI.Editors.Uib.Menus
{
  partial class ucMenusUibEditor
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
      this.dgvTable = new ExtendedDataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.DcFadeOut = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.DcFadeIn = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.DcMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DcKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // dgvTable
      // 
      this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DcKey,
            this.DcMenu,
            this.DcFadeIn,
            this.DcFadeOut});
      this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvTable.Location = new System.Drawing.Point(0, 0);
      this.dgvTable.Name = "dgvTable";
      this.dgvTable.Size = new System.Drawing.Size(789, 429);
      this.dgvTable.TabIndex = 0;
      this.dgvTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTable_CellValueChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.dgvTable);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 107);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(789, 429);
      this.panel1.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Gainsboro;
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 67);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(789, 40);
      this.panel2.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
      this.label2.Location = new System.Drawing.Point(3, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(157, 30);
      this.label2.TabIndex = 1;
      this.label2.Text = "Menu UI Binary";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(166, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(620, 30);
      this.label1.TabIndex = 0;
      this.label1.Text = "Menu uib files (menus.uib) store references to menu layout (.uil) files. The game" +
    " provides a key, this table returns the menu file path and parameters mapped to " +
    "this key.";
      // 
      // DcFadeOut
      // 
      this.DcFadeOut.HeaderText = "Fade Out Action";
      this.DcFadeOut.Items.AddRange(new object[] {
            "Fade from Black",
            "Fade to Black",
            "Tween",
            "Don\'t Fade"});
      this.DcFadeOut.MinimumWidth = 120;
      this.DcFadeOut.Name = "DcFadeOut";
      this.DcFadeOut.Width = 120;
      // 
      // DcFadeIn
      // 
      this.DcFadeIn.HeaderText = "Fade In Action";
      this.DcFadeIn.Items.AddRange(new object[] {
            "Fade from Black",
            "Fade to Black",
            "Tween",
            "Don\'t Fade"});
      this.DcFadeIn.MinimumWidth = 120;
      this.DcFadeIn.Name = "DcFadeIn";
      this.DcFadeIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.DcFadeIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.DcFadeIn.Width = 120;
      // 
      // DcMenu
      // 
      this.DcMenu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DcMenu.HeaderText = "Menu File";
      this.DcMenu.Name = "DcMenu";
      this.DcMenu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // DcKey
      // 
      this.DcKey.HeaderText = "Key";
      this.DcKey.MinimumWidth = 100;
      this.DcKey.Name = "DcKey";
      this.DcKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // ucMenusUibEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucMenusUibEditor";
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ExtendedDataGridView dgvTable;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridViewTextBoxColumn DcKey;
    private System.Windows.Forms.DataGridViewTextBoxColumn DcMenu;
    private System.Windows.Forms.DataGridViewComboBoxColumn DcFadeIn;
    private System.Windows.Forms.DataGridViewComboBoxColumn DcFadeOut;
  }
}
