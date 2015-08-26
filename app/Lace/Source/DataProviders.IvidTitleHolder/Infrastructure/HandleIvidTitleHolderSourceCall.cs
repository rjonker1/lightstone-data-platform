using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public sealed class HandleIvidTitleHolderSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDatafromIvidTitleHolderSource());
        }
    }
}
