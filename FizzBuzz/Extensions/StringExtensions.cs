using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FizzBuzz.Extensions
{
  public static class StringExtensions
  {
    public static string Replace(this string originalString,
                                 string oldValue,
                                 string newValue,
                                 StringComparison comparisonType)
    {
      int startIndex = 0;
      while (true)
      {
        startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);
        if (startIndex == -1)
          break;

        originalString = originalString.Substring(0, startIndex) + newValue +
                         originalString.Substring(startIndex + oldValue.Length);

        startIndex += newValue.Length;
      }

      return originalString;
    }

    public static string ToSplAssetName(this string originalString)
    {
      if (originalString == null) return null;
      return originalString.Replace(" ", "");
    }


    public static string GetBaseHomeFolder(this string packagesPath)
    {
      var pathRoot = Path.GetPathRoot(packagesPath);
      var folders = packagesPath.Split(Path.DirectorySeparatorChar).ToList();
      if (folders.Any()
          && !string.IsNullOrEmpty(pathRoot)
          && folders.First() == pathRoot.Replace(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture), ""))
      {
        folders.RemoveAt(0);
      }

      var basefolders = packagesPath;
      if (folders.Any())
      {
        string lastfolder = folders.Last();
        folders.Remove(lastfolder);
        basefolders = Path.Combine(folders.ToArray());
        if (!string.IsNullOrEmpty(pathRoot))
        {
          basefolders = Path.Combine(pathRoot, basefolders);
        }
      }
      string baseHomeFolder = Path.Combine(basefolders, "DaVinci");
      return baseHomeFolder;
    }
  }
}