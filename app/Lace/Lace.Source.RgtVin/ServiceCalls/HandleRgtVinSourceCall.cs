using System;
namespace Lace.Source.RgtVin.ServiceCalls
{
    public class HandleRgtVinSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromRgtVinSource());
        }
    }
}
