using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lim.Web.UI.Repository
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForLimDatabase = () => new SqlConnection(ConfigurationManager.ConnectionStrings["database/lim"].ToString());
        public static Func<IDbConnection> ForUsermanagementDatabase = () => new SqlConnection(ConfigurationManager.ConnectionStrings["database/usermanagement"].ToString());
    }
}