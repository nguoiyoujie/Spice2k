
using System.Windows.Forms;

namespace Dune2000.Editor.UI.Forms
{
  public partial class MainEditor : Form
  {
    public MainEditor()
    {
      InitializeComponent();

      //FormClosing += (o, e) => e.Cancel = !ucTextUibEditor1.Unload();
    }


    private void Add()
    {

    }

    private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
    {

    }
  }
}
