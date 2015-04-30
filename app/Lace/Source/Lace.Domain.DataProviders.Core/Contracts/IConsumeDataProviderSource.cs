using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConsumeDataProviderSource
    {
        void ConsumeDataProvider(ICollection<IPointToLaceProvider> response);
    }
}
