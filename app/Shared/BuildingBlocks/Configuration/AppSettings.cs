namespace BuildingBlocks.Configuration
{
    public class AppSettings
    {
        private readonly AppSettingsReader reader = new AppSettingsReader();

        public AppSettings()
        {
            Service = new ServiceAppSettings(reader);
        }

        public ServiceAppSettings Service { get; private set; }
    }
}
