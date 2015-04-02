using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConsumeDataProviderSource
    {
        void ConsumeExternalSource(ICollection<IPointToLaceProvider> response, ISendCommandToBus command);
    }
}
