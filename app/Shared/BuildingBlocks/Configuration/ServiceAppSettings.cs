namespace BuildingBlocks.Configuration
{
    public class ServiceAppSettings
    {
        private readonly AppSettingsReader reader;

        private ServiceAppSettings()
        {
        }

        internal ServiceAppSettings(AppSettingsReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called service/config/name
        /// </summary>
        public string Name
        {
            get { return reader.GetString("service/config/name", () => "UNKNOWN_SERVICE_NAME"); }
        }

        /// <summary>
        /// Finds an appSetting called service/config/description
        /// </summary>
        public string Description
        {
            get { return reader.GetString("service/config/description", () => "UNKNOWN SERVICE DESCRIPTION"); }
        }

        /// <summary>
        /// Finds an appSetting called service/config/name
        /// </summary>
        public string DisplayName
        {
            get { return reader.GetString("service/config/displayName", () => "UNKNOWN SERVICE DISPLAY NAME"); }
        }
    }
}