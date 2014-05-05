namespace BuildingBlocks.Configuration
{
    public class UmApiSettings
    {
        private readonly AppSettingsReader _reader;

        private UmApiSettings()
        {
        }

        internal UmApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("umApi/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/authenticationResource
        /// </summary>
        public string AuthenticationResource
        {
            get { return _reader.GetString("umApi/config/authenticationResource", () => "UNKNOWN_AUTHENTICATION_RESOURCE"); }
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/redisServers
        /// </summary>
        public string RedisServers
        {
            get { return _reader.GetString("umApi/config/redisServers", () => "UNKNOWN_REDIS_SERVERS"); }
        }
    }
}