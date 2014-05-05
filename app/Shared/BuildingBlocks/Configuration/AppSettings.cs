using System.Configuration;

namespace BuildingBlocks.Configuration
{
    public class AppSettings
    {
        private readonly AppSettingsReader reader = new AppSettingsReader();

        public AppSettings()
        {
            Service = new ServiceAppSettings(reader);
            ConnectionStrings = new ConnectionStrings(ConfigurationManager.ConnectionStrings);
            RabbitMQ = new RabbmitMQSettings(reader);
            UmApi = new UmApiSettings(reader);
        }

        public ServiceAppSettings Service { get; private set; }
        public ConnectionStrings ConnectionStrings { get; private set; }
        public RabbmitMQSettings RabbitMQ { get; private set; }
        public UmApiSettings UmApi { get; private set; }
    }
}
