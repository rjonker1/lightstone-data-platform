using System;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source
{
    public interface IHandleServiceCall
    {
        Services Service { get; }
        bool CanHandle(ILaceRequest request, ILaceResponse response);
        void Call(Action<IRequestDataFromService> action);
    }
}
