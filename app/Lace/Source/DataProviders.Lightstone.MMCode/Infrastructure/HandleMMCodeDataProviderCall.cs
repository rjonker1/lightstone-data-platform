using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace DataProviders.Lightstone.MMCode.Infrastructure
{
    public sealed class HandleMMCodeDataProviderCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromMMCodeSource());
        }
    }
}