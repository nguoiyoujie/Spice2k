using Dune2000.Enums;
using Primrose.Primitives.ValueTypes;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Dune2000.Structs.Mis
{
  [StructLayout(LayoutKind.Explicit, Size = 72, Pack = 1)]
  public unsafe struct MisAction
  {
    public const int MAX_CONDITIONS = 14;
    public const int MAX_DATA = 25;

    #region Layout // Do not modify unless unless you know what you are doing
    [FieldOffset(0)]
    public uint X;

    [FieldOffset(4)]
    public uint Y;

    [FieldOffset(8)]
    public uint Value; // MessageUnknown, BuildRate, AttackRate, SetCash, Tech, Time

    [FieldOffset(8)]
    public uint SoundID;

    public bool Enable { get { return Value > 0; } set { Value = value ? 1u : 0u; } } // for Flag

    [FieldOffset(12)]
    public byte NumberOfConditions;

    [FieldOffset(13)]
    public EventType Action;

    [FieldOffset(14)]
    public byte NumberOfUnits;

    [FieldOffset(14)]
    public byte RevealMapRadius;

    [FieldOffset(15)]
    public House House;

    [FieldOffset(15)]
    public byte Flag;

    [FieldOffset(16)]
    public House TargetHouse; // for Allegiance

    [FieldOffset(17)]
    public Allegiance Allegiance;

    [FieldOffset(18)]
    public EventUnitMission UnitMission;

    [FieldOffset(19)]
    private fixed byte ConditionIDs[MAX_CONDITIONS];

    [FieldOffset(33)]
    private fixed byte ConditionNegativeSwitches[MAX_CONDITIONS];

    [FieldOffset(47)]
    private fixed byte Data[MAX_DATA];

    [FieldOffset(68)]
    public short MessageID;
    #endregion

    public ConditionType[] Conditions // be careful; the indexing of this object does not reference its source, make sure to set your modified array back to the struct
    {
      get
      {
        int count = NumberOfConditions < MAX_CONDITIONS ? NumberOfConditions : MAX_CONDITIONS;
        ConditionType[] array = new ConditionType[count];
        for (int i = 0; i < array.Length; i++)
          array[i] = (ConditionType)ConditionIDs[i];

        return array;
      }

      set
      {
        if (value.Length > MAX_CONDITIONS)
          throw new Exception("Input is limited to " + MAX_CONDITIONS + " items");

        for (int i = 0; i < value.Length; i++)
          ConditionIDs[i] = (byte)value[i];

        NumberOfConditions = (byte)value.Length;
      }
    }

    public bool[] ConditionFireIfFalse // be careful; the indexing of this object does not reference its source, make sure to set your modified array back to the struct
    {
      get
      {
        int count = NumberOfConditions < MAX_CONDITIONS ? NumberOfConditions : MAX_CONDITIONS;
        bool[] array = new bool[count];
        for (int i = 0; i < array.Length; i++)
          array[i] = ConditionNegativeSwitches[i] != 0;

        return array;
      }

      set
      {
        if (value.Length > MAX_CONDITIONS)
          throw new Exception("Input is limited to " + MAX_CONDITIONS + " items");

        for (int i = 0; i < value.Length; i++)
          ConditionNegativeSwitches[i] = (byte)(value[i] ? 1 : 0);
      }
    }

    public Unit[] Units // be careful; the indexing of this object does not reference its source, make sure to set your modified array back to the struct
    {
      get 
      {
        Unit[] array = new Unit[NumberOfUnits];
        for (int i = 0; i < array.Length && i < NumberOfUnits; i++)
          array[i] = (Unit)Data[i];

        return array;
      }

      set 
      {
        if (value.Length > MAX_DATA)
          throw new Exception("Input is limited to " + MAX_DATA + " items");

        for (int i = 0; i < value.Length; i++)
          Data[i] = (byte)value[i];
      }
    }

    public uint2 Position
    {
      get
      {
        return new uint2(X, Y);
      }
      set
      {
        X = value.x;
        Y = value.y;
      }
    }

    public string Music
    {
      get
      {
        byte[] array = new byte[MAX_DATA];
        for (int i = 0; i < array.Length; i++)
          array[i] = Data[i];

        return Encoding.Default.GetString(array).Trim('\0');
      }
      set
      {
        if (value.Length > MAX_DATA)
          throw new Exception("Input string is limited to " + MAX_DATA + " characters");

        byte[] array = Encoding.Default.GetBytes(value);
        for (int i = 0; i < MAX_DATA; i++)
        {
          if (i < array.Length)
            Data[i] = array[i];
          else
            Data[i] = 0;
        }
      }
    }
  }
}
