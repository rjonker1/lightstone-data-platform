using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Monitoring.Projection.UI.Repository.Framework.Connections
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForReadDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["monitoring/read/database"].ToString());
    }
}