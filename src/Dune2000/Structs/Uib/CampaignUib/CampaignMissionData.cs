using Dune2000.Enums;
using Primrose.Primitives.ValueTypes;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Dune2000.Structs.Uib
{
  [StructLayout(LayoutKind.Explicit, Size = 260, Pack = 1)]
  public unsafe struct CampaignMissionData
  {
    public const int MAX_MISSION_STRLEN = 5;
    public const int MAX_AWARDS = 3;
    public const int MAX_SFX_STRLEN = 60;
    public const int MAX_THEME_STRLEN = 8;


    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public byte RegionID1;

    [FieldOffset(1)]
    public byte RegionID2;

    [FieldOffset(2)]
    private fixed byte _missionFile1[MAX_MISSION_STRLEN];

    [FieldOffset(7)]
    private fixed byte _missionFile2[MAX_MISSION_STRLEN];

    [FieldOffset(12)]
    public Direction Unconfirmed_Direction1;

    [FieldOffset(16)]
    public Direction Unconfirmed_Direction2;

    [FieldOffset(20)]
    public int Region1IconX;

    [FieldOffset(24)]
    public int Region1IconY;

    [FieldOffset(28)]
    public int Region2IconX;

    [FieldOffset(32)]
    public int Region2IconY;

    [FieldOffset(36)]
    private fixed byte _regionsAwardedToAtreides[MAX_AWARDS];

    [FieldOffset(39)]
    private fixed byte _regionsAwardedToHarkonnen[MAX_AWARDS];

    [FieldOffset(42)]
    private fixed byte _regionsAwardedToOrdos[MAX_AWARDS];

    [FieldOffset(45)]
    public fixed byte Unknown_45_3[3];

    [FieldOffset(48)]
    public float ScoreMultiplier;

    [FieldOffset(52)]
    public House RegionAnim_House1;

    [FieldOffset(56)]
    public House RegionAnim_House2;

    [FieldOffset(60)]
    public House RegionAnim_House3;

    [FieldOffset(64)]
    private fixed byte _sfx1[MAX_SFX_STRLEN];

    [FieldOffset(124)]
    private fixed byte _sfx2[MAX_SFX_STRLEN];

    [FieldOffset(184)]
    private fixed byte _sfx3[MAX_SFX_STRLEN];

    [FieldOffset(244)]
    private fixed byte _theme[MAX_THEME_STRLEN];

    [FieldOffset(252)]
    public fixed byte Unknown_232_4[4];

    [FieldOffset(256)]
    public House Unconfirmed_MainEnemyHouse;
    #endregion

    public string MissionFile1
    {
      get
      {
        byte[] array = new byte[MAX_MISSION_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _missionFile1[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if ((value + '\0').Length > MAX_MISSION_STRLEN)
          throw new Exception("Input string is limited to " + MAX_MISSION_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_MISSION_STRLEN; i++)
        {
          if (i < array.Length)
            _missionFile1[i] = array[i];
          else
            _missionFile1[i] = 0;
        }
      }
    }

    public string MissionFile2
    {
      get
      {
        byte[] array = new byte[MAX_MISSION_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _missionFile2[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if ((value + '\0').Length > MAX_MISSION_STRLEN)
          throw new Exception("Input string is limited to " + MAX_MISSION_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_MISSION_STRLEN; i++)
        {
          if (i < array.Length)
            _missionFile2[i] = array[i];
          else
            _missionFile2[i] = 0;
        }
      }
    }

    public byte[] RegionsAwardedToAtreides 
    {
      get
      {
        byte[] array = new byte[MAX_AWARDS];
        for (int i = 0; i < array.Length && i < MAX_AWARDS; i++)
          array[i] = _regionsAwardedToAtreides[i];

        return array;
      }

      set
      {
        if (value.Length > MAX_AWARDS)
          throw new Exception("Input is limited to " + MAX_AWARDS + " items");

        for (int i = 0; i < value.Length; i++)
          _regionsAwardedToAtreides[i] = value[i];
      }
    }

    public byte[] RegionsAwardedToHarkonnen
    {
      get
      {
        byte[] array = new byte[MAX_AWARDS];
        for (int i = 0; i < array.Length && i < MAX_AWARDS; i++)
          array[i] = _regionsAwardedToHarkonnen[i];

        return array;
      }

      set
      {
        if (value.Length > MAX_AWARDS)
          throw new Exception("Input is limited to " + MAX_AWARDS + " items");

        for (int i = 0; i < value.Length; i++)
          _regionsAwardedToHarkonnen[i] = value[i];
      }
    }

    public byte[] RegionsAwardedToOrdos
    {
      get
      {
        byte[] array = new byte[MAX_AWARDS];
        for (int i = 0; i < array.Length && i < MAX_AWARDS; i++)
          array[i] = _regionsAwardedToOrdos[i];

        return array;
      }

      set
      {
        if (value.Length > MAX_AWARDS)
          throw new Exception("Input is limited to " + MAX_AWARDS + " items");

        for (int i = 0; i < value.Length; i++)
          _regionsAwardedToOrdos[i] = value[i];
      }
    }

    public int2 Region1IconPosition
    {
      get
      {
        return new int2(Region1IconX, Region1IconY);
      }
      set
      {
        Region1IconX = value.x;
        Region1IconY = value.y;
      }
    }

    public int2 Region2IconPosition
    {
      get
      {
        return new int2(Region2IconX, Region2IconY);
      }
      set
      {
        Region2IconX = value.x;
        Region2IconY = value.y;
      }
    }

    public string SFX1
    {
      get
      {
        byte[] array = new byte[MAX_SFX_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _sfx1[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if ((value + '\0').Length > MAX_SFX_STRLEN)
          throw new Exception("Input string is limited to " + MAX_SFX_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_SFX_STRLEN; i++)
        {
          if (i < array.Length)
            _sfx1[i] = array[i];
          else
            _sfx1[i] = 0;
        }
      }
    }

    public string SFX2
    {
      get
      {
        byte[] array = new byte[MAX_SFX_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _sfx2[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if ((value + '\0').Length > MAX_SFX_STRLEN)
          throw new Exception("Input string is limited to " + MAX_SFX_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_SFX_STRLEN; i++)
        {
          if (i < array.Length)
            _sfx2[i] = array[i];
          else
            _sfx2[i] = 0;
        }
      }
    }

    public string SFX3
    {
      get
      {
        byte[] array = new byte[MAX_SFX_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _sfx3[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if ((value + '\0').Length > MAX_SFX_STRLEN)
          throw new Exception("Input string is limited to " + MAX_SFX_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_SFX_STRLEN; i++)
        {
          if (i < array.Length)
            _sfx3[i] = array[i];
          else
            _sfx3[i] = 0;
        }
      }
    }

    public string Theme
    {
      get
      {
        byte[] array = new byte[MAX_THEME_STRLEN];
        for (int i = 0; i < array.Length; i++)
          array[i] = _theme[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if (value.Length > MAX_THEME_STRLEN)
          throw new Exception("Input string is limited to " + MAX_THEME_STRLEN + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_THEME_STRLEN; i++)
        {
          if (i < array.Length)
            _theme[i] = array[i];
          else
            _theme[i] = 0;
        }
      }
    }
  }
}
