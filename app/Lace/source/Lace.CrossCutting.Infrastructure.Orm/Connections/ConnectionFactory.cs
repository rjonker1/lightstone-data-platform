using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                return _autocarStatsConnection ?? new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lace/source/database/auto-car-stats"].ToString());
            }
        }
    }
}