using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;

namespace HAADUtil.Communication.Mqtt
{
    public class TcpManagedClient : IManagedClient
    {
        public bool IsConnected => _mqttClient.IsConnected;

        private IManagedMqttClient _mqttClient;
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
                    .WithTcpServer(_managedClientSettings.ServerAddress, 1883)
                    .WithCredentials(_managedClientSettings.Username, _managedClientSettings.Password)
                    .Build()).Build();

            _mqttClient = new MqttFactory().CreateManagedMqttClient();

            var topicFilters = new List<MqttTopicFilter>();

            foreach (var topic in _managedClientSettings.SubscribeTopics)
            {
                topicFilters.Add(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            }
            await _mqttClient.SubscribeAsync(topicFilters.ToArray());
            await _mqttClient.StartAsync(options);
        }

        public async Task SendMessage(string topic, string payload, MqttQualityOfServiceLevel qos, bool retain)
        {
            var message = new MqttApplicationMessage()
            {
                Topic = topic,
                Payload = Encoding.UTF8.GetBytes(payload),
                QualityOfServiceLevel = qos,
                Retain = retain
            };

            await _mqttClient.PublishAsync(message);
        }
    }
}
