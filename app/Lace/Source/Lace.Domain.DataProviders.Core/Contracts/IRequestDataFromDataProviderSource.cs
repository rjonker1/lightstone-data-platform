using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IRequestDataFromDataProviderSource
    {
        void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalSource);
    }
}
