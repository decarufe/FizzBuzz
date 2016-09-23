namespace FizzBuzz.Helpers
{
    public class FizzRule : IRule
    {
        public void Apply(Payload payload)
        {
            if (payload.Value % 3 == 0) payload.Write("Fizz");
        }
    }
}