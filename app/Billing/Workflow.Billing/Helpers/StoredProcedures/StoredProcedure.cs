using System.Collections.Generic;
using DataPlatform.Shared.Repositories;

namespace Workflow.Billing.Helpers.StoredProcedures
{
    public class StoredProcedure : IStoredProcedure<StoredProcedure>
    {
        public StoredProcedure StoredProcedure(string query)
        {
            throw new System.NotImplementedException();
        }

        public StoredProcedure WithParameters(Dictionary<string, string> queryParams)
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}