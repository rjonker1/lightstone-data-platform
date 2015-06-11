using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure
{
    public class HandleLightstoneBusinessCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromLightstoneBusinessSource());
        }
    }
}
