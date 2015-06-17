using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.Metadata.DataProviders.Signio.DriversLicense.Infrastructure
{
    public class HandleSignioSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromSignioSource());
        }
    }
}
