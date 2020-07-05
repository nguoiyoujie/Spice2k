using System.Runtime.InteropServices;

namespace Dune2000.Structs.Bin.Templates
{
  [StructLayout(LayoutKind.Explicit, Size = 0x1c, Pack = 1)]
  public unsafe struct WeaponTemplate
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public fixed byte Raw[0x1c];
    #endregion

  }
}
