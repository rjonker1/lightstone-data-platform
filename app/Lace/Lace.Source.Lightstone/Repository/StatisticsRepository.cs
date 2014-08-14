using System;
using System.Data;
using Lace.Source.Lightstone.Models;
using Workflow.Billing.Repository;

namespace Lace.Source.Lightstone.Repository
{
    public class StatisticsRepository : IReadOnlyRepository<Statistics>
    {
        private readonly IDbConnection _connection;

        public StatisticsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Statistics FindWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Statistics FindWithRequest(ILightstoneRequest request)
        {
           
            throw new NotImplementedException();
        }
    }
}
