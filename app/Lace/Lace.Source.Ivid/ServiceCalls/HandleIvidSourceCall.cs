using System;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class HandleIvidSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromIvidSource());
        }
    }
}
