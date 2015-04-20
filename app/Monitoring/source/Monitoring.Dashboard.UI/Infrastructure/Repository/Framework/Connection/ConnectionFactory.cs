using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository.Framework.Connection
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForMonitoringDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["database/monitoring"].ToString());

        public static Func<IDbConnection> ForCommandsDatabase =
           () =>
               new SqlConnection(
                   ConfigurationManager.ConnectionStrings["database/commands"].ToString());

        
    }
}