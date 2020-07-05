using Dune2000.FileFormats.Bin;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Bin.Templates
{
  [StructLayout(LayoutKind.Explicit, Size = 0x20814 - 0x00adb0, Pack = 1)]
  public unsafe struct ArtTemplate
  {
    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20814 - 0x00adb0)]
    private byte[] _raw;


    // JIT is not able to handle the writing of this struct. Either JIT or my struct is nonsense.
    // The layout is kept here, commented, for research reasons, while a properties and methods are used to extract data instead
    /*
    [FieldOffset(0x00adb0 - 0x00adb0)]
    private fixed uint UnitArtFrames[TemplatesFile.MAX_UNIT_ART];

    [FieldOffset(0x00af18 - 0x00adb0)]
    private fixed uint UnitArtDirections[TemplatesFile.MAX_UNIT_ART];

    [FieldOffset(0x00b080 - 0x00adb0)]
    private uint UnitArtCount;

    [FieldOffset(0x00b084 - 0x00adb0)]
    private byte UnitCount;

    [FieldOffset(0x00b085 - 0x00adb0)]
    private uint AnimationArtCount;

    [FieldOffset(0x00b089 - 0x00adb0)]
    private fixed uint AnimationFrames[TemplatesFile.MAX_ANIMATION_ART];

    [FieldOffset(0x00b189 - 0x00adb0)]
    private byte Unknown_0xB189;

    [FieldOffset(0x00b18a - 0x00adb0)]
    private uint Unknown_0xB18A;

    [FieldOffset(0x00b18e - 0x00adb0)]
    private fixed uint ProjectileArtDirections[TemplatesFile.MAX_PROJECTILE_ART];

    [FieldOffset(0x00b28e - 0x00adb0)]
    private byte ProjectileArtCount;

    [FieldOffset(0x00b28f - 0x00adb0)]
    private uint BuildingArtCount;

    [FieldOffset(0x00b293 - 0x00adb0)]
    private fixed uint BuildingArtDirections[TemplatesFile.MAX_BUILDING_ART];

    [FieldOffset(0x00b473 - 0x00adb0)]
    private byte BuildingCount;

    [FieldOffset(0x00b484 - 0x00adb0)]
    private fixed byte BuildingNames[TemplatesFile.MAX_BUILDINGS * 0x1c2];

    [FieldOffset(0x01643c - 0x00adb0)]
    private fixed byte WeaponNames[TemplatesFile.MAX_WEAPONS * 0x32];

    [FieldOffset(0x0170bc - 0x00adb0)]
    private fixed byte ExplosionNames[TemplatesFile.MAX_EXPLOSIONS * 0x32];

    [FieldOffset(0x017d3c - 0x00adb0)]
    private fixed byte UnitNames[TemplatesFile.MAX_UNITS * 0x1c2];

    [FieldOffset(0x01e6b4 - 0x00adb0)]
    private fixed byte UnitTypeNames[TemplatesFile.MAX_UNIT_TYPES * 0x32];

    [FieldOffset(0x01f26c - 0x00adb0)]
    private fixed byte BuildingTypeNames[TemplatesFile.MAX_BUILDING_TYPES * 0x32];

    [FieldOffset(0x0205f4 - 0x00adb0)]
    private fixed byte Unknown_0x205F4[86];

    [FieldOffset(0x02064a - 0x00adb0)]
    private fixed byte Unknown_0x2064A[256];

    [FieldOffset(0x02074a - 0x00adb0)]
    private fixed byte BuildingActiveAnimationFrames[TemplatesFile.MAX_BUILDINGS];

    [FieldOffset(0x0207ae - 0x00adb0)]
    private fixed byte BuildingBuildupAnimationFrames[TemplatesFile.MAX_BUILDINGS];

    [FieldOffset(0x020812 - 0x00adb0)]
    private byte Unknown_0x20812;

    [FieldOffset(0x020813 - 0x00adb0)]
    private byte Unknown_0x20813;
    */
    #endregion

    /*
    public uint[] UnitArtFrames
    {
      get
      {


      }
      set
      {



      }
    }
    */
  }
}
