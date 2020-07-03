using Primrose.Primitives.Pipelines;
using System;

namespace Dune2000.Launcher.UI
{
  public class UIPipeline : Pipeline<UIPipedObject>
  {
    public UIPipeline(int maxExecutionsPerRun = 1) : base(maxExecutionsPerRun) { }

    public void Queue(Action action)
    {
      Queue(new UIPipedObject(action));
    }
  }
}
