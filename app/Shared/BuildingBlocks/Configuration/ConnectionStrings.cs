using System;
using System.Configuration;

namespace BuildingBlocks.Configuration
{
    public class ConnectionStrings
    {
        private readonly ConnectionStringSettingsCollection connectionStrings;

        private ConnectionStrings()
        {
        }

        internal ConnectionStrings(ConnectionStringSettingsCollection connectionStrings)
        {
            this.connectionStrings = connectionStrings;
        }

        public string Get(string key, Func<string> ifMissing)
        {
            var connectionStringSettings = connectionStrings[key];

            if (connectionStringSettings == null)
                return ifMissing();

            return connectionStringSettings.ConnectionString;

        }
    }
}