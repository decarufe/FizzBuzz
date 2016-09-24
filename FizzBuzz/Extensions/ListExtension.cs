using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Extensions
{
  public static class ListExtension
  {
    public static void Merge<TSource, TTarget>(this IList<TTarget> collection,
                                               IEnumerable<TSource> sourceCollection,
                                               Func<TSource, TTarget, bool> match,
                                               Action<TTarget, TTarget> update,
                                               Func<TSource, TTarget> convert)
      where TSource : class
      where TTarget : class
    {
      TSource[] sourceArray = sourceCollection.ToArray();
      for (int i = collection.Count - 1; i >= 0; i--)
      {
        TTarget element = collection[i];

        // See if element was removed from updated collection.
        TSource sourceElement = sourceArray.FirstOrDefault(x => match(x, element));
        if (sourceElement == null)
        {
          // If so, remove element from collection.
          collection.Remove(element);
        }
      }

      foreach (TSource sourceElement in sourceArray)
      {
        // See if a new element was added in the updated collection.
        TTarget oldElement = collection.FirstOrDefault(x => match(sourceElement, x));
        if (oldElement == null)
        {
          // If so, add element to the collection.
          collection.Add(convert(sourceElement));
        }
        else
        {
          // Element exists in both list: copy updated element into old element
          update(convert(sourceElement), oldElement);
        }
      }
    }

    public static void Merge<T>(this IList<T> collection,
                                IEnumerable<T> sourceCollection,
                                Func<T, T, bool> match)
      where T : class
    {
      Merge(collection, sourceCollection, match, (sourceItem, targetItem) => Mapper.Map(sourceItem, targetItem), x => x);
    }

    public static void Merge<T>(this IList<T> collection,
                                IEnumerable<T> sourceCollection,
                                Func<T, T, bool> match,
                                Action<T, T> update)
      where T : class
    {
      Merge(collection, sourceCollection, match, update, x => x);
    }

    public static void Merge<T>(this IList<T> collection, IEnumerable<T> sourceCollection)
      where T : class
    {
      T[] sourceArray = sourceCollection.ToArray();

      for (int i = collection.Count - 1; i >= 0; --i)
      {
        T element = collection[i];

        // See if element was removed from updated collection.
        T sourceElement = sourceArray.FirstOrDefault(x => x.Equals(element));

        if (sourceElement == null)
        {
          // If so, remove element from collection
          collection.Remove(element);
        }
      }

      foreach (T sourceElement in sourceArray)
      {
        // See if a new element was added in the updated collection.
        T oldElement = collection.FirstOrDefault(x => sourceElement.Equals(x));
        if (oldElement == null)
        {
          // If so, add element to the collection.
          collection.Add(sourceElement);
        }
      }
    }

    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> sourceCollection)
    {
      foreach (var item in sourceCollection)
      {
        collection.Add(item);
      }
    }

    public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> predicate)
    {
      var objectsToRemove = collection.Where(predicate).ToList();

      foreach (var objectToRemove in objectsToRemove)
      {
        collection.Remove(objectToRemove);
      }
    }

    public static void Merge<TSource, TTarget>(this ICollection<TTarget> collection,
                                               IEnumerable<TSource> sourceCollection,
                                               Func<TSource, TTarget, bool> match,
                                               Action<TTarget, TTarget> update,
                                               Func<TSource, TTarget> convert)
      where TSource : class
      where TTarget : class
    {
      TSource[] sourceArray = sourceCollection.ToArray();
      for (int i = collection.Count - 1; i >= 0; i--)
      {
        TTarget element = collection.ElementAt(i);

        // See if element was removed from updated collection.
        TSource sourceElement = sourceArray.FirstOrDefault(x => match(x, element));
        if (sourceElement == null)
        {
          // If so, remove element from collection.
          collection.Remove(element);
        }
      }

      foreach (TSource sourceElement in sourceArray)
      {
        // See if a new element was added in the updated collection.
        TTarget oldElement = collection.FirstOrDefault(x => match(sourceElement, x));
        if (oldElement == null)
        {
          // If so, add element to the collection.
          collection.Add(convert(sourceElement));
        }
        else
        {
          // Element exists in both list: copy updated element into old element
          update(convert(sourceElement), oldElement);
        }
      }
    }

    public static void Merge<T>(this ICollection<T> collection,
                                IEnumerable<T> sourceCollection,
                                Func<T, T, bool> match,
                                Action<T, T> update)
      where T : class
    {
      Merge(collection, sourceCollection, match, update, x => x);
    }

    public static void Merge<T>(this ICollection<T> collection, IEnumerable<T> sourceCollection)
      where T : class
    {
      T[] sourceArray = sourceCollection.ToArray();

      for (int i = collection.Count - 1; i >= 0; --i)
      {
        T element = collection.ElementAt(i);

        // See if element was removed from updated collection.
        T sourceElement = sourceArray.FirstOrDefault(x => x.Equals(element));

        if (sourceElement == null)
        {
          // If so, remove element from collection
          collection.Remove(element);
        }
      }

      foreach (T sourceElement in sourceArray)
      {
        // See if a new element was added in the updated collection.
        T oldElement = collection.FirstOrDefault(x => sourceElement.Equals(x));
        if (oldElement == null)
        {
          // If so, add element to the collection.
          collection.Add(sourceElement);
        }
      }
    }
  }
}