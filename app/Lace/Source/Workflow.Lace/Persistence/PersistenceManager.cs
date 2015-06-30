using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Workflow.Lace.Persistence
{
    public sealed class PersistenceManager
    {
        private static readonly IDbConnection _connection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["workflow/dataprovider/database"]
                .ConnectionString);

        static PersistenceManager()
        {
            
        }

        public static IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }
}
