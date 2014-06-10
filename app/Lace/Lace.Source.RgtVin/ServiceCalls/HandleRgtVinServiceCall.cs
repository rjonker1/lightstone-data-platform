using System;
namespace Lace.Source.RgtVin.ServiceCalls
{
    public class HandleRgtVinServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new RequestDataFromRgtVinService());
        }
    }
}
