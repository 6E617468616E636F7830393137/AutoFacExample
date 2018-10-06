namespace AutoFacExample.Business.Encryption.Decrypt
{
    public interface IDecrypt
    {
        string RijndaelDecryption(string secretKey, string salt, string data);
    }
}
