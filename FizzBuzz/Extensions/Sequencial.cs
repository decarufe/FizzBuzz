using System;

namespace FizzBuzz.Extensions
{
  public static class Sequencial
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