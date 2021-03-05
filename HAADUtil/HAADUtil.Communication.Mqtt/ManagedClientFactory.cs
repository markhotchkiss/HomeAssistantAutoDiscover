using System;

namespace HAADUtil.Communication.Mqtt
{
    public class ManagedClientFactory
    {
        private ManagedClientSettings _managedClientSettings;

        public ManagedClientFactory(ManagedClientSettings managedClientSettings)
        {
            _managedClientSettings = managedClientSettings;
        }

        public IManagedClient GetClient(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Mqtt:
                    return new TcpManagedClient(_managedClientSettings);
                case ConnectionType.Mqtts:
                    return null;
                case ConnectionType.Ws:
                    return null;
                case ConnectionType.Wss:
                    return null;
                default:
                    throw new NotImplementedException("Interface not implemented");
            }
        }
    }
}
