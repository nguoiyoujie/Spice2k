using Dune2000.FileFormats.Bin;
using Dune2000.FileFormats.R16;
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

      //TemplatesFile tplfile = new TemplatesFile();
      //tplfile.ReadFromFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\bin\templates.bin");
      //tplfile.WriteToFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\bin\templates_write.bin");

      //ResourceFile resfile = new ResourceFile();
      //resfile.ReadFromFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\DATA.R8");
      //resfile.WriteToFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\DATA_write.R8");
      //resfile.ReadFromFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\data\DATA_write.R8");


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


      //StatsFile stats = new StatsFile();
      //stats.LoadFromFile(@"C:\Program Files (x86)\Gruntmods Studios\Dune 2000\stats.dmp");
    }
  }
}
