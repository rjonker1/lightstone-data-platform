using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository.Framework.Connection
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForReadDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["monitoring/read/database"].ToString());

        
    }
}