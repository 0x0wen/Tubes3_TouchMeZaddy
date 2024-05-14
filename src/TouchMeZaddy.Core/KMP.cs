using System;

partial class Program
{
    public static double KMP(string text1, string text2)
    {
        if (text1 == null || text2 == null)
            throw new ArgumentNullException("Input strings cannot be null.");

        if (text1.Length == 0 || text2.Length == 0)
            return 0.0;

        int[] lps = ComputeLPSArray(text2);

        int matchedChars = 0;
        int i = 0, j = 0;
        while (i < text1.Length)
        {
            if (text1[i] == text2[j])
            {
                i++;
                j++;
                matchedChars++;
            }

            if (j == text2.Length)
            {
                j = lps[j - 1];
            }
            else if (i < text1.Length && text1[i] != text2[j])
            {
                if (j != 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }

        double similarity = (double)matchedChars / (double)Math.Max(text1.Length, text2.Length);
        return similarity * 100.0;
    }

    private static int[] ComputeLPSArray(string pattern)
    {
        int[] lps = new int[pattern.Length];
        int len = 0;
        int i = 1;
        lps[0] = 0;

        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }

        return lps;
    }
}