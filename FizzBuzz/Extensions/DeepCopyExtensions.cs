using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FizzBuzz.Extensions
{
  public static class DeepCopyExtensions
  {
    public static T DeepCopy<T>(this T obj)
    {
      if (Equals(obj, null)) return default(T);
      using (var stream = new MemoryStream())
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, obj);
        stream.Position = 0;

        return (T) formatter.Deserialize(stream);
      }
    }
  }
}