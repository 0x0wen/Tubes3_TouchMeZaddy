using System;
namespace TouchMeZaddy;

public class CaesarCipher
{
    public static string Encrypt(string text, int key)
    {
        string result = string.Empty;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result += (char)(((c + key - offset) % 26) + offset);
            }
            else
            {
                result += c;
            }
        }

        return result;
    }

    public static string Decrypt(string text, int key)
    {
        return Encrypt(text, 26 - key);
    }
}
