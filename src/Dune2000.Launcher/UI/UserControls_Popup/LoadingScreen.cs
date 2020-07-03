using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.Util;
using Primrose.Primitives.ValueTypes;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class LoadingScreen : UserControl, ILinkedControl
  {
    public LoadingScreen(string description)
    {
      InitializeComponent();
      SetLoadDescription(description);
      _scale = Size.ToFloat2() / Globals.DEFAULT_WINDOW_SIZE.ToFloat2();
    }

    private float2 _scale;

    public void SetLoadDescription(string description)
    {
      spLoadingText.Text = description;
    }

    public void Release()
    {
      if (ParentForm is GameForm f)
      {
        f.Remove(this);
      }
      else // Popup
      {
        ParentForm?.Close();
      }
    }

    public void Activate(Engine e, Control prevControl) { }
    public void Deactivate(Engine e) { }
    public void HandleKey(Keys keyData) { }
    public void Link(Engine e) { }
    public void Link(GameForm f) { }
    public bool PreviewKey(Keys keyData) { return false; }

    public void HandleFormResize(Size newSize) 
    {
      Size = (newSize.ToFloat2() * _scale).ToSize();
      Size = spBG.AspectAdjustedSize;
    }
  }
}
