using System.Collections.Generic;

namespace HAADUtil.Communication.Mqtt
{
    public class ManagedClientSettings
    {
        public string ClientId { get; set; }

        public string ServerAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<string> SubscribeTopics { get; set; }
    }
}
