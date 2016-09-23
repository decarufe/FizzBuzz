using System;
using System.Linq;

namespace FizzBuzz
{
    class WithLinq : IGenerator
    {
        private readonly Action<string> _todo;

        public WithLinq(Action<string> todo)
        {
            _todo = s =>
            {
                Console.WriteLine(s);
                todo(s);
            };
        }

        public void Generate(int count)
        {
            Console.WriteLine("=== Linq with string.Join ===");

            var result = from source in Enumerable.Range(1, count)
                let fizz = source%3 == 0 ? "Fizz" : ""
                let buzz = source%5 == 0 ? "Buzz" : ""
                let number = (fizz + buzz).Length == 0 ? source.ToString() : ""
                select fizz + buzz + number;
            result.ForEach(_todo);
        }
    }
}