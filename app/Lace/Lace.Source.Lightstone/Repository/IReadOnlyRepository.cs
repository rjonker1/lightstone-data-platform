
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T FindWithId(int id);
        T FindWithRequest(IHaveLightstoneRequest request);
        IEnumerable<T> FindAllWithRequest(IHaveLightstoneRequest request);
    }
}
