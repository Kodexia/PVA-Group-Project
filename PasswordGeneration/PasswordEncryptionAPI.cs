namespace PasswordGeneration;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class PasswordEncryption
{
    // This is a constant key for demonstration. 
    // In a real-world scenario, you should securely generate and store the key and IV.
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("aVerySecretKey12345678"); // 16 bytes for AES128, 24 bytes for AES192, 32 bytes for AES256
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("aVerySecretIV12"); // AES always uses 128-bit IV regardless of key size

    public static string EncryptPassword(string password)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using MemoryStream memoryStream = new MemoryStream();
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
        {
            streamWriter.Write(password);
        }

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    public static string DecryptPassword(string encryptedPassword)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedPassword));
        using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new StreamReader(cryptoStream);
        
        return streamReader.ReadToEnd();
    }
}