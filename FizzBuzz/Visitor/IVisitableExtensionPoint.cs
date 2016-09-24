using FizzBuzz.Extensions;

namespace FizzBuzz.Visitor
{
  /// <summary>
  ///   Specialized extension point interface for visitable objects.
  /// </summary>
  /// <typeparam name="T">The type of objects to extend.</typeparam>
  public interface IVisitableExtensionPoint<out T> : IExtensionPoint<T>
  {
  }
}