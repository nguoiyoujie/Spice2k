using Dune2000.Editor.UI.Editors;

namespace Dune2000.Editor.UI.Forms
{
  partial class MainEditor
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
      this.pEditor = new System.Windows.Forms.Panel();
      this.ucEditorController = new ucEditorController();
      this.ucEditorSelector1 = new ucEditorSelector();
      this.SuspendLayout();
      // 
      // pEditor
      // 
      this.pEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pEditor.Location = new System.Drawing.Point(0, 173);
      this.pEditor.Name = "pEditor";
      this.pEditor.Size = new System.Drawing.Size(944, 428);
      this.pEditor.TabIndex = 5;
      // 
      // ucEditorController
      // 
      this.ucEditorController.AutoSize = true;
      this.ucEditorController.Dock = System.Windows.Forms.DockStyle.Top;
      this.ucEditorController.Location = new System.Drawing.Point(0, 114);
      this.ucEditorController.Name = "ucEditorController";
      this.ucEditorController.Size = new System.Drawing.Size(944, 59);
      this.ucEditorController.TabIndex = 3;
      // 
      // ucEditorSelector1
      // 
      this.ucEditorSelector1.AutoSize = true;
      this.ucEditorSelector1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ucEditorSelector1.Location = new System.Drawing.Point(0, 0);
      this.ucEditorSelector1.Name = "ucEditorSelector1";
      this.ucEditorSelector1.Size = new System.Drawing.Size(944, 114);
      this.ucEditorSelector1.TabIndex = 4;
      // 
      // MainEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(944, 601);
      this.Controls.Add(this.pEditor);
      this.Controls.Add(this.ucEditorController);
      this.Controls.Add(this.ucEditorSelector1);
      this.Name = "MainEditor";
      this.Text = "Dune 2000 Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private ucEditorController ucEditorController;
    private ucEditorSelector ucEditorSelector1;
    private System.Windows.Forms.Panel pEditor;
  }
}