using System;

namespace FizzBuzz.Extensions
{
  public class ExtensionPoint<T> : IExtensionPoint<T>
  {
    private readonly T _extendedValue;

    public ExtensionPoint(T extendedValue)
    {
      _extendedValue = extendedValue;
    }

    public T ExtendedValue
    {
      get { return _extendedValue; }
    }

    public Type ExtendedType
    {
      get { return typeof (T); }
    }

    public void Disregard()
    {
    }
  }
}