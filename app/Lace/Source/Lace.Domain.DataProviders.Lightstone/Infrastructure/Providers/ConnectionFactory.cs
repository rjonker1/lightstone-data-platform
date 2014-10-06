using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Providers
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForAutoCarStatsDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lace/source/database/auto-car-stats"].ToString());

    }
}
