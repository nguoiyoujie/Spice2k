using Dune2000.Launcher.UI.Forms;
using Dune2000.Launcher.Util;
using Primrose.Primitives.ValueTypes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dune2000.Launcher.UI.UserControls
{
  public partial class ErrorScreen : PreviewKeyUserControl, ILinkedControl
  {
    public ErrorScreen()
    {
      InitializeComponent();
      _scale = Size.ToFloat2() / Globals.DEFAULT_WINDOW_SIZE.ToFloat2();

      RemoveKeyAction(Keys.F1);
      SetKeyAction(Keys.Escape, () => spErrAck_Click(null, null));
      SetKeyAction(Keys.Enter, () => spErrAck_Click(null, null));
      SetKeyAction(Keys.Left, () => spPrevPage_Click(null, null));
      SetKeyAction(Keys.Right, () => spNextPage_Click(null, null));
    }

    private float2 _scale;

    public void SetError(string title, string description)
    {
      spErrorTitle.Text = title;
      spErrorText.Text = description;
      UpdateControls();
    }

    public void UpdateControls()
    {
      spPrevPage.Enabled = !spErrorText.IsFirstTextPage;
      spNextPage.Enabled = !spErrorText.IsLastTextPage;
    }

    private void spErrAck_Click(object sender, EventArgs e)
    {
      Visible = false;
      AudioEngine.Click();
      Release();
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

    private void spPrevPage_Click(object sender, EventArgs e) { if (!spErrorText.IsFirstTextPage) { AudioEngine.Click(); spErrorText.TextPage--; UpdateControls(); } }
    private void spNextPage_Click(object sender, EventArgs e) { if (!spErrorText.IsLastTextPage) { AudioEngine.Click(); spErrorText.TextPage++; UpdateControls(); } }

    public override void HandleFormResize(Size newSize)
    {
      Size = (newSize.ToFloat2() * _scale).ToSize();
      Size = spBG.AspectAdjustedSize;
    }
  }
}
