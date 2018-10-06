using System;
using System.Configuration;
using Autofac;
using Logger = Log4net.Helper.Logging.Logger;

namespace AutoFacExample.Tests.EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Info(": : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : :");
            Logger.Info(": : : : : : : : : : Encrypt / Decrypt Test: : : : : : : : : : : : : :");
            Logger.Info(": : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : :");
            Console.WriteLine(": : : : : Encrypt / Decrypt Test : : : : :");
            // Initializes the Autofac DiContainer
            DiContainer.Initialize();
            // Used to build the container for consumption
            var container = DiContainer.builder.Build();
            Console.Write("Input String to Encrypt:  ");
            var Data = Console.ReadLine();
            Logger.Info($"Input String to Encrypt:  {Data}");
            // Accessing container to build object from encryption service
            var EncryptedData = container.Resolve<Business.Encryption.Encrypt.IEncrypt>().RijndaelEncryption(
                ConfigurationManager.AppSettings["SecretKey"],
                ConfigurationManager.AppSettings["Salt"],
                Data);
            Console.WriteLine($"Encrypted String : {EncryptedData}");
            Logger.Info($"Encrypted String : {EncryptedData}");
            // Encode encryted string
            var EncodedString = container.Resolve<Business.Encryption.Encoding.IConversions>().StringToHexConversion8(EncryptedData);
            Console.WriteLine($"Encoded String : {EncodedString}");
            Logger.Info($"Encoded String : {EncodedString}");
            // Decode encypted string
            var DecodedString = container.Resolve<Business.Encryption.Encoding.IConversions>().HexToStringConversion8(EncodedString);
            Console.WriteLine($"Decoded String : {DecodedString}");
            Logger.Info($"Decoded String : {DecodedString}");
            // Accessing container to build object from encryption service
            var DecryptedData = container.Resolve<Business.Encryption.Decrypt.IDecrypt>().RijndaelDecryption(
                ConfigurationManager.AppSettings["SecretKey"],
                ConfigurationManager.AppSettings["Salt"],
                DecodedString);
            Console.WriteLine($"Decrypted String : {DecryptedData}");
            Logger.Info($"Decrypted String : {DecryptedData}");
            Logger.Info(": : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : :");
            Console.WriteLine("Press any key when done...");
            Console.ReadLine();
        }
    }
}

