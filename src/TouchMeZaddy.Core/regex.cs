using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

partial class Program
{
    static string BuildPattern(string target)
    {
        Dictionary<char, List<char>> rgx = new Dictionary<char, List<char>>
        {
            { 'a', new List<char> { '4', 'A', 'a' } },
            { 'b', new List<char> { 'B', 'b', '8' } },
            { 'c', new List<char> { 'C', 'c' } },
            { 'd', new List<char> { 'D', 'd' } },
            { 'e', new List<char> { '3', 'E', 'e' } },
            { 'f', new List<char> { 'F', 'f' } },
            { 'g', new List<char> { 'G', 'g', '6' } },
            { 'h', new List<char> { 'H', 'h' } },
            { 'i', new List<char> { '1', 'I', 'i' } },
            { 'j', new List<char> { 'J', 'j' } },
            { 'k', new List<char> { 'K', 'k' } },
            { 'l', new List<char> { 'L', 'l' } },
            { 'm', new List<char> { 'M', 'm' } },
            { 'n', new List<char> { 'N', 'n' } },
            { 'o', new List<char> { '0', 'O', 'o' } },
            { 'p', new List<char> { 'P', 'p' } },
            { 'q', new List<char> { 'Q', 'q' } },
            { 'r', new List<char> { 'R', 'r' } },
            { 's', new List<char> { 'S', 's', '5' } },
            { 't', new List<char> { 'T', 't', '7' } },
            { 'u', new List<char> { 'U', 'u' } },
            { 'v', new List<char> { 'V', 'v' } },
            { 'w', new List<char> { 'W', 'w' } },
            { 'x', new List<char> { 'X', 'x' } },
            { 'y', new List<char> { 'Y', 'y' } },
            { 'z', new List<char> { 'Z', 'z', '2' } }
        };

        string pattern = "^";
        foreach (char c in target)
        {
            if (rgx.ContainsKey(char.ToLower(c)))
            {
                pattern += "[";
                foreach (char rc in rgx[char.ToLower(c)])
                {
                    pattern += Regex.Escape(rc.ToString());
                }
                pattern += "]";
            }
            else
            {
                pattern += Regex.Escape(c.ToString());
            }
        }
        pattern += "$";
        return pattern;
    }

    static int LevenshteinRegex(string source, string target)
    {
        Dictionary<char, List<char>> rgx = new Dictionary<char, List<char>>
        {
            { 'a', new List<char> { '4', 'A', 'a' } },
            { 'b', new List<char> { 'B', 'b', '8' } },
            { 'c', new List<char> { 'C', 'c' } },
            { 'd', new List<char> { 'D', 'd' } },
            { 'e', new List<char> { '3', 'E', 'e' } },
            { 'f', new List<char> { 'F', 'f' } },
            { 'g', new List<char> { 'G', 'g', '6' } },
            { 'h', new List<char> { 'H', 'h' } },
            { 'i', new List<char> { '1', 'I', 'i' } },
            { 'j', new List<char> { 'J', 'j' } },
            { 'k', new List<char> { 'K', 'k' } },
            { 'l', new List<char> { 'L', 'l' } },
            { 'm', new List<char> { 'M', 'm' } },
            { 'n', new List<char> { 'N', 'n' } },
            { 'o', new List<char> { '0', 'O', 'o' } },
            { 'p', new List<char> { 'P', 'p' } },
            { 'q', new List<char> { 'Q', 'q' } },
            { 'r', new List<char> { 'R', 'r' } },
            { 's', new List<char> { 'S', 's', '5' } },
            { 't', new List<char> { 'T', 't', '7' } },
            { 'u', new List<char> { 'U', 'u' } },
            { 'v', new List<char> { 'V', 'v' } },
            { 'w', new List<char> { 'W', 'w' } },
            { 'x', new List<char> { 'X', 'x' } },
            { 'y', new List<char> { 'Y', 'y' } },
            { 'z', new List<char> { 'Z', 'z', '2' } }
        };

        int m = source.Length;
        int n = target.Length;
        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
        {
            dp[i, 0] = i;
        }

        for (int j = 0; j <= n; j++)
        {
            dp[0, j] = j;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int cost = 1;
                if (rgx.ContainsKey(char.ToLower(source[i - 1])) && rgx[char.ToLower(source[i - 1])].Contains(target[j - 1]))
                {
                    cost = 0;
                }

                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost);
            }
        }

        return dp[m, n];
    }

}
