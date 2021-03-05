using System.Threading.Tasks;

namespace HAADUtil.Communication.Mqtt
{
    public interface IManagedClient
    {
        Task Connect();

        Task SendMessage();
    }
}
