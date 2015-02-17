using System.Configuration;

namespace Shared.Configuration
{
    public class AppSettings
    {
        private readonly AppSettingsReader reader = new AppSettingsReader();

        public AppSettings()
        {
            Service = new ServiceAppSettings(reader);
            ConnectionStrings = new ConnectionStrings(ConfigurationManager.ConnectionStrings);
            RabbitMQ = new RabbmitMQSettings(reader);
            Api = new ApiSettings(reader);
            UserAuthenticationApi = new UserAuthenticationApiSettings(reader);
            PackageBuilderApi = new PackageBuilderApiSettings(reader);
            UserManagementApi = new UserManagementApiSettings(reader);
        }

        public ServiceAppSettings Service { get; private set; }
        public ConnectionStrings ConnectionStrings { get; private set; }
        public RabbmitMQSettings RabbitMQ { get; private set; }
        public ApiSettings Api { get; private set; }
        public UserAuthenticationApiSettings UserAuthenticationApi { get; private set; }
        public UserManagementApiSettings UserManagementApi { get; private set; }
        public PackageBuilderApiSettings PackageBuilderApi { get; private set; }
    }
}
