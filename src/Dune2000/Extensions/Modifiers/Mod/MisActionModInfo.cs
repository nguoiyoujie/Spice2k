using Dune2000.Enums;
using Dune2000.FileFormats.Mis;
using Primrose.FileFormat.INI;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.ValueTypes;
using System;

namespace Dune2000.Extensions.Modifiers
{
  public struct MisActionModInfo
  {
    [INIHeader]
    public string Name;

    [INIValue(Required = true)]
    public EventType Type;

    [INIValue(Required = true)]
    public int Index;

    [INIValue]
    public uint2? Position;

    [INIValue]
    public uint? Value;

    [INIValue]
    public uint? SoundID;

    [INIValue]
    public House? House;

    [INIValue]
    public House? TargetHouse;

    [INIValue]
    public Allegiance? DiplomaticState;

    [INIValue]
    public EventUnitMission? UnitMission;

    [INIValue]
    public Unit[] Units;

    [INIValue]
    public short? MessageID;

    [INIValue]
    public byte? Radius;

    [INIValue]
    public byte? Flag;

    [INIValue]
    public bool? Enable;

    [INIValue]
    public string Music;


    public ModEntry<MisFile> CreateEntry()
    {
      switch (Type)
      {
        case EventType.DEPLOY:
        case EventType.ADDUNITS:
        case EventType.REINFORCE:
          {
            Mis_ReinforcementActionModEntry reinf = new Mis_ReinforcementActionModEntry
            {
              Index = Index,
              Type = Mis_ReinforcementActionModEntry.ReinforcementTypeExt.FromActionType(Type),
              Position = Position,
              House = House,
              Units = Units,
              UnitMission = UnitMission
            };
            return reinf;
          }

        case EventType.SETATTACKBUILDINGRATE:
        case EventType.SETBUILDRATE:
        case EventType.SETCASH:
        case EventType.SETTECH:
          {
            Mis_SetHouseAttributeModEntry setatr = new Mis_SetHouseAttributeModEntry
            {
              Index = Index,
              Type = Mis_SetHouseAttributeModEntry.AttributeTypeExt.FromActionType(Type),
              House = House,
              Value = Value
            };
            return setatr;
          }

        case EventType.LOSE:
        case EventType.WIN:
          {
            Mis_TriggerMissionStateModEntry setmis = new Mis_TriggerMissionStateModEntry
            {
              Index = Index,
              State = Mis_TriggerMissionStateModEntry.MissionStateExt.FromActionType(Type)
            };
            return setmis;
          }

        case EventType.BESERK:
        case EventType.LEAVE:
          {
            Mis_HouseActionModEntry hseact = new Mis_HouseActionModEntry
            {
              Index = Index,
              Type = Mis_HouseActionModEntry.ActionExt.FromActionType(Type),
              House = House
            };
            return hseact;
          }

        case EventType.ALLEGIANCE:
          {
            Mis_HouseDiplomacyModEntry setdlp = new Mis_HouseDiplomacyModEntry
            {
              Index = Index,
              House = House,
              TargetHouse = TargetHouse,
              DiplomaticState = DiplomaticState
            };
            return setdlp;
          }

        case EventType.PLAY_MUSIC:
          {
            Mis_PlayMusicModEntry playmu = new Mis_PlayMusicModEntry
            {
              Index = Index,
              Music = Music
            };
            return playmu;
          }

        case EventType.PLAYSOUND:
          {
            Mis_PlaySoundModEntry playsd = new Mis_PlaySoundModEntry
            {
              Index = Index,
              SoundID = SoundID
            };
            return playsd;
          }

        case EventType.SHOWMESSAGE:
          {
            Mis_MissionMessageModEntry setmsg = new Mis_MissionMessageModEntry
            {
              Index = Index,
              MessageID = MessageID,
              MessageUnknown = Value ?? 0
            };
            return setmsg;
          }

        case EventType.SETFLAG:
          {
            Mis_SetFlagModEntry setflg = new Mis_SetFlagModEntry
            {
              Index = Index,
              Flag = Flag,
              Enable = Enable
            };
            return setflg;
          }

        case EventType.SHOWTIMER:
          {
            Mis_TimerStartModEntry settim = new Mis_TimerStartModEntry
            {
              Index = Index,
              Time = Value
            };
            return settim;
          }

        case EventType.HIDETIMER:
          {
            Mis_TimerStopModEntry stoptm = new Mis_TimerStopModEntry
            {
              Index = Index
            };
            return stoptm;
          }

        case EventType.REVEAL:
          {
            Mis_MapRevealModEntry reveal = new Mis_MapRevealModEntry
            {
              Index = Index,
              Position = Position,
              Radius = Radius
            };
            return reveal;
          }

        default:
          throw new InvalidOperationException("Unknown mission action entry ({0}) found!".F(Type));
      }
    }
  }
}
