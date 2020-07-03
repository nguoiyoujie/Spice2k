using System.Collections.Generic;

namespace Dune2000.Launcher.Util
{
  public static class Cascade
  {
    public static T Pick<T>(T skipValue, T v1)
    {
      if (!EqualityComparer<T>.Default.Equals(skipValue, v1))
        return v1;

      return skipValue;
    }

    public static T Pick<T>(T skipValue, T v1, T v2)
    {
      if (!EqualityComparer<T>.Default.Equals(skipValue, v1))
        return v1;
      else if (!EqualityComparer<T>.Default.Equals(skipValue, v2))
        return v2;

      return skipValue;
    }

    public static T Pick<T>(T skipValue, T v1, T v2, T v3)
    {
      if (!EqualityComparer<T>.Default.Equals(skipValue, v1))
        return v1;
      else if (!EqualityComparer<T>.Default.Equals(skipValue, v2))
        return v2;
      else if (!EqualityComparer<T>.Default.Equals(skipValue, v3))
        return v3;

      return skipValue;
    }

    public static T Pick<T>(T skipValue, params T[] values)
    {
      // Starting from the first value in values, select the first value that is not equal to skipValue. 
      // If all values are equal to skipValue, return skipValue
      foreach (T v in values)
        if (!EqualityComparer<T>.Default.Equals(skipValue, v))
          return v;

      return skipValue;
    }
  }
}
