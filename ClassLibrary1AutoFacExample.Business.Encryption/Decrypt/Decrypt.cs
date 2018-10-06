using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AutoFacExample.Business.Encryption.Decrypt
{
    public class Decrypt : IDecrypt
    {
        public string RijndaelDecryption(string secretKey, string salt, string data)
        {
            if (salt == null || secretKey == null)
            {
                throw new ArgumentNullException("Incorrect input parameters.");
            }

            var saltBytes = System.Text.Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(secretKey, saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException("Incorrect input parameters.");

            string text = string.Empty;
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            var cipher = Convert.FromBase64String(data);

            using (var msDecrypt = new MemoryStream(cipher))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }
            return text;
        }
    }
}
