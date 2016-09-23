using System;
using System.Linq;

namespace FizzBuzz
{
    class ImplicitConversion : IGenerator
    {
        private Action<string> _todo;

        public ImplicitConversion(Action<string> todo)
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