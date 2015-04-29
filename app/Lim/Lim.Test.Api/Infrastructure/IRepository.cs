using System.Collections.Generic;

namespace Lim.Test.Api.Infrastructure
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        IList<T> GetWith(object param);

        T Get();
        T Get(object param);
    }
}
