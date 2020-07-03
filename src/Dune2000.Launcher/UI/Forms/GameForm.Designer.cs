namespace Dune2000.Launcher.UI.Forms
{
  partial class GameForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
      this.tmTick = new System.Windows.Forms.Timer(this.components);
      this.fadePanel = new Dune2000.Launcher.UI.Objects.FadePanel();
      this.SuspendLayout();
      // 
      // tmTick
      // 
      this.tmTick.Enabled = true;
      this.tmTick.Interval = 20;
      this.tmTick.Tick += new System.EventHandler(this.Tick);
      // 
      // fadePanel
      // 
      this.fadePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.fadePanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fadePanel.Location = new System.Drawing.Point(0, 0);
      this.fadePanel.Name = "fadePanel";
      this.fadePanel.Size = new System.Drawing.Size(944, 561);
      this.fadePanel.TabIndex = 0;
      this.fadePanel.Visible = false;
      // 
      // GameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(944, 561);
      this.Controls.Add(this.fadePanel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "GameForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Dune 2000 Launcher";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
      this.SizeChanged += new System.EventHandler(this.GameForm_SizeChanged);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer tmTick;
    private Objects.FadePanel fadePanel;
  }
}