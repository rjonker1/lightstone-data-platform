using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IExecuteTheDataProviderSource
    {
        void CallSource(ICollection<IPointToLaceProvider> response);
    }
}
