namespace FizzBuzz.Visitor
{
  public static class VisitableExtensionPointProvider
  {
    public static IVisitableExtensionPoint<T> AsVisitable<T>(this T toExtend)
    {
      return new VisitableExtensionPoint<T>(toExtend);
    }
  }
}