﻿using System;
using System.IO.Compression;
namespace TouchMeZaddy;

partial class Comparison
{
    public static int BmMatch(string text, string pattern)
    {
        int[] last = BuildLast(pattern);
        int n = text.Length;
        int m = pattern.Length;
        int i = m - 1;
        if (i > n - 1)
            return -1;
        int j = m - 1;
        do
        {
            if (pattern[j] == text[i])
            {
                if (j == 0)
                    return i;
                else
                {
                    i--;
                    j--;
                }
            }
            else
            {
                int lo = last[text[i]];
                i = i + m - Math.Min(j, 1 + lo);
                j = m - 1;
            }
        } while (i <= n - 1);
        return -1;
    }

    public static int[] BuildLast(string pattern)
    {
        int[] last = new int[256];
        for (int i = 0; i < 256; i++) { 
            last[i] = -1;
        }
        for (int i = 0; i < pattern.Length; i++) {
            last[pattern[i]] = i;
        }
        return last;
    }
}