using System.Globalization;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGeneration;

public class PasswordGenerateAPI
{

    public static string GeneratePassword(int length = 8, bool lettersLow = true, bool lettersHigh = true, bool numbers = true, bool specCharacters = true)
    {
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string numChars = "0123456789";
        const string specialChars = "!@#$%^&*()-_=+<>?";

        StringBuilder charPool = new StringBuilder();

        if (lettersLow) charPool.Append(lowerChars);
        if (lettersHigh) charPool.Append(upperChars);
        if (numbers) charPool.Append(numChars);
        if (specCharacters) charPool.Append(specialChars);


        if (charPool.Length == 0) return string.Empty;

        char[] resultSet = new char[length];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            for (int i = 0; i < length; i++)
            {
                byte[] randomInt = new byte[4];
                rng.GetBytes(randomInt);
                int index = BitConverter.ToInt32(randomInt, 0) % charPool.Length;
                if (index < 0) index = -index;
                resultSet[i] = charPool[index];
            }
        }

        return new string(resultSet);
    }
}