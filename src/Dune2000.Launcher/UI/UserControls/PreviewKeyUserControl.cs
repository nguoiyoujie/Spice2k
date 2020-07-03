using System;
using System.Drawing;
using System.Windows.Forms;
using Dune2000.Launcher.UI.Forms;
using Primrose.Primitives.Factories;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class PreviewKeyUserControl : UserControl, ILinkedControl
  {
    public PreviewKeyUserControl()
    {
      InitializeComponent();

      SetKeyAction(Keys.F1, OpenKeyHelp);
    }

    protected UpdateDelegate Clicked_KeyHelp;
    protected Registry<Keys, Action> KeyActions = new Registry<Keys, Action>();
    protected Registry<Keys, string> KeyDescriptions = new Registry<Keys, string>();
    public void SetKeyAction(Keys keyData, Action action, string description = null)
    {
      if (action == null)
      {
        RemoveKeyAction(keyData);
        return;
      }

      KeyActions.Put(keyData, action);
      KeyDescriptions.Put(keyData, description);
    }

    public void RemoveKeyAction(Keys keyData)
    {
      KeyActions.Remove(keyData);
      KeyDescriptions.Remove(keyData);
    }

    private void OpenKeyHelp()
    {
      AudioEngine.Click();
      Clicked_KeyHelp?.Invoke();
    }

    public bool PreviewKey(Keys keyData)
    {
      return KeyActions.Contains(keyData) && KeyActions[keyData] != null;
    }

    public void HandleKey(Keys keyData)
    {
      KeyActions[keyData]?.Invoke();
    }

    public virtual void Link(Engine e) { }

    public virtual void Link(GameForm f)
    {
      if (!(this is KeyNavigationHelpScreen) && KeyDescriptions.Count > 0)
      {
        Clicked_KeyHelp += () =>
        {
          KeyNavigationHelpScreen help = new KeyNavigationHelpScreen();
          help.SetKeys(KeyDescriptions);
          f.Push(help);
        };
      }
    }

    public virtual void Activate(Engine e, Control prevControl) { }

    public virtual void Deactivate(Engine e) { }

    public virtual void HandleFormResize(Size newSize) { }
  }
}
