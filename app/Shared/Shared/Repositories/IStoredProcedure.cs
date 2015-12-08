using System.Collections.Generic;

namespace DataPlatform.Shared.Repositories
{
    public interface IStoredProcedure<T>
    {
        T StoredProcedure(string query);
        T WithParameters(Dictionary<string, string> queryParams);
        T Execute();
    }
}