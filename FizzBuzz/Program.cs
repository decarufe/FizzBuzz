using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i%3 == 0 && i%5 == 0) Console.WriteLine("FizzBuzz");
                else if (i%3 == 0) Console.WriteLine("Fizz");
                else if (i%5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }

            Console.WriteLine();

            var engine = new RuleEngine();
            engine.AddRule<FizzRule>();
            engine.AddRule<BuzzRule>();

            for (int i = 1; i <= 20; i++)
            {
                Payload payload = i;
                engine.ApplyRulesTo(payload);
                Console.WriteLine(payload);
            }
        }
    }
}
