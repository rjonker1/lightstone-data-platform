using System;
namespace Lace.Source
{
    public interface IHandleServiceCall
    {
        //Services Service { get; }
        //bool CanHandle(ILaceRequest request, ILaceResponse response);
        //bool CanHandle(IDataSet request, ILaceResponse response);
        void Request(Action<IRequestDataFromService> action);
    }
}
