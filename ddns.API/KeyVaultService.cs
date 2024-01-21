using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Prueba
{
    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(string keyVaultName)
        {
            var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
            _secretClient = new SecretClient(keyVaultUri, new DefaultAzureCredential());
        }

        public string GetSecret(string secretName)
        {
            var secretValue = _secretClient.GetSecret(secretName).Value.Value;
            return secretValue;
        }
    }
}
