using System.Text;

namespace FizzBuzz.Helpers
{
    public class Payload
    {
        private readonly int _value;
        private StringBuilder _output = new StringBuilder();

        private Payload(int value)
        {
            _value = value;
        }

        public void Write(string message)
        {
            _output.AppendFormat("{0}", message);
        }

        public int Value
        {
            get { return _value; }
        }

        public static implicit operator Payload(int value)
        {
            return new Payload(value);
        }

        private string Output
        {
            get
            {
                if (_output.Length == 0) return _value.ToString();
                return _output.ToString();
            }
        }

        public override string ToString()
        {
            return Output;
        }
    }
}