using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.Util;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using Primrose.Primitives.ValueTypes;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class KeyNavigationHelpScreen : PreviewKeyUserControl, ILinkedControl
  {
    public KeyNavigationHelpScreen()
    {
      InitializeComponent();
      _scale = Size.ToFloat2() / Globals.DEFAULT_WINDOW_SIZE.ToFloat2();

      RemoveKeyAction(Keys.F1);
      SetKeyAction(Keys.Escape, () => spAck_Click(null, null));
      SetKeyAction(Keys.Enter, () => spAck_Click(null, null));
      SetKeyAction(Keys.Left, () => spPrevPage_Click(null, null));
      SetKeyAction(Keys.Right, () => spNextPage_Click(null, null));
    }

    private float2 _scale;
    public UpdateDelegate Acknowledged;

    public void SetKeys(Registry<Keys, string> descriptions)
    {
      StringBuilder sb = new StringBuilder();
      foreach (Keys k in descriptions.GetKeys())
      {
        string d = descriptions[k];
        if (!string.IsNullOrEmpty(d))
        {
          sb.AppendLine("{0}    {1}".F(k.ToString(), d));
        }
      }
      spKeyDesc.Text = sb.ToString();
      UpdateControls();
    }

    public void UpdateControls()
    {
      spPrevPage.Enabled = !spKeyDesc.IsFirstTextPage;
      spNextPage.Enabled = !spKeyDesc.IsLastTextPage;
    }

    private void spAck_Click(object sender, EventArgs e)
    {
      Visible = false;
      AudioEngine.Click();
      Acknowledged?.Invoke();
    }

    private void spPrevPage_Click(object sender, EventArgs e) { if (!spKeyDesc.IsFirstTextPage) { AudioEngine.Click(); spKeyDesc.TextPage--; UpdateControls(); } }
    private void spNextPage_Click(object sender, EventArgs e) { if (!spKeyDesc.IsLastTextPage) { AudioEngine.Click(); spKeyDesc.TextPage++; UpdateControls(); } }

    public override void Link(GameForm f)
    {
      base.Link(f);
      Acknowledged += () => f.Remove(this);
    }

    public override void HandleFormResize(Size newSize)
    {
      Size = (newSize.ToFloat2() * _scale).ToSize();
      Size = spBG.AspectAdjustedSize;
    }
  }
}
