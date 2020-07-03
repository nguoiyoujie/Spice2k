using Primrose.Primitives.Pipelines;
using System;

namespace Dune2000.Launcher.UI
{
  public class UIPipedObject : IPipedObject
  {
    public UIPipedObject(Action action)
    {
      _action = action;
    }

    private readonly Action _action;

    public void Execute()
    {
      _action?.Invoke();
    }
  }
}
