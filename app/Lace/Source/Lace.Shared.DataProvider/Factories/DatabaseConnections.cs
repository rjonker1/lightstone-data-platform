using System.Data;
using System.Data.SqlClient;
using Lace.Domain.DataProviders.Core.Configuration;

namespace Lace.Toolbox.Database.Factories.CarInformation
{
    public static class DatabaseConnectionFactory
    {
        private static readonly IDbConnection _autocarStatsConnection;
        private static readonly IDbConnection _financedInterestsConnection;

        static DatabaseConnectionFactory()
        {

        }

        public static IDbConnection AutocarStatsConnection
        {
            get { return _autocarStatsConnection ?? new SqlConnection(AutoCarstatsConfiguration.Database); }
        }

        public static IDbConnection FinacedInterestsConnection
        {
            get { return _financedInterestsConnection ?? new SqlConnection(IntegrationBmwConfiguration.Database); }
        }
    }
}
