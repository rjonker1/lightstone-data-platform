namespace Shared.Configuration
{
    public class PbApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal PbApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("pbApi/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }
    }
}