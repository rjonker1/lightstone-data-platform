using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure
{
    public class HandleBmwFinancedInterestsSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromBmwFinancedInterests());
        }
    }
}