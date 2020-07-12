namespace Dune2000.Editor.UI.Editors.Resources
{
  partial class ImportDataResourceForm
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
      this.tbFilepath = new System.Windows.Forms.TextBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bFilepath = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.rbMerge = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.pbarProgress = new System.Windows.Forms.ProgressBar();
      this.lblProgress = new System.Windows.Forms.Label();
      this.ofdImport = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
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
      this.bOK.Location = new System.Drawing.Point(454, 70);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(76, 34);
      this.bOK.TabIndex = 61;
      this.bOK.Text = "Begin Import";
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
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 63;
      this.label1.Text = "Import File";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(536, 70);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(76, 34);
      this.button1.TabIndex = 65;
      this.button1.Text = "Close";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.bClose_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(97, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(510, 13);
      this.label2.TabIndex = 76;
      this.label2.Text = "It is the user\'s responsibility to ensure that all data and image references are " +
    "in proper order before importing";
      // 
      // rbMerge
      // 
      this.rbMerge.AutoSize = true;
      this.rbMerge.Checked = true;
      this.rbMerge.Location = new System.Drawing.Point(100, 58);
      this.rbMerge.Name = "rbMerge";
      this.rbMerge.Size = new System.Drawing.Size(116, 17);
      this.rbMerge.TabIndex = 77;
      this.rbMerge.TabStop = true;
      this.rbMerge.Text = "Merge with Existing";
      this.rbMerge.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(247, 58);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(201, 17);
      this.radioButton1.TabIndex = 78;
      this.radioButton1.Text = "Erase Existing (turn into blank entries)";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // pbarProgress
      // 
      this.pbarProgress.Location = new System.Drawing.Point(15, 94);
      this.pbarProgress.Name = "pbarProgress";
      this.pbarProgress.Size = new System.Drawing.Size(436, 10);
      this.pbarProgress.TabIndex = 79;
      // 
      // lblProgress
      // 
      this.lblProgress.AutoSize = true;
      this.lblProgress.Location = new System.Drawing.Point(12, 78);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(10, 13);
      this.lblProgress.TabIndex = 80;
      this.lblProgress.Text = " ";
      // 
      // ofdImport
      // 
      this.ofdImport.Filter = "Resource data file|*.ini";
      // 
      // ImportDataResourceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 116);
      this.Controls.Add(this.lblProgress);
      this.Controls.Add(this.pbarProgress);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.rbMerge);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bFilepath);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.tbFilepath);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "ImportDataResourceForm";
      this.Text = "Dune 2000 Editor";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox tbFilepath;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bFilepath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton rbMerge;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.ProgressBar pbarProgress;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.OpenFileDialog ofdImport;
  }
}