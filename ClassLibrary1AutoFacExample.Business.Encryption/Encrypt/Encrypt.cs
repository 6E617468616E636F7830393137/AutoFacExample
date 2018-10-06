using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AutoFacExample.Business.Encryption.Encrypt
{
    public class Encrypt : IEncrypt
    {
        public string RijndaelEncryption(string secretKey, string salt, string data)
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
            
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(data);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }
}
