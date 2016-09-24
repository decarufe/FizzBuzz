using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Extensions
{
  public static class ObjectExtensions
  {
    public static bool IsIn<T>(this T obj, IEnumerable<T> items)
    {
      return items.Contains(obj);
    }

    public static bool IsNotIn<T>(this T obj, IEnumerable<T> items)
    {
      return !obj.IsIn(items);
    }
  }
}