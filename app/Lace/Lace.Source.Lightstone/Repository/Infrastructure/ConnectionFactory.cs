using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lace.Source.Lightstone.Repository.Infrastructure
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForAutoCarStatsDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lace/source/database/auto-car-stats"].ToString());

    }
}
