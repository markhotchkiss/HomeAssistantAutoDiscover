using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HAADUtil.Communication.Mqtt;
using MQTTnet.Protocol;
using NUnit.Framework;

namespace HAADUtil.Tests
{
    [TestFixture]
    public class TcpMqttClientTestFixture : MqttBaseTestClass
    {
        private IManagedClient _managedClient;

        [OneTimeSetUp]
        public async Task SetupTests()
        {
            var deserializedSecret = await RetrieveCredentials();

            _managedClient = new ManagedClientFactory(new ManagedClientSettings()
            {
                ServerAddress = deserializedSecret.Server,
                ClientId = Guid.NewGuid().ToString(),
                Username = deserializedSecret.Username,
                Password = deserializedSecret.Password,
                SubscribeTopics = new List<string>()
            }).GetClient(ConnectionType.Mqtt);
        }

        [Test]
        public async Task Connect()
        {
            await _managedClient.Connect();

            //Wait for connection to server to complete.
            Thread.Sleep(5000);

            Assert.IsTrue(_managedClient.IsConnected);
        }

        [Test]
        public async Task SendMessage()
        {
            await _managedClient.Connect();

            //Wait for connection to server to complete.
            Thread.Sleep(5000);

            const string topic = "markjhotchkiss/tests/test_message";
            const string payload = "Test Payload";

            await _managedClient.SendMessage(topic, payload, MqttQualityOfServiceLevel.AtLeastOnce, false);
        }
    }
}
