namespace AutoFacExample.Business.Encryption.Encrypt
{
    public interface IEncrypt
    {
        string RijndaelEncryption(string secretKey, string salt, string data);
    }
}
