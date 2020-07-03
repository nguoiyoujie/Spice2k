namespace Dune2000.Launcher.UI.Objects
{
  partial class FadePanel
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
      DisposeInner();
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tmFade = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // tmFade
      // 
      this.tmFade.Interval = 66;
      this.tmFade.Tick += new System.EventHandler(this.TmFade_Tick);
      // 
      // FadePanel
      // 
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.Name = "FadeUserControl";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer tmFade;
  }
}
