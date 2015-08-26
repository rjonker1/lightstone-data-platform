using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Lace.Domain.DataProviders.Core.Configuration;

namespace Lace.CrossCutting.Infrastructure.Orm.Connections
{
    public static class ConnectionFactoryManager
    {
        private static readonly IDbConnection _autocarStatsConnection;

        static ConnectionFactoryManager()
        {

        }

        public static IDbConnection AutocarStatsConnection
        {
            get
            {
                return _autocarStatsConnection ?? new SqlConnection(AutoCarstatsConfiguration.Database);
            }
        }
    }
}