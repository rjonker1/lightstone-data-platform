using System;
using Lace.Request;
using Lace.Source.Enums;

namespace Lace.Source
{
    public interface IHandleServiceCall
    {
        Services Service { get; }
        bool CanHandle(ILaceRequest request);
        //ILaceResponse Call(Action<IRequestDataFromService> action);
        void Call(Action<IRequestDataFromService> action);
    }
}
