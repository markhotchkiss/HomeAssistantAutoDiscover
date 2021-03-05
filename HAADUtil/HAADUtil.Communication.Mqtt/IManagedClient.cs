using System.Threading.Tasks;
using MQTTnet.Protocol;

namespace HAADUtil.Communication.Mqtt
{
    public interface IManagedClient
    {
        bool IsConnected { get; }

        Task Connect();

        Task SendMessage(string topic, string payload, MqttQualityOfServiceLevel qos, bool retain);
    }
}
