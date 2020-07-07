
using Dune2000.Editor.UI.UserControls;
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Forms
{
  public partial class MainEditor : Form
  {
    public MainEditor()
    {
      InitializeComponent();
      tcEditorTabs_SelectedIndexChanged(null, null);
    }

    private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
      foreach (TabPage page in tcEditorTabs.TabPages)
      {
        foreach (Control c in page.Controls)
        {
          if (c is IEditorControl editc && editc.Dirty)
          {
            tcEditorTabs.SelectedTab = page;
            ucEditorController.SetEditor(editc);
            if (!ucEditorController.Unload())
            {
              e.Cancel = true;
              return;
            }
          }
        }
      }
    }

    private void tcEditorTabs_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      TabPage page = tcEditorTabs.SelectedTab;
      if (page == null) { return; }

      foreach (Control c in page.Controls)
      {
        if (c is IEditorControl editc)
        {
          ucEditorController.SetEditor(editc);
        }
      }
    }
  }
}
