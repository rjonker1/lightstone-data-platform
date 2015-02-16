namespace Shared.Configuration
{
    public class ApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal ApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("api/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }
    }
}