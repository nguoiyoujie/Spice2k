using System.Windows.Forms;

namespace Dune2000.Launcher.UI.Forms
{
  public partial class PopupForm : Form
  {
    public PopupForm(Control control)
    {
      InitializeComponent();
      Controls.Add(control);
      _control = control;
      Size = control.Size;
      CenterToScreen();
      Focus();
      KeyPreview = true;
    }

    private Control _control;

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (Enabled)
      {
        if (_control is ILinkedControl linkedControl)
        {
          linkedControl.HandleKey(keyData);
          return true;
        };
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }
  }
}
