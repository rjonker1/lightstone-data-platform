using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendCommandToBus command);
        void TransformResponse(ICollection<IPointToLaceProvider> response, ISendCommandToBus command);
    }
}
