using System.Runtime.InteropServices;

namespace Dune2000.Structs.Mis
{
  public struct MisAI
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7608)]
    public byte[] data;
    #endregion
  }
}
