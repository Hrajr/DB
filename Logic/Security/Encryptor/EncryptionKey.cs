using Microsoft.Extensions.Configuration;
using System.IO;

namespace Logic.Security.Encryptor
{
    public class EncryptionKey
    {
        internal string key;
        internal static bool useHashing = true;
        public EncryptionKey()
        {
            var configuration = GetConfiguration();
            key = configuration.GetSection("AppSecurity").GetSection("SecurityKey").Value;
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
