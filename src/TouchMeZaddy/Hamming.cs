using System;

partial class Program
{
    public static double Hamming(string text1, string text2)
    {
        if (text1 == null || text2 == null)
            throw new ArgumentNullException("Input strings cannot be null.");

        if (text1.Length == 0 || text2.Length == 0)
            return 0.0;

        // if (text1.Length != text2.Length)
        //     throw new ArgumentException("Input strings must have the same length for Hamming Distance.");

        int hammingDistance = 0;
        for (int i = 0; i < Math.Min(text1.Length, text2.Length); i++)
        {
            if (text1[i] != text2[i])
                hammingDistance++;
        }

        double similarity = 1.0 - ((double)hammingDistance / (double)Math.Min(text1.Length, text2.Length));
        return similarity * 100.0;
    }
}
