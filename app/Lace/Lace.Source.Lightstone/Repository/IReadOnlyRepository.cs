using System.Collections.Generic;
using Lace.Request;

namespace Lace.Source.Lightstone.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T FindWithId(int id);
        T FindWithRequest(ILaceRequestCarInformation request);
        IEnumerable<T> FindAllWithRequest(ILaceRequestCarInformation request);
    }
}
