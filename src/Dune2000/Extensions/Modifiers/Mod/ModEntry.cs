namespace Dune2000.Extensions.Modifiers
{
  public abstract class ModEntry<T>
  {
    public abstract void Apply(ref T target);
  }
}
