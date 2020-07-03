using Dune2000.Extensions.Missions;
using Dune2000.Extensions.Mount;
using Dune2000.Launcher.UI;
using Primrose;
using Primrose.Primitives.Factories;
using System;
using System.Diagnostics;

namespace Dune2000.Launcher
{
  public class Engine
  {
    public const string SETTINGS_PATH = @"./config.ini";
    public const string ERROR_LOG_CH = @"error";
    public const string DEBUG_LOG_CH = @"debug";

    public const string GAME_LOG_ERR = @"dune2000_err";
    public const string GAME_LOG_OUT = @"dune2000_out";

    public ErrorDelegate EncounteredError;

    private MountInfo _mount;
    private Process _gameProcess;

    public bool LoadMount()
    {
      return Handle(MountInfo.CreateFromConfig(SETTINGS_PATH, out _mount));
    }

    public void LaunchGame()
    {
      _gameProcess = _mount.Run(GAME_LOG_OUT, GAME_LOG_ERR);
    }

    public bool IsGameInProcess { get { return _gameProcess != null && !_gameProcess.HasExited; } }

    public string GetUibText(string key)
    {
      return _mount.TextUib.GetFirst(key);
    }

    public bool ImportMissions(out MissionSet[] missionSet, Predicate<MissionSet> filter)
    {
      return Handle(_mount.ImportMissions(out missionSet, filter));
    }

    public bool ImportMissions<T>(out Registry<T, MissionSet[]> sortedMissions, Func<MissionSet, T> filter)
    {
      return Handle(_mount.ImportMissions(out sortedMissions, filter));
    }

    public void LaunchGame(MissionSet missionSet)
    {
      if (!Handle(_mount.MountFiles(missionSet.Source))) { return; }
      if (!Handle(_mount.WriteSpawnFile(missionSet))) { return; }
      _gameProcess = _mount.RunSpawn(GAME_LOG_OUT, GAME_LOG_ERR);
    }

    public bool Handle(MountResult result)
    {
      if (result.Result == MountErrorType.SUCCESS) { return true; }
      HandleError(result.Description, result.InnerException);
      return false;
    }

    internal void HandleError(Exception ex) { HandleError(ex.Message, ex); }

    internal void HandleError(string errorMessage, Exception ex)
    {
      // log
      Log.Write(ERROR_LOG_CH, errorMessage);
      Log.WriteErr(ERROR_LOG_CH, ex);

      // send message to UI
      EncounteredError?.Invoke(errorMessage, ex);
    }
  }
}
