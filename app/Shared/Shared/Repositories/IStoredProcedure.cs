using System.Collections.Generic;

namespace DataPlatform.Shared.Repositories
{
    public interface IStoredProcedure<T>
    {
        T Query(string query);
        T WithParameters(Dictionary<string, string> queryParams);
        IEnumerable<T> RetrieveData();
    }
}