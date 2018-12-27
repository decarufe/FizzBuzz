using System;

namespace FizzBuzz.Generators
{
    class Without3Or5 : IGenerator
    {
        private readonly Action<string> _todo;

        public Without3Or5(Action<string> todo)
        {
            _todo = s =>
            {
                Console.WriteLine(s);
                todo(s);
            };
        }

        public void Generate(int count)
        {
            var random = new Random(82);
            var rule1 = random.Next(6);
            var rule2 = random.Next(6);
            for (int i = 1; i <= 100; i++)
            {
                if (i % rule1 == 0 && i % rule2 == 0)
                {
                    _todo("FizzBuzz");
                }
                else if (i % rule1 == 0)
                {
                    _todo("Fizz");
                }
                else if (i % rule2 == 0)
                {
                    _todo("Buzz");
                }
                else
                {
                    _todo(i.ToString());
                }
            }
        }
    }
}