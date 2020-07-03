using System;

namespace Dune2000.Extensions.Mount
{
  public readonly struct MountResult
  {
    public readonly MountErrorType Result;
    public readonly string Description;
    public readonly Exception InnerException;

    public MountResult(MountErrorType result)
    {
      Result = result;
      Description = "";
      InnerException = null;
    }

    public MountResult(MountErrorType result, string description)
    {
      Result = result;
      Description = description;
      InnerException = null;
    }

    public MountResult(MountErrorType result, Exception exception)
    {
      Result = result;
      Description = exception.Message;
      InnerException = exception;
    }

    public MountResult(MountErrorType result, string description, Exception exception)
    {
      Result = result;
      Description = description;
      InnerException = exception;
    }
  }
}
