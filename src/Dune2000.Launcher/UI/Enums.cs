namespace Dune2000.Launcher.UI
{
	public enum AnimateType { NONE, ONCE, ALWAYS }
	public enum MouseState { NONE, HOVER, DOWN }
	public enum PositionType { ABSOLUTE, RELATIVE }
	public enum SizeType { ABSOLUTE, RELATIVE }

  public enum TransitionStyle
  {
    NOFADE,
    FADE_BLACK,
    FADE_TWEEN
  }

  public enum FadeStyle
  {
    NOFADE,
    FADEIN_FROM_BLACK,
    FADEIN_FROM_BACKGROUND,
    FADEOUT_TO_BLACK,
    FADEOUT_TO_BACKGROUND
  }
}
