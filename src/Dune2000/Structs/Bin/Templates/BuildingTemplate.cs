using System.Runtime.InteropServices;

namespace Dune2000.Structs.Bin.Templates
{
  [StructLayout(LayoutKind.Explicit, Size = 0x10c, Pack = 1)]
  public unsafe struct BuildingTemplate
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public fixed byte Raw[0x10c];
    #endregion

  }
}
