using Primrose.FileFormat.INI;

namespace Dune2000.Extensions.FileFormats.INI
{
  public class LauncherSettingsFile : INIFile
  {
    // Internal settings file format for the launcher

    [INIValue(Section = "Paths")]
    public string ExecutablePath;
  }
}
