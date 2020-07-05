using System.Runtime.InteropServices;

namespace Dune2000.Structs.Bin.Templates
{
  [StructLayout(LayoutKind.Explicit, Size = 0x08, Pack = 1)]
  public unsafe struct ExplosionTemplate
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public fixed byte Raw[0x08];
    #endregion

  }
}
