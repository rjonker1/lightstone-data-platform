using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure
{
    public class HandleConsumerSpecificationsSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromConsumerSpecifications());
        }
    }
}
