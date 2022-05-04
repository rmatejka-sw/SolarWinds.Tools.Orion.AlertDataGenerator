using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex SIntegerPattern = new Regex("[0-9]+", RegexOptions.Compiled);

        public static int ToInt(this string text, int defaultValue = default)
        {
            var match = SIntegerPattern.Match(text);
            if (match.Success && Int32.TryParse(match.Value, out int value))
            {
                return value;
            }

            return defaultValue;
        }

        public static string Encrypt(this string plaintext, string key)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = new byte[16];
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                        {
                            using (var streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(plaintext);
                            }
                            return Convert.ToBase64String(memoryStream.ToArray());

                        }

                    }
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not encrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static string ExpandAsteriskToPropList<T>(this string query)
        {
            return query.Replace("*", typeof(T).GetPropertyList());
        }

        public static string Decrypt(this string encryptedText, string key)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = new byte[16];
                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();

                            }

                        }

                    }

                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not decrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
