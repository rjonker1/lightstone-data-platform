
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T FindWithId(int id);
        T FindWithRequest(ILightstoneRequest request);
    }
}
