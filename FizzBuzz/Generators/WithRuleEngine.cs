using System;
using FizzBuzz.Helpers;

namespace FizzBuzz.Generators
{
    class WithRuleEngine : IGenerator
    {
        private readonly Action<string> _todo;
        private static RuleEngine _engine;

        public WithRuleEngine(Action<string> todo)
        {
            _todo = s =>
            {
                Console.WriteLine(s);
                todo(s);
            };
            _engine = new RuleEngine();
            _engine.AddRule<FizzRule>();
            _engine.AddRule<BuzzRule>();
        }

        public void Generate(int count)
        {
            Console.WriteLine("=== Rule Engine ===");

            for (int i = 1; i <= count; i++)
            {
                Payload payload = i;
                _engine.ApplyRulesTo(payload);
                _todo(payload.ToString());
            }
        }
    }
}