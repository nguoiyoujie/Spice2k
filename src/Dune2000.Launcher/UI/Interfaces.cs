using Dune2000.Launcher.UI.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI
{
  public interface ILinkedControl
  {
    void Link(Engine e);
    void Link(GameForm f);
    void Activate(Engine e, Control prevControl);
    void Deactivate(Engine e);
    bool PreviewKey(Keys keyData);
    void HandleKey(Keys keyData);
    void HandleFormResize(Size newSize);
  }
}
