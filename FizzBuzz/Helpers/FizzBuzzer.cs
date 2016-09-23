namespace FizzBuzz.Helpers
{
    public struct FizzBuzzer
    {
        private readonly int _value;

        private FizzBuzzer(int value)
        {
            _value = value;
        }

        public static implicit operator FizzBuzzer(int value)
        {
            return new FizzBuzzer(value);
        }

        public static implicit operator string(FizzBuzzer value)
        {
            return value.ToString();
        }

        public override string ToString()
        {
            var result = string.Empty;
            if (_value%3 == 0) result += "Fizz";
            if (_value%5 == 0) result += "Buzz";
            if (string.IsNullOrEmpty(result)) result += _value;
            return result;
        }
    }
}