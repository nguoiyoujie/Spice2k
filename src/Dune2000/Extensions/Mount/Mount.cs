using Dune2000.FileFormats.INI;
using Dune2000.FileFormats.Map;
using Dune2000.FileFormats.Mis;
using Dune2000.FileFormats.Uib;
using Dune2000.Extensions.FileFormats.INI;
using Dune2000.Extensions.Modifiers;
using Primrose;
using Primrose.FileFormat.INI;
using Primrose.Primitives.Extensions;
using Primrose.Primitives.Factories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using Dune2000.Extensions.Missions;

namespace Dune2000.Extensions.Mount
{
  /// <summary>
  /// Represents the location and information sourced from the game directory
  /// </summary>
  public class MountInfo
  {
    public const string RESOURCE_PATH = "resource.cfg";
    public const string SPAWN_PATH = "spawn.ini";
    public const string SPAWN_ARG = "-SPAWN";
    public const string RESERVED_MISSION_NAME = "MOUNT"; // we write the files to the game directory under a reserved name, so we do not overwrite the precious.
    public const string RULESFILE_EXT = ".ini";
    public const string MAPFILE_EXT = ".map";
    public const string MISFILE_EXT = ".mis";
    public const string MODFILE_EXT = ".md";
    public const string RULESFILE_FORMAT = @"{0}/{1}" + RULESFILE_EXT;
    public const string MAPFILE_FORMAT = @"{0}/{1}" + MAPFILE_EXT;
    public const string MISFILE_FORMAT = @"{0}/_{1}" + MISFILE_EXT;
    public const string MODFILE_FORMAT = @"{0}/{1}" + MODFILE_EXT;

    public readonly string MainDir;
    public readonly string ExecutablePath;
    public readonly string SpawnerPath;
    public readonly string SpawnerArgs;

    public readonly string DataDir;
    public readonly string MoviesDir;
    public readonly string MusicDir;
    public readonly string MissionDir;
    public readonly string MapDir;

    public readonly string Language;
    public readonly TextUibFile TextUib;


    private MountInfo(string executablePath, string resourcePath)
    {
      ExecutablePath = executablePath;
      MainDir = Path.GetDirectoryName(executablePath);
      SpawnerPath = Path.Combine(MainDir, SPAWN_PATH);
      SpawnerArgs = SPAWN_ARG;

      string[] resourcePaths = File.ReadAllLines(resourcePath);

      DataDir = Path.Combine(MainDir, resourcePaths[0]);
      MoviesDir = Path.Combine(MainDir, resourcePaths[1]);
      MusicDir = Path.Combine(MainDir, resourcePaths[2]);
      MissionDir = Path.Combine(MainDir, resourcePaths[3]);
      MapDir = Path.Combine(MainDir, resourcePaths[4]);

      string iniPath = Path.Combine(MainDir, Path.GetFileNameWithoutExtension(executablePath) + ".ini");
      if (File.Exists(iniPath))
      {
        INIFile f = new INIFile(iniPath);
        Language = f.GetString("Options", "Language", "");
      }
      else
      {
        Language = "";
      }
      
      TextUib = new TextUibFile();
      TextUib.ReadFromFile(Path.Combine(DataDir, "UI_DATA", "text{0}.uib".F(Language)));
    }

    public static MountResult CreateFromConfig(string configPath, out MountInfo mount)
    {
      mount = null;
      if (!File.Exists(configPath)) { return new MountResult(MountErrorType.CONFIG_NOTFOUND, Resource.Strings.MountError_CONFIG_NOTFOUND.F(configPath)); }

      LauncherSettingsFile sFile = new LauncherSettingsFile();
      try
      {
        sFile.ReadFromFile(configPath);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.CONFIG_READ_ERROR, Resource.Strings.MountError_CONFIG_READ_ERROR, ex);
      }
      return Create(sFile.ExecutablePath, out mount);
    }

    public static MountResult Create(string executablePath, out MountInfo mount)
    {
      mount = null;
      if (!File.Exists(executablePath)) { return new MountResult(MountErrorType.EXECUTABLE_NOTFOUND, Resource.Strings.MountError_EXECUTABLE_NOTFOUND.F(executablePath ?? Resource.Strings.Undefined)); }

      string resourcePath = Path.Combine(Path.GetDirectoryName(executablePath), RESOURCE_PATH);
      if (!File.Exists(resourcePath)) { return new MountResult(MountErrorType.RESOURCE_NOTFOUND, Resource.Strings.MountError_RESOURCE_NOTFOUND.F(resourcePath ?? Resource.Strings.Undefined)); }

      try
      {
        mount = new MountInfo(executablePath, resourcePath);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.RESOURCE_READ_ERROR, Resource.Strings.MountError_RESOURCE_READ_ERROR.F(RESOURCE_PATH), ex);
      }
      return new MountResult(MountErrorType.SUCCESS);
    }

    public MountResult ImportMissions(out MissionSet[] missions, Predicate<MissionSet> filter = null)
    {
      return ImportMissions(MissionDir, out missions, filter);
    }

    public MountResult ImportMissions<T>(out Registry<T, MissionSet[]> sortedMissions, Func<MissionSet, T> filter)
    {
      return ImportMissions(MissionDir, out sortedMissions, filter);
    }

    public MountResult ImportMissions(string directoryPath, out MissionSet[] missions, Predicate<MissionSet> filter = null)
    {
      missions = null;
      List<MissionSet> list = new List<MissionSet>();
      if (directoryPath == null || !Directory.Exists(directoryPath) || File.Exists(directoryPath))
      {
        return new MountResult(MountErrorType.INVALID_DIRECTORY, Resource.Strings.MountError_INVALID_DIRECTORY.F(directoryPath));
      }

      List<string> errorList = new List<string>();
      foreach (string p in Directory.GetFiles(directoryPath, "*" + RULESFILE_EXT, SearchOption.AllDirectories))
      {
        try
        {
          string dir = Path.GetDirectoryName(p);
          string name = Path.GetFileNameWithoutExtension(p);

          string sMap = MAPFILE_FORMAT.F(dir, name);
          string sMis = MISFILE_FORMAT.F(dir, name);
          string sMod = MODFILE_FORMAT.F(dir, name);

          // Ignore the set if either the map or the mis file does not exist
          if (!File.Exists(sMap) || !File.Exists(sMis)) { continue; }

          // The mod file is optional, exclude it if not present
          if (!File.Exists(sMod)) { sMod = null; }

          MissionSourceInfo srcInfo = new MissionSourceInfo(sMap, sMis, p, sMod);

          // load rules file into memory (if some error occurs, ignore this set)
          MapRulesFile rulf = new MapRulesFile();
          try
          {
            rulf.ReadFromFile(p);
            MissionInfo misInfo = rulf.RetrieveInfo();
            MissionSet set = new MissionSet(misInfo, srcInfo);

            if (filter == null || filter(set))
              list.Add(set);
          }
          catch
          {
            errorList.Add(p);
            continue;
          }
        }
        catch
        {
          errorList.Add(p);
          continue;
        }
      }

      missions = list.ToArray();
      if (errorList.Count > 0) { return new MountResult(MountErrorType.PARTIAL_ERROR, Resource.Strings.MountError_PARTIAL_ERROR.F(errorList.Count)); }
      return new MountResult(MountErrorType.SUCCESS);
    }

    public MountResult ImportMissions<T>(string directoryPath, out Registry<T, MissionSet[]> sortedMissions, Func<MissionSet, T> filter)
    {
      sortedMissions = new Registry<T, MissionSet[]>();
      Registry<T, List<MissionSet>> temp = new Registry<T, List<MissionSet>>();
      if (directoryPath == null || !Directory.Exists(directoryPath) || File.Exists(directoryPath))
      {
        return new MountResult(MountErrorType.INVALID_DIRECTORY, Resource.Strings.MountError_INVALID_DIRECTORY.F(directoryPath));
      }

      List<string> errorList = new List<string>();
      foreach (string p in Directory.GetFiles(directoryPath, "*" + RULESFILE_EXT, SearchOption.AllDirectories))
      {
        try
        {
          string dir = Path.GetDirectoryName(p);
          string name = Path.GetFileNameWithoutExtension(p);

          string sMap = MAPFILE_FORMAT.F(dir, name);
          string sMis = MISFILE_FORMAT.F(dir, name);
          string sMod = MODFILE_FORMAT.F(dir, name);

          // Ignore the set if either the map or the mis file does not exist
          if (!File.Exists(sMap) || !File.Exists(sMis)) { continue; }

          // The mod file is optional, exclude it if not present
          if (!File.Exists(sMod)) { sMod = null; }

          MissionSourceInfo srcInfo = new MissionSourceInfo(sMap, sMis, p, sMod);

          // load rules file into memory (if some error occurs, ignore this set)
          MapRulesFile rulf = new MapRulesFile();
          try
          {
            rulf.ReadFromFile(p);
            MissionInfo misInfo = rulf.RetrieveInfo();
            MissionSet set = new MissionSet(misInfo, srcInfo);

            T t = filter(set);
            if (t != null)
            {
              if (temp.Contains(t)) { temp[t].Add(set); }
              else { temp.Add(t, new List<MissionSet> { set }); }
            }
          }
          catch
          {
            errorList.Add(p);
            continue;
          }
        }
        catch
        {
          errorList.Add(p);
          continue;
        }
      }

      foreach (T t in temp.GetKeys())
      {
        sortedMissions.Put(t, temp[t].ToArray());
      }

      if (errorList.Count > 0) { return new MountResult(MountErrorType.PARTIAL_ERROR, Resource.Strings.MountError_PARTIAL_ERROR.F(errorList.Count)); }
      return new MountResult(MountErrorType.SUCCESS);
    }


    public MountResult MountFiles(MissionSourceInfo srcInfo)
    {
      // load map file into memory
      MapFile mapf = new MapFile();
      if (srcInfo.Map == null) { return new MountResult(MountErrorType.MAP_UNDEFINED, Resource.Strings.MountError_MAP_UNDEFINED); }
      if (!File.Exists(srcInfo.Map)) { return new MountResult(MountErrorType.MAP_NOTFOUND, Resource.Strings.MountError_MAP_NOTFOUND.F(srcInfo.Map)); }
      try
      {
        mapf.ReadFromFile(srcInfo.Map);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.MAP_READ_ERROR, Resource.Strings.MountError_MAP_READ_ERROR, ex);
      }

      // load mis file into memory
      MisFile misf = new MisFile();
      if (srcInfo.Mis == null) { return new MountResult(MountErrorType.MIS_UNDEFINED, Resource.Strings.MountError_MIS_UNDEFINED); }
      if (!File.Exists(srcInfo.Mis)) { return new MountResult(MountErrorType.MIS_NOTFOUND, Resource.Strings.MountError_MIS_NOTFOUND.F(srcInfo.Mis)); }
      try
      {
        misf.ReadFromFile(srcInfo.Mis);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.MIS_READ_ERROR, Resource.Strings.MountError_MIS_READ_ERROR, ex);
      }

      // load (optional) rules file into memory
      MapRulesFile rulf = new MapRulesFile();
      if (srcInfo.Rules != null)
      {
        if (!File.Exists(srcInfo.Rules)) { return new MountResult(MountErrorType.RULES_NOTFOUND, Resource.Strings.MountError_RULES_NOTFOUND.F(srcInfo.Rules)); }
        try
        {
          rulf.ReadFromFile(srcInfo.Rules);
        }
        catch (Exception ex)
        {
          return new MountResult(MountErrorType.RULES_READ_ERROR, Resource.Strings.MountError_RULES_READ_ERROR, ex);
        }
      }

      // load (optional) mod file into memory
      if (srcInfo.Mod != null)
      {
        if (!File.Exists(srcInfo.Mod)) { return new MountResult(MountErrorType.MOD_NOTFOUND, Resource.Strings.MountError_MOD_NOTFOUND.F(srcInfo.Mod)); }
        ModFile modf = new ModFile();
        try
        {
          modf.ReadFromFile(srcInfo.Mod);
        }
        catch (Exception ex)
        {
          return new MountResult(MountErrorType.MOD_READ_ERROR, Resource.Strings.MountError_MOD_READ_ERROR, ex);
        }

        // apply mod
        try
        {
          Mod mod = modf.CreateMod();
          mod.Apply(ref mapf, ref misf);
        }
        catch (Exception ex)
        {
          return new MountResult(MountErrorType.MOD_ERROR, Resource.Strings.MountError_MOD_ERROR, ex);
        }
      }

      // define target paths
      string mapPath = MAPFILE_FORMAT.F(MissionDir, RESERVED_MISSION_NAME);
      string misPath = MISFILE_FORMAT.F(MissionDir, RESERVED_MISSION_NAME);
      string rulPath = RULESFILE_FORMAT.F(MissionDir, RESERVED_MISSION_NAME);

      // write map
      try
      {
        mapf.WriteToFile(mapPath);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.MAP_WRITE_ERROR, Resource.Strings.MountError_MAP_WRITE_ERROR, ex);
      }

      // write mis
      try
      {
        misf.WriteToFile(misPath);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.MIS_WRITE_ERROR, Resource.Strings.MountError_MIS_WRITE_ERROR, ex);
      }

      // write rules, if defined
      if (srcInfo.Rules != null)
      {
        try
        {
          rulf.WriteToFile(rulPath);
        }
        catch (Exception ex)
        {
          return new MountResult(MountErrorType.RULES_WRITE_ERROR, Resource.Strings.MountError_RULES_WRITE_ERROR, ex);
        }
      }

      return new MountResult(MountErrorType.SUCCESS);
    }

    public MountResult WriteSpawnFile(MissionSet mission)
    {
      SpawnerFile spfile = new SpawnerFile
      {
        Scenario = RESERVED_MISSION_NAME,
        MySideID = (int)mission.Info.House,
        MissionNumber = mission.Info.MissionNumber,
        DifficultyLevel = (int)mission.Difficulty,
        Seed = new Random().Next(2147483647)
      };

      try
      {
        spfile.WriteToFile(SpawnerPath);
      }
      catch (Exception ex)
      {
        return new MountResult(MountErrorType.SPAWNER_WRITE_ERROR, Resource.Strings.MountError_SPAWNER_WRITE_ERROR, ex);
      }
      return new MountResult(MountErrorType.SUCCESS);
    }

    public Process Run(string log_out, string log_err) { return CreateProcess(null, log_out, log_err); }
    public Process RunSpawn(string log_out, string log_err) { return CreateProcess(SpawnerArgs, log_out, log_err); }

    private Process CreateProcess(string arguments, string log_out, string log_err)
    {
      // in case of insanity
      if (!File.Exists(ExecutablePath)) { throw new InvalidOperationException(Resource.Strings.MountError_EXECUTABLE_NOTFOUND.F(ExecutablePath)); }

      ProcessStartInfo processStartInfo = new ProcessStartInfo(ExecutablePath)
      {
        Arguments = arguments,
        WorkingDirectory = MainDir
      };

      if (Environment.OSVersion.Version >= new Version(6, 2, 9200, 0))
      {
        StringDictionary environmentVariables;
        (environmentVariables = processStartInfo.EnvironmentVariables)["__COMPAT_LAYER"] = environmentVariables["__COMPAT_LAYER"] + "DWM8And16BitMitigation 16BITCOLOR ";
        processStartInfo.UseShellExecute = false;
      }
      return Start(processStartInfo, log_out, log_err);
    }

    private Process Start(ProcessStartInfo pInfo, string log_out, string log_err)
    {
      Process p = Process.Start(pInfo);
      p.EnableRaisingEvents = true;

      if (log_out != null)
      {
        p.StartInfo.RedirectStandardOutput = true;
        p.OutputDataReceived += (o, e) => Log.Write(log_out, e.Data);
        p.Exited += (o, e) => Log.Write(log_out, "Game exited at {0} with exit code {1}".F(DateTime.Now, p.ExitCode));
      }

      if (log_err != null)
      {
        p.StartInfo.RedirectStandardError = true;
        p.ErrorDataReceived += (o, e) => Log.Write(log_err, e.Data);
      }
      return p;
    }
  }
}
