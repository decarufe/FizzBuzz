using System;
using System.Linq;
using FizzBuzz.Helpers;

namespace FizzBuzz.Generators
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
                let fizz = source%3 == 0 ? "Fizz" : string.Empty
                let buzz = source%5 == 0 ? "Buzz" : string.Empty
                let number = (fizz + buzz).Length == 0 ? source.ToString() : string.Empty
                select String.Join(string.Empty, fizz, buzz, number);
            result.ForEach(_todo);
        }
    }
}