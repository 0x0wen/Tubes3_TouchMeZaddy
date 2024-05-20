using System;

partial class Program
{
    public static int LevenshteinRecursive(string str1, string str2, int m, int n)
    {
        // If str1 is empty, the distance is the length of str2
        if (m == 0)
        {
            return n;
        }
         
        // If str2 is empty, the distance is the length of str1
        if (n == 0)
        {
            return m;
        }
 
        // If the last characters of the strings are the same
        if (str1[m - 1] == str2[n - 1])
        {
            return LevenshteinRecursive(str1, str2, m - 1, n - 1);
        }
 
        // Calculate the minimum of three operations:
        // Insert, Remove, and Replace
        return 1 + Math.Min(
            Math.Min(
                // Insert
                LevenshteinRecursive(str1, str2, m, n - 1),
                // Remove
                LevenshteinRecursive(str1, str2, m - 1, n)
            ),
            // Replace
            LevenshteinRecursive(str1, str2, m - 1, n - 1)
        );
    }

    public static int LevenshteinFullMatrix(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
 
        // Create a matrix to store distances
        int[,] dp = new int[m + 1, n + 1];
 
        // Initialize the first row and column of the matrix
        for (int i = 0; i <= m; i++)
        {
            dp[i, 0] = i; // Number of insertions required for str1 to become an empty string
        }
        for (int j = 0; j <= n; j++)
        {
            dp[0, j] = j; // Number of insertions required for an empty string to become str2
        }
 
        // Fill in the matrix with minimum edit distances
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1]; // Characters match, no operation needed
                }
                else
                {
                    // Choose the minimum of insert, delete, or replace operations
                    dp[i, j] = 1 + Math.Min(
                        dp[i, j - 1], // Insertion
                        Math.Min(
                            dp[i - 1, j], // Deletion
                            dp[i - 1, j - 1] // Replacement
                        )
                    );
                }
            }
        }
        return dp[m, n]; // Return the final edit distance
    }

    static int LevenshteinTwoMatrixRows(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
 
        // Initialize two rows for dynamic programming
        int[] prevRow = new int[n + 1];
        int[] currRow = new int[n + 1];
 
        // Initialization of the first row
        for (int j = 0; j <= n; j++) {
            prevRow[j] = j;
        }
 
        // Dynamic programming to calculate Levenshtein
        // distance
        for (int i = 1; i <= m; i++) {
            // Initialize the current row with the value of
            // i
            currRow[0] = i;
 
            for (int j = 1; j <= n; j++) {
                // If characters are the same, no operation
                // is needed
                if (str1[i - 1] == str2[j - 1]) {
                    currRow[j] = prevRow[j - 1];
                }
                else {
                    // Choose the minimum of three
                    // operations: insert, remove, or
                    // replace
                    currRow[j] = 1
                                 + Math.Min(
                                     // Insert
                                     currRow[j - 1],
                                     Math.Min(
                                         // Remove
                                         prevRow[j],
 
                                         // Replace
                                         prevRow[j - 1]));
                }
            }
 
            // Update the previous row for the next
            // iteration
            Array.Copy(currRow, prevRow, n + 1);
        }
 
        // The bottom-right cell contains the Levenshtein
        // distance
        return currRow[n];
    }
}
