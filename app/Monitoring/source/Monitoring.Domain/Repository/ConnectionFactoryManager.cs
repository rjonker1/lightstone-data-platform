using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Monitoring.Domain.Repository
{
    public sealed class ConnectionFactoryManager
    {
        private static readonly IDbConnection _monitoringConnection;
        private static readonly IDbConnection _billingConnection;
        private ConnectionFactoryManager()
        {

        }

        public static IDbConnection MonitoringConnection
        {
            get
            {
                return _monitoringConnection ?? new SqlConnection(
                    ConfigurationManager.ConnectionStrings["database/monitoring"].ToString());
            }
        }

        public static IDbConnection BillingConnection
        {
            get
            {
                return _billingConnection ?? new SqlConnection(
                    ConfigurationManager.ConnectionStrings["database/billing"].ToString());
            }
        }
    }
}
