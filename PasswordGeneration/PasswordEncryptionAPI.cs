namespace PasswordGeneration;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class PasswordEncryptionAPI
{
    private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("ap5LpoTFiDn3iFR2iLsaK4b01ow5SmWE");
    private static readonly byte[] AesIV = new byte[16];

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = AesKey;
            aes.IV = AesIV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(plainText);
                }

                byte[] encryptedBytes = memoryStream.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    public static string Decrypt(string encryptedText)
    {
        try
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = AesKey;
                aes.IV = AesIV;

                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        catch(Exception ex) {
            return "Password is encrypted with different key.";
        }
        
    }
}