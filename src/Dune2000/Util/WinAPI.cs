using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Dune2000.Util
{
  public static class WinAPI
  {
    [DllImport("shlwapi.dll", EntryPoint = "PathRelativePathTo")]
    private static extern bool PathRelativePathTo(StringBuilder lpszDst, string from, UInt32 attrFrom, string to, UInt32 attrTo);

    public static string GetRelativePath(string from, string to)
    {
      StringBuilder builder = new StringBuilder(1024);
      bool result = PathRelativePathTo(builder, from, 0, to, 0);
      return builder.ToString();
    }
  }
}
