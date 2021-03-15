using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace TSMobileApp.Scripts.Security
{
    class Encryption
    {
        private readonly static string aes_key = @"E)H@McQfTjWnZr4u7x!A%C*F-JaNdRgUkXp2s5v8y/B?E(G+KbPeShVmYq3t6w9z";

        public static string AES_Encrypt(string str)
        {
            byte[] init_vector = new byte[16];
            byte[] arr;

            using(Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(aes_key);
                aes.IV = init_vector;

                ICryptoTransform ic_encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream mem_stream = new MemoryStream())
                {
                    using (CryptoStream crypto_stream = new CryptoStream((Stream)mem_stream, ic_encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter stream_writer = new StreamWriter((Stream)crypto_stream))
                        {
                            stream_writer.WriteLine(str);
                        }

                        arr = mem_stream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(arr);
        }

        public static string AES_Decrypt(string str)
        {
            byte[] init_vector = new byte[16];
            byte[] arr;
        }
    }
}
