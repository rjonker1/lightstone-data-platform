using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class HandleLightstonePropertyCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromLightstonePropertySource());
        }
    }
}
