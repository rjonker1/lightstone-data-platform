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
        /// Finds an appSetting called service/name
        /// </summary>
        public string Name
        {
            get { return reader.GetString("service/name", () => "UNKNOWN_SERVICE_NAME"); }
        }

        /// <summary>
        /// Finds an appSetting called service/description
        /// </summary>
        public string Description
        {
            get { return reader.GetString("service/description", () => "UNKNOWN SERVICE DESCRIPTION"); }
        }

        /// <summary>
        /// Finds an appSetting called service/name
        /// </summary>
        public string DisplayName
        {
            get { return reader.GetString("service/displayName", () => "UNKNOWN SERVICE DISPLAY NAME"); }
        }
    }
}