using System;

partial class Program
{
    public static double LevenshteinDistance(string str1, string str2)
    {
        if (str1 == null || str2 == null)
            throw new ArgumentNullException("Input strings cannot be null.");

        if (str1.Length == 0 || str2.Length == 0)
            return 0.0;

        int[,] distance = new int[str1.Length + 1, str2.Length + 1];

        for (int i = 0; i <= str1.Length; i++)
            distance[i, 0] = i;

        for (int j = 0; j <= str2.Length; j++)
            distance[0, j] = j;

        for (int i = 1; i <= str1.Length; i++)
        {
            for (int j = 1; j <= str2.Length; j++)
            {
                int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                distance[i, j] = Math.Min(Math.Min(
                    distance[i - 1, j] + 1,
                    distance[i, j - 1] + 1),
                    distance[i - 1, j - 1] + cost);
            }
        }

        double maxLen = Math.Max(str1.Length, str2.Length);
        double similarity = 1.0 - ((double)distance[str1.Length, str2.Length] / maxLen);
        return similarity * 100.0;
    }
}
