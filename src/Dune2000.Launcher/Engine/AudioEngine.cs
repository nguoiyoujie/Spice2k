using Primrose.Primitives.Extensions;
using System.IO;
using System.Media;

namespace Dune2000.Launcher
{
  public static class AudioEngine
  {
    // basic audio, wav only.
    private static readonly SoundPlayer _soundPlayer = new SoundPlayer();
    private static readonly SoundPlayer _clickPlayer = new SoundPlayer();
    private static readonly SoundPlayer _musicPlayer = new SoundPlayer();

    public const string FMT_WAV = "{0}.wav";
    public const string MUSIC_DIRECTORY = @"./assets/music/";
    public const string SOUND_DIRECTORY = @"./assets/sounds/";

    static AudioEngine()
    {
      try
      {
        _clickPlayer.SoundLocation = GetSound(AudioGlobals.Sound_Click);
        _clickPlayer.Load();
      }
      catch { }
    }

    public static void Click()
    {
      try
      {
        _clickPlayer.Play();
      }
      catch { }
    }

    public static void PlayMusic(string musicName)
    {
      try
      {
        _musicPlayer.Stop();
        _musicPlayer.SoundLocation = GetMusic(musicName);
        _musicPlayer.PlayLooping();
      }
      catch { }
    }

    public static void StopMusic()
    {
      try
      {
        _musicPlayer.Stop();
      }
      catch { }
    }

    public static void PlaySound(string soundName)
    {
      try
      {
        _soundPlayer.Stop();
        _soundPlayer.SoundLocation = GetSound(soundName);
        _soundPlayer.Play();
      }
      catch { }
    }

    public static void StopSound()
    {
      try
      {
        _soundPlayer.Stop();
      }
      catch { }
    }

    private static string GetMusic(string musicName)
    {
      return Path.Combine(MUSIC_DIRECTORY, FMT_WAV.F(musicName));
    }

    private static string GetSound(string soundName)
    {
      return Path.Combine(SOUND_DIRECTORY, FMT_WAV.F(soundName));
    }
  }
}
