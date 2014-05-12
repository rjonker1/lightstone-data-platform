using System;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.Repository
{
    public interface IHandleProductRepositoryCall
    {
        bool CanHandle(ILaceRequest request, ILaceResponse response);
        void Get(Action<IRequestProductDataFromRepository> action);
    }
}
