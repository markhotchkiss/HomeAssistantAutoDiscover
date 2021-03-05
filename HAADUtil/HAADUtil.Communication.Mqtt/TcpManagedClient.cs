using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;

namespace HAADUtil.Communication.Mqtt
{
    public class TcpManagedClient : IManagedClient
    {
        private readonly ManagedClientSettings _managedClientSettings;

        public TcpManagedClient(ManagedClientSettings managedClientSettings)
        {
            _managedClientSettings = managedClientSettings;
        }

        public async Task Connect()
        {
            var options = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(new MqttClientOptionsBuilder()
                    .WithClientId(_managedClientSettings.ClientId)
                    .WithTcpServer(_managedClientSettings.ServerAddress)
                    .WithTls().Build())
                .Build();

            var mqttClient = new MqttFactory().CreateManagedMqttClient();

            var topicFilters = new List<MqttTopicFilter>();

            foreach (var topic in _managedClientSettings.SubscribeTopics)
            {
                topicFilters.Add(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            }
            await mqttClient.SubscribeAsync(topicFilters.ToArray());
            await mqttClient.StartAsync(options);
        }

        public Task SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
