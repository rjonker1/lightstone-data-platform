using System;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class HandleIvidTitleHolderServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new RequestDatafromIvidTitleHolderService());
        }
    }
}
