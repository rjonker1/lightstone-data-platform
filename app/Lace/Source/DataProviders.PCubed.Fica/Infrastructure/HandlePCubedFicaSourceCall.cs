using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.PCubed.Fica.Infrastructure
{
    public class HandlePCubedFicaSourceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromPCubedFicaSource());
        }
    }
}
