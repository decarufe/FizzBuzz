using System;
using System.Linq;
using FizzBuzz.Helpers;

namespace FizzBuzz.Generators
{
    class WithImplicitConversion : IGenerator
    {
        private Action<string> _todo;

        public WithImplicitConversion(Action<string> todo)
        {
            _todo = s =>
            {
                Console.WriteLine(s);
                todo(s);
            };
        }

        public void Generate(int count)
        {
            Console.WriteLine("=== implicit conversion trick ===");

            Enumerable.Range(1, count)
                .Select(n => (string) (FizzBuzzer) n)
                .ForEach(_todo);
        }
    }
}