using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lace.Shared.CertificateProvider.Infrastructure.Providers
{
    public class ConnectionFactory
    {
        public static Func<IDbConnection> ForLsCorporateAutoDatabase =
            () =>
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lace/source/database/ls-corporate-auto"].ToString());
    }
}
