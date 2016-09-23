using System.Collections.Generic;

namespace FizzBuzz.Helpers
{
    public class RuleEngine
    {
        private IList<IRule> _rules = new List<IRule>();

        public void AddRule<TRule>() where TRule : IRule, new()
        {
            _rules.Add(new TRule());
        }

        public void ApplyRulesTo(Payload payload)
        {
            foreach (var rule in _rules)
            {
                rule.Apply(payload);
            }
        }
    }
}
