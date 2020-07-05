using Dune2000.Enums;
using Dune2000.Structs.Bin.Templates;
using Primrose.FileFormats.Common;
using System.IO;
using System.Runtime.InteropServices;

namespace Dune2000.FileFormats.Bin
{
  public class TemplatesFile : IFile
  {
    public const int MAX_UNITS = 60;
    public const int MAX_BUILDINGS = 100;
    public const int MAX_WEAPONS = 64;
    public const int MAX_EXPLOSIONS = 64;

    public const int MAX_UNIT_ART = 90;
    public const int MAX_BUILDING_ART = 120;
    public const int MAX_PROJECTILE_ART = 64;
    public const int MAX_ANIMATION_ART = 64;

    public const int MAX_UNIT_TYPES = 60;
    public const int MAX_BUILDING_TYPES = 100;


    public readonly UnitTemplate[] Units = new UnitTemplate[MAX_UNITS] ;
    public readonly BuildingTemplate[] Buildings = new BuildingTemplate[MAX_BUILDINGS] ;
    public readonly WeaponTemplate[] Weapons = new WeaponTemplate[MAX_WEAPONS] ;
    public readonly ExplosionTemplate[] Explosions = new ExplosionTemplate[MAX_EXPLOSIONS] ;

    // based on exact layout of file
    private uint[] UnitArtFrames = new uint[MAX_UNIT_ART];
    private uint[] UnitArtDirections = new uint[MAX_UNIT_ART];
    private uint UnitArtCount;
    private byte UnitCount;
    private uint AnimationArtCount;
    private uint[] AnimationFrames = new uint[MAX_ANIMATION_ART];
    private byte Unknown_0xB189;
    private uint Unknown_0xB18A;
    private uint[] ProjectileArtDirections = new uint[MAX_PROJECTILE_ART];
    private byte ProjectileArtCount;
    private uint BuildingArtCount;
    private uint[] BuildingArtDirections = new uint[MAX_BUILDING_ART];
    private byte BuildingCount;
    private string[] BuildingNames = new string[MAX_BUILDINGS]; // length limit: 0x1c2
    private string[] WeaponNames = new string[MAX_WEAPONS]; // length limit: 0x32
    private string[] ExplosionNames = new string[MAX_EXPLOSIONS]; // length limit: 0x32
    private string[] UnitNames = new string[MAX_UNITS]; // length limit: 0x1c2
    private string[] UnitTypeNames = new string[MAX_UNIT_TYPES]; // length limit: 0x32
    private string[] BuildingTypeNames = new string[MAX_BUILDING_TYPES]; // length limit: 0x32
    private byte[] Unknown_0x205F4 = new byte[86];
    private byte[] Unknown_0x2064A = new byte[256];
    private byte[] BuildingActiveAnimationFrames = new byte[MAX_BUILDINGS];
    private byte[] BuildingBuildupAnimationFrames = new byte[MAX_BUILDINGS];
    private byte Unknown_0x20812;
    private byte Unknown_0x20813;


    public void ReadFromFile(string filePath)
    {
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader reader = new BinaryReader(fs))
        {
          // Layout is so horrible, you can't Marshal the file as a single struct...

          byte[] readBuffer;
          GCHandle handle;
          for (int i = 0; i < Units.Length; i++)
          {
            readBuffer = reader.ReadBytes(Marshal.SizeOf(typeof(UnitTemplate)));
            handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            Units[i] = (UnitTemplate)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(UnitTemplate));
            handle.Free();
          }

          for (int i = 0; i < Buildings.Length; i++)
          {
            readBuffer = reader.ReadBytes(Marshal.SizeOf(typeof(BuildingTemplate)));
            handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            Buildings[i] = (BuildingTemplate)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(BuildingTemplate));
            handle.Free();
          }

          for (int i = 0; i < Weapons.Length; i++)
          {
            readBuffer = reader.ReadBytes(Marshal.SizeOf(typeof(WeaponTemplate)));
            handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            Weapons[i] = (WeaponTemplate)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(WeaponTemplate));
            handle.Free();
          }

          for (int i = 0; i < Explosions.Length; i++)
          {
            readBuffer = reader.ReadBytes(Marshal.SizeOf(typeof(ExplosionTemplate)));
            handle = GCHandle.Alloc(readBuffer, GCHandleType.Pinned);
            Explosions[i] = (ExplosionTemplate)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(ExplosionTemplate));
            handle.Free();
          }


          for (int i = 0; i < UnitArtFrames.Length; i++) { UnitArtFrames[i] = reader.ReadUInt32(); }
          for (int i = 0; i < UnitArtDirections.Length; i++) { UnitArtDirections[i] = reader.ReadUInt32(); }
          UnitArtCount = reader.ReadUInt32();
          UnitCount = reader.ReadByte();
          AnimationArtCount = reader.ReadUInt32();
          for (int i = 0; i < AnimationFrames.Length; i++) { AnimationFrames[i] = reader.ReadUInt32(); }
          Unknown_0xB189 = reader.ReadByte();
          Unknown_0xB18A = reader.ReadUInt32();
          for (int i = 0; i < ProjectileArtDirections.Length; i++) { ProjectileArtDirections[i] = reader.ReadUInt32(); }
          ProjectileArtCount = reader.ReadByte();
          BuildingArtCount = reader.ReadUInt32();
          for (int i = 0; i < BuildingArtDirections.Length; i++) { BuildingArtDirections[i] = reader.ReadUInt32(); }
          BuildingCount = reader.ReadByte();
          for (int i = 0; i < BuildingNames.Length; i++) { BuildingNames[i] = ReadFixedString(reader, 0x1c2); }
          for (int i = 0; i < WeaponNames.Length; i++) { WeaponNames[i] = ReadFixedString(reader, 0x32); }
          for (int i = 0; i < ExplosionNames.Length; i++) { ExplosionNames[i] = ReadFixedString(reader, 0x32); }
          for (int i = 0; i < UnitNames.Length; i++) { UnitNames[i] = ReadFixedString(reader, 0x1c2); }
          for (int i = 0; i < UnitTypeNames.Length; i++) { UnitTypeNames[i] = ReadFixedString(reader, 0x32); }
          for (int i = 0; i < BuildingTypeNames.Length; i++) { BuildingTypeNames[i] = ReadFixedString(reader, 0x32); }
          for (int i = 0; i < Unknown_0x205F4.Length; i++) { Unknown_0x205F4[i] = reader.ReadByte(); }
          for (int i = 0; i < Unknown_0x2064A.Length; i++) { Unknown_0x2064A[i] = reader.ReadByte(); }
          for (int i = 0; i < BuildingActiveAnimationFrames.Length; i++) { BuildingActiveAnimationFrames[i] = reader.ReadByte(); }
          for (int i = 0; i < BuildingBuildupAnimationFrames.Length; i++) { BuildingBuildupAnimationFrames[i] = reader.ReadByte(); }
          Unknown_0x20812 = reader.ReadByte();
          Unknown_0x20813 = reader.ReadByte();
        }
      }
    }

    public void WriteToFile(string destinationPath)
    {
      int countUnit = Marshal.SizeOf(typeof(UnitTemplate));
      int countBuilding = Marshal.SizeOf(typeof(BuildingTemplate));
      int countWeapon = Marshal.SizeOf(typeof(WeaponTemplate));
      int countExplosion = Marshal.SizeOf(typeof(ExplosionTemplate));
      using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
      {
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
          byte[] writeBuffer;
          GCHandle handle;
          for (int i = 0; i < Units.Length; i++)
          {
            writeBuffer = new byte[countUnit];
            handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(Units[i], handle.AddrOfPinnedObject(), true);
            writer.Write(writeBuffer, 0, writeBuffer.Length);
            handle.Free();
          }

          for (int i = 0; i < Buildings.Length; i++)
          {
            writeBuffer = new byte[countBuilding];
            handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(Buildings[i], handle.AddrOfPinnedObject(), true);
            writer.Write(writeBuffer, 0, writeBuffer.Length);
            handle.Free();
          }

          for (int i = 0; i < Weapons.Length; i++)
          {
            writeBuffer = new byte[countWeapon];
            handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(Weapons[i], handle.AddrOfPinnedObject(), true);
            writer.Write(writeBuffer, 0, writeBuffer.Length);
            handle.Free();
          }

          for (int i = 0; i < Explosions.Length; i++)
          {
            writeBuffer = new byte[countExplosion];
            handle = GCHandle.Alloc(writeBuffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(Explosions[i], handle.AddrOfPinnedObject(), true);
            writer.Write(writeBuffer, 0, writeBuffer.Length);
            handle.Free();
          }


          for (int i = 0; i < UnitArtFrames.Length; i++) { writer.Write(UnitArtFrames[i]); }
          for (int i = 0; i < UnitArtDirections.Length; i++) { writer.Write(UnitArtDirections[i]); }
          writer.Write(UnitArtCount);
          writer.Write(UnitCount);
          writer.Write(AnimationArtCount);
          for (int i = 0; i < AnimationFrames.Length; i++) { writer.Write(AnimationFrames[i]); }
          writer.Write(Unknown_0xB189);
          writer.Write(Unknown_0xB18A);
          for (int i = 0; i < ProjectileArtDirections.Length; i++) { writer.Write(ProjectileArtDirections[i]); }
          writer.Write(ProjectileArtCount);
          writer.Write(BuildingArtCount);
          for (int i = 0; i < BuildingArtDirections.Length; i++) { writer.Write(BuildingArtDirections[i]); }
          writer.Write(BuildingCount);
          for (int i = 0; i < BuildingNames.Length; i++) { WriterFixedString(writer, BuildingNames[i], 0x1c2); }
          for (int i = 0; i < WeaponNames.Length; i++) { WriterFixedString(writer, WeaponNames[i] ,  0x32); }
          for (int i = 0; i < ExplosionNames.Length; i++) { WriterFixedString(writer, ExplosionNames[i], 0x32); }
          for (int i = 0; i < UnitNames.Length; i++) { WriterFixedString(writer, UnitNames[i], 0x1c2); }
          for (int i = 0; i < UnitTypeNames.Length; i++) { WriterFixedString(writer, UnitTypeNames[i], 0x32); }
          for (int i = 0; i < BuildingTypeNames.Length; i++) { WriterFixedString(writer, BuildingTypeNames[i], 0x32); }
          for (int i = 0; i < Unknown_0x205F4.Length; i++) { writer.Write(Unknown_0x205F4[i]); }
          for (int i = 0; i < Unknown_0x2064A.Length; i++) { writer.Write(Unknown_0x2064A[i]); }
          for (int i = 0; i < BuildingActiveAnimationFrames.Length; i++) { writer.Write(BuildingActiveAnimationFrames[i]); }
          for (int i = 0; i < BuildingBuildupAnimationFrames.Length; i++) { writer.Write(BuildingBuildupAnimationFrames[i]); }
          writer.Write(Unknown_0x20812);
          writer.Write(Unknown_0x20813);
        }
      }
    }

    private string ReadFixedString(BinaryReader reader, int length)
    {
      return new string(reader.ReadChars(length)).Trim('\0');
    }

    private void WriterFixedString(BinaryWriter writer, string value, int length)
    {
      if (value == null) { value = ""; }

      for (int i = 0; i < length; i++)
      {
        if (i < value.Length)
        {
          writer.Write(value[i]);
        }
        else
        {
          writer.Write('\0');
        }
      }
    }
  }
}
