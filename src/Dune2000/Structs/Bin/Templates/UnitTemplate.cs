using Dune2000.Enums;
using System.Runtime.InteropServices;

namespace Dune2000.Structs.Bin.Templates
{
  [StructLayout(LayoutKind.Explicit, Size = 0x100, Pack = 1)]
  public unsafe struct UnitTemplate
  {
    // Warning: This listing is derived from TibEd, each value has to be tested and confirmed!
    public const int MAX_DIRECTIONS = 32;
    public const int MAX_HOUSES = 3;
    public const int MAX_REPORTING_SOUNDS_PER_HOUSE = 3;
    public const int MAX_CONFIRMED_SOUNDS_PER_HOUSE = 3;

    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public byte Unknown_1;

    [FieldOffset(1)]
    public UnitType UnitType;

    [FieldOffset(2)]
    public ArmourType ArmourType;

    [FieldOffset(3)]
    public byte ROT;

    [FieldOffset(4)]
    public uint Strength;

    [FieldOffset(8)]
    public byte Unknown_8;

    [FieldOffset(9)]
    public ushort Speed;

    [FieldOffset(11)]
    public byte Unknown_11;

    [FieldOffset(12)]
    public byte PrimaryWeaponID;

    [FieldOffset(13)]
    public byte SecondaryWeaponID;

    [FieldOffset(14)]
    public ushort ROF;

    [FieldOffset(16)]
    public byte Sight;

    [FieldOffset(17)]
    public byte MoveInfantryZone; // 00=no, 01=yes

    [FieldOffset(18)]
    public byte Unknown_18;

    [FieldOffset(19)]
    public byte Unknown_19;

    [FieldOffset(20)]
    public int UnitArtID; // FF FF FF FF = none

    [FieldOffset(24)]
    public int BarrelArtID; // use a UnitArt entry, FF FF FF FF = none

    [FieldOffset(28)]
    public uint Cost;

    [FieldOffset(32)]
    public uint BuildSpeed;

    [FieldOffset(36)]
    public byte TechLevel;

    [FieldOffset(37)]
    public byte IsStarportUnit; // 00=no, 01=yes

    [FieldOffset(38)]
    public byte HasBarrel; // 00=no, 01=yes

    [FieldOffset(39)]
    public byte RequiresUpgrade; // 00=no, 01=yes

    [FieldOffset(40)]
    public BuildingType Prerequisite; // uses BuildingType (if value >= the BuildingType limit (0x64), the game determines as NONE)

    // bytes 41-43 are likely overflow from Prerequisite, not used
    [FieldOffset(41)]
    public byte Unused_41;

    [FieldOffset(42)]
    public byte Unused_42;

    [FieldOffset(43)]
    public byte Unused_43;

    [FieldOffset(44)]
    public byte Owners; // bitflag for sides 0 - 7

    [FieldOffset(45)]
    public byte SpecialLogic;

    [FieldOffset(46)]
    public byte Unknown_46;

    [FieldOffset(47)]
    public byte DeathAnimationArtID; // Uses AnimationArt

    [FieldOffset(48)]
    public BuildingType Prerequisite2; // uses BuildingType (if value >= the BuildingType limit (0x64), the game determines as NONE)

    // bytes 49-51 are likely overflow from Prerequisite2, not used
    [FieldOffset(49)]
    public byte Unused_49;

    [FieldOffset(50)]
    public byte Unused_50;

    [FieldOffset(51)]
    public byte Unused_51;

    [FieldOffset(52)]
    public byte Unknown_52;

    [FieldOffset(53)]
    public byte IsCrusher; // 00=no, 01=yes

    [FieldOffset(54)]
    public byte HealthBar; // 0=small (inf), 1=medium, 2=large (harvester)

    [FieldOffset(55)]
    public byte Unknown_55;

    [FieldOffset(56)]
    public byte Unknown_56;

    [FieldOffset(57)]
    public byte IsInaccurate; // 00=no, 80=yes

    [FieldOffset(58)]
    public byte SelfHeal; // 00=no, 80=yes

    [FieldOffset(59)]
    public byte Unknown_59;

    [FieldOffset(60)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DIRECTIONS)]
    public byte[] DirectionStartFrames;

    // fixed int can be avoided due to offset 92 being of good alignment
    [FieldOffset(92)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (MAX_REPORTING_SOUNDS_PER_HOUSE + MAX_CONFIRMED_SOUNDS_PER_HOUSE) * MAX_HOUSES)]
    public int[] UnitVoiceIDs;

    [FieldOffset(164)]
    public byte InfantryFiringAnimationArtID; // Uses AnimationArt

    [FieldOffset(168)]
    public byte SmokeAnimationArtID; // Uses AnimationArt

    [FieldOffset(169)]
    public SpeedType SpeedType;

    [FieldOffset(170)]
    public byte MultiplayerOnly;

    // more bytes, but they don't seem to be filled
    #endregion

  }
}
