using System;
using System.Text;

namespace Longest_Happy_String
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var result = s.LongestDiverseString(2, 2, 7);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    public string LongestDiverseString(int a, int b, int c)
    {
      var str = new StringBuilder();
      LongestStringBuilder(new[] { a, b, c }, -1, str);

      return str.ToString();
    }

    private void LongestStringBuilder(int[] abc, int banned, StringBuilder str)
    {
      var (max, trueMax, index) = (0, 0, -1);
      for (int i = 0; i < 3; ++i)
      {
        var count = abc[i];
        if (count > trueMax)
          trueMax = count;
        if (i != banned && count > max)
        {
          max = count;
          index = i;
        }
      }
      if (max == 0) return ;
      if (max != trueMax) max = 1;
      else if (max > 2) max = 2;

      abc[index] -= max;
      string s = new String((char)('a' + index), max);
      str.Append(s);
      LongestStringBuilder(abc, index, str);
    }
  }
}
