using Dune2000.Editor.UI.Objects;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Editors.Uib.Text
{
  partial class ucTextUibEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTextUibEditor));
      this.dgvTable = new ExtendedDataGridView();
      this.DcKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // dgvTable
      // 
      this.dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvTable.Columns.AddRange(new DataGridViewColumn[] {
            this.DcKey,
            this.DcValue});
      this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvTable.Location = new System.Drawing.Point(0, 0);
      this.dgvTable.Name = "dgvTable";
      this.dgvTable.Size = new System.Drawing.Size(789, 429);
      this.dgvTable.TabIndex = 0;
      this.dgvTable.CellValueChanged += new DataGridViewCellEventHandler(this.DgvTable_CellValueChanged);
      // 
      // DcKey
      // 
      this.DcKey.HeaderText = "Key";
      this.DcKey.Name = "DcKey";
      this.DcKey.SortMode = DataGridViewColumnSortMode.NotSortable;
      // 
      // DcValue
      // 
      this.DcValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.DcValue.HeaderText = "Value";
      this.DcValue.Name = "DcValue";
      this.DcValue.SortMode = DataGridViewColumnSortMode.NotSortable;
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
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(166, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(620, 30);
      this.label1.TabIndex = 0;
      this.label1.Text = resources.GetString("label1.Text");
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
      this.panel2.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
      this.label2.Location = new System.Drawing.Point(3, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(157, 30);
      this.label2.TabIndex = 1;
      this.label2.Text = "Text UI Binary";
      // 
      // ucTextUibEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "ucTextUibEditor";
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
    private System.Windows.Forms.DataGridViewTextBoxColumn DcKey;
    private System.Windows.Forms.DataGridViewTextBoxColumn DcValue;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label2;
  }
}
