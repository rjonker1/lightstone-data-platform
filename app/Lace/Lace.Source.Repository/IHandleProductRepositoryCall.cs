using System;

namespace Lace.Source.Repository
{
    public interface IHandleProductRepositoryCall
    {
        void Get(Action<IRequestProductDataFromRepository> action);
    }
}
