using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class HandleIvidTitleHolderSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDatafromIvidTitleHolderSource());
        }
    }
}
