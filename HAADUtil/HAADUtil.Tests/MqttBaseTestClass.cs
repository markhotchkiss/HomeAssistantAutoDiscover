using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json;

namespace HAADUtil.Tests
{
    public class MqttBaseTestClass
    {
        public async Task<Credential> RetrieveCredentials()
        {
            var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync("mqtt");

            var deserializedSecret = JsonConvert.DeserializeObject<Credential>(secret.Value.Value);

            return deserializedSecret;
        }
    }
}
