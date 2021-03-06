﻿namespace Shared.Configuration
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

    public class PackageBuilderApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal PackageBuilderApiSettings(AppSettingsReader reader)
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

    public class UserManagementApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal UserManagementApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called umApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("userManagementApi/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }
        /// <summary>
        /// Finds an appSetting called umApi/config/redisServers
        /// </summary>
        public string RedisServers
        {
            get { return _reader.GetString("umApi/config/redisServers", () => "UNKNOWN_REDIS_SERVERS"); }
        }
    }

    public class ReportApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal ReportApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called reportApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("reportApi/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }
    }

    public class BillingApiSettings
    {
        private readonly AppSettingsReader _reader;

        internal BillingApiSettings(AppSettingsReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Finds an appSetting called billingApi/config/baseUrl
        /// </summary>
        public string BaseUrl
        {
            get { return _reader.GetString("billingApi/config/baseUrl", () => "UNKNOWN_BASE_URL"); }
        }
    }
}