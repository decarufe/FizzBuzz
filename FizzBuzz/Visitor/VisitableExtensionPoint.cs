using FizzBuzz.Extensions;

namespace FizzBuzz.Visitor
{
  public class VisitableExtensionPoint<T> : ExtensionPoint<T>, IVisitableExtensionPoint<T>
  {
    public VisitableExtensionPoint(T extendedValue)
      : base(extendedValue)
    {
    }
  }
}