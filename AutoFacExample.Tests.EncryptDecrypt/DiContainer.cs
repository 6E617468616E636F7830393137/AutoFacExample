using Autofac;

namespace AutoFacExample.Tests.EncryptDecrypt
{    
    public static class DiContainer
    {
        public static ContainerBuilder builder;
        public static void Initialize()
        {
            builder = new ContainerBuilder();
            builder.RegisterType<Business.Encryption.Encrypt.Encrypt>().As<Business.Encryption.Encrypt.IEncrypt>();
            builder.RegisterType<Business.Encryption.Decrypt.Decrypt>().As<Business.Encryption.Decrypt.IDecrypt>();
            builder.RegisterType<Business.Encryption.Encoding.Conversions>().As<Business.Encryption.Encoding.IConversions>();
        }
        
    }
}
