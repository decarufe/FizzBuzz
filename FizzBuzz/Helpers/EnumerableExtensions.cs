using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Helpers
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            var forEach = enumerable.ToArray();
            foreach (var item in forEach)
            {
                action(item);
            }
            return forEach;
        }
    }
}