using Dune2000.Launcher.UI.Forms;
using Primrose.Primitives.Extensions;
using System;
using System.Windows.Forms;

namespace Dune2000.Launcher
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      try
      {
        Engine engine = new Engine();
        GameForm gForm = new GameForm(engine);
        Application.Run(gForm);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Unhandled exception encountered!\n\n{0}\n\nStacktrace:\n{1}".F(ex.Message, ex.StackTrace));
      }
    }
  }
}
