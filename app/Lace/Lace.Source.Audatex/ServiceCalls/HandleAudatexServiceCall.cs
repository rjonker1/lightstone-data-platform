using System;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class HandleAudatexServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new RequestDataFromAudatexService());
        }
    }
}
