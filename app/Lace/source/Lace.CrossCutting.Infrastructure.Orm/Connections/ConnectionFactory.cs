using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lace.CrossCutting.Infrastructure.Orm.Connections
{
    public sealed class ConnectionFactoryManager
    {
        private static readonly IDbConnection _autocarStatsConnection;

        private ConnectionFactoryManager()
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