using System;
using Lace.Request;
using Lace.Response;

namespace Lace.Source
{
    public interface IHandleServiceCall
    {
        string ServiceName { get; }
        bool CanHandle(ILaceRequest request);
        ILaceResponse Call(Action<IRequestDataFromService> action);
    }
}
