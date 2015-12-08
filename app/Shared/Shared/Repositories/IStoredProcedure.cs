using System.Collections.Generic;

namespace DataPlatform.Shared.Repositories
{
    public interface IStoredProcedure<out T>
    {
        T Query(string query);
        T WithParameters(Dictionary<string, string> queryParams);
        void Execute();
    }
}