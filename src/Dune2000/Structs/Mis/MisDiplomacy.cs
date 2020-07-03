using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Mis
{
  public struct MisDiplomacy
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MisFile.MAX_HOUSES)]
    public Allegiance[] DiploState;
    #endregion
  }

}
