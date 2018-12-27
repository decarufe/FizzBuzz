using System;

namespace FizzBuzz.Extensions
{
  public static class Sequential
  {
    public static void Invoke(params Action[] actions)
    {
      foreach (var action in actions)
      {
        action();
      }
    }
  }
}