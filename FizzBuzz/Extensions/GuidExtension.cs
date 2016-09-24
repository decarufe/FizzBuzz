using System;
using System.Collections.Generic;

namespace FizzBuzz.Extensions
{
  public static class GuidExtension
  {
    private static readonly IDictionary<Guid, string> GuidMap = new Dictionary<Guid, string>();

    public static string ToShortString(this Guid guid)
    {
      string id = guid.ToString();
      if (!GuidMap.ContainsKey(guid))
      {
        string value = String.Format("{{{0}}}", id.Substring(0, 4));
        if (GuidMap.Values.Contains(value)) throw new InvalidOperationException("Guid collision");
        GuidMap[guid] = value;
      }
      return GuidMap[guid];
    }
  }
}