using System;

namespace FizzBuzz.Extensions
{
  /// <summary>
  ///   Generic interface definition for an adapter used to provide extension methods to a type without polluting that
  ///   type's own interface.
  /// </summary>
  /// <typeparam name="T">The type for which an extension method should be used.</typeparam>
  public interface IExtensionPoint<out T>
  {
    /// <summary>
    ///   Gets the value for which an extension method should be used.
    /// </summary>
    T ExtendedValue { get; }

    /// <summary>
    ///   Gets the type for which an extension method should be used.
    /// </summary>
    Type ExtendedType { get; }

    /// <summary>
    ///   Method used to ensure that extension points are always used. When implemented, this method should do nothing.
    /// </summary>
    void Disregard();
  }
}