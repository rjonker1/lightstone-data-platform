using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lace.CrossCutting.Infrastructure.Orm.Connections
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForAutoCarStatsDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lace/source/database/auto-car-stats"].ToString());

    }
}
