using Dune2000.Enums;

namespace Dune2000.Structs.Uib
{
  public readonly struct MenusUibData
  {
    public readonly string Menu;
    public readonly FadeAction FadeIn;
    public readonly FadeAction FadeOut;

    public MenusUibData(string menu, FadeAction fadeIn, FadeAction fadeOut)
    {
      Menu = menu;
      FadeIn = fadeIn;
      FadeOut = fadeOut;
    }
  }
}
