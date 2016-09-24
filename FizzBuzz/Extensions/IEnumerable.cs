using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Extensions
{
  public static class IEnumerable
  {
    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> match)
    {
      return !source.Any(match);
    }

    public static IEnumerable<TSource> NonIntersect<TSource>(this IEnumerable<TSource> source,
                                                             IEnumerable<TSource> input,
                                                             IEqualityComparer<TSource> comparer)
    {
      var enumerable = input as TSource[] ?? input.ToArray();
      var sources = source as TSource[] ?? source.ToArray();
      return sources.Except(enumerable, comparer).Union(enumerable.Except(sources, comparer));
    }
  }
}