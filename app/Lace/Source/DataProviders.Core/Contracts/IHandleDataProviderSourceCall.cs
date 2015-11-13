using System;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IHandleDataProviderSourceCall
    {
       void Request(Action<IRequestDataFromDataProviderSource> action);
    }
}
