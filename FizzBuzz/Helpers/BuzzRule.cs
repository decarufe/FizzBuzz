namespace FizzBuzz.Helpers
{
    public class BuzzRule : IRule
    {
        public void Apply(Payload payload)
        {
            if (payload.Value % 5 == 0) payload.Write("Buzz");
        }
    }
}