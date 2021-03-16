using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace TSMobileApp.Scripts.Security
{
    class Encryption
    {
        private readonly static string aes_key = @"KaPdSgVkYp3s6v9y$B&E)H+MbQeThWmZ";

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
            string result = Convert.ToBase64String(arr).Replace("+","%2b");
            return result;
        }

        public static string AES_Decrypt(string str)
        {
            byte[] init_vector = new byte[16];
            byte[] buffer = Convert.FromBase64String(str);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(aes_key);
                aes.IV = init_vector;

                ICryptoTransform ic_decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream mem_stream = new MemoryStream(buffer))
                {
                    using (CryptoStream crypto_stream = new CryptoStream((Stream)mem_stream, ic_decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader stream_reader = new StreamReader((Stream)crypto_stream))
                        {
                            return stream_reader.ReadToEnd() ;
                        }
                    }
                }
            }
        }
    }
}
