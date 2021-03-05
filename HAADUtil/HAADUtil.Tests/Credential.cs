using Newtonsoft.Json;

namespace HAADUtil.Tests
{
    public class Credential
    {
        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

}
