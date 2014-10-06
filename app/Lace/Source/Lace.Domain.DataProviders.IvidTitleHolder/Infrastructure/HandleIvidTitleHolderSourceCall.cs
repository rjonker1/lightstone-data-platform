using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class HandleIvidTitleHolderSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDatafromIvidTitleHolderSource());
        }
    }
}
