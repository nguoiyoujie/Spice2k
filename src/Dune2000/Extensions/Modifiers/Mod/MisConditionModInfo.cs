using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Primrose.FileFormat.INI;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public struct MisConditionModInfo
  {
    [INIHeader]
    public string Name;

    [INIValue(Required = true)]
    public ConditionType Type;

    [INIValue(Required = true)]
    public int Index;

    [INIValue]
    public uint2? Position;

    [INIValue]
    public uint? Value;

    [INIValue]
    public uint? Time;

    [INIValue]
    public uint? InitialDelay;

    [INIValue]
    public Compare? Compare;

    [INIValue]
    public uint? RunCount;

    [INIValue]
    public House? House;

    [INIValue]
    public uint? Minimum;

    [INIValue]
    public float? Ratio;

    [INIValue]
    public Building? Building;

    [INIValue]
    public Unit? Unit;


    public ModEntry<MisFile> CreateEntry()
    {
      switch (Type)
      {
        case ConditionType.BASEDESTROYED:
        case ConditionType.UNITSRESTROYED:
          {
            Mis_IsDestroyedModEntry destr = new Mis_IsDestroyedModEntry
            {
              Index = Index,
              State = Mis_IsDestroyedModEntry.ObjectTypeExt.FromConditionType(Type),
              House = House
            };
            return destr;
          }

        case ConditionType.BUILDINGEXISTS:
          {
            Mis_DoesBuildingExistModEntry bldext = new Mis_DoesBuildingExistModEntry
            {
              Index = Index, 
              Building = Building
            };
            return bldext;
          }

        case ConditionType.UNITEXISTS:
          {
            Mis_DoesUnitExistModEntry untext = new Mis_DoesUnitExistModEntry
            {
              Index = Index,
              Unit = Unit
            };
            return untext;
          }

        case ConditionType.CASUALTIES:
          {
            Mis_HasCasualitiesModEntry csulty = new Mis_HasCasualitiesModEntry
            {
              Index = Index, 
              House = House, 
              Minimum = Minimum,
              Ratio = Ratio
            };
            return csulty;
          }

        case ConditionType.HARVESTED:
          {
            Mis_HarvestedSpice credit = new Mis_HarvestedSpice
            {
              Index = Index,
              Value = Value
            };
            return credit;
          }


        case ConditionType.TIMER:
          {
            Mis_IsTimerReachedModEntry tmcond = new Mis_IsTimerReachedModEntry
            {
              Index = Index,
              Time = Time,
              Compare = Compare
            };
            return tmcond;
          }

        case ConditionType.INTERVAL:
          {
            Mis_IsIntervalReachedModEntry itcond = new Mis_IsIntervalReachedModEntry
            {
              Index = Index,
              Time = Time,
              InitialDelay = InitialDelay,
              RunCount = RunCount
            };
            return itcond;
          }

        case ConditionType.REVEALED:
          {
            Mis_IsTileRevealedModEntry tilerv = new Mis_IsTileRevealedModEntry
            {
              Index = Index,
              Position = Position,
              Unknown = Value ?? 0
            };
            return tilerv;
          }

        case ConditionType.FLAG:
          {
            Mis_FlagModEntry cdflag = new Mis_FlagModEntry
            {
              Index = Index
            };
            return cdflag;
          }

        default:
          throw new InvalidOperationException("Unknown mission condition entry ({0}) found!".F(Type));
      }
    }
  }
}
