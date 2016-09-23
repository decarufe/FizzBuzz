using System;

namespace FizzBuzz.Generators
{
    class WithForLoopWithIfElse : IGenerator
    {
        private readonly Action<string> _todo;

        public WithForLoopWithIfElse(Action<string> todo)
        {
            _todo = s =>
            {
                Console.WriteLine(s);
                todo(s);
            };
        }

        public void Generate(int count)
        {
            Console.WriteLine("=== Standard for loop with if else ===");

            for (int i = 1; i <= count; i++)
            {
                if (i%3 == 0 && i%5 == 0) _todo("FizzBuzz");
                else if (i%3 == 0) _todo("Fizz");
                else if (i%5 == 0) _todo("Buzz");
                else _todo(i.ToString());
            }
        }
    }
}