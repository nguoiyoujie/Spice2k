namespace Dune2000.Launcher.UI.Objects
{
  partial class SpriteBox
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
      this.SuspendLayout();
      // 
      // SpriteBox
      // 
      this.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.EnabledChanged += new System.EventHandler(this.EventHandler_UpdateState);
      this.LocationChanged += new System.EventHandler(this.SpriteBox_LocationChanged);
      this.SizeChanged += new System.EventHandler(this.SpriteBox_SizeChanged);
      this.VisibleChanged += new System.EventHandler(this.EventHandler_UpdateState);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventHandler_SetMouseDown);
      this.MouseEnter += new System.EventHandler(this.EventHandler_SetMouseHover);
      this.MouseLeave += new System.EventHandler(this.EventHandler_SetMouseDefault);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventHandler_SetMouseHoverIfDown);
      this.ResumeLayout(false);

    }

    #endregion
  }
}
