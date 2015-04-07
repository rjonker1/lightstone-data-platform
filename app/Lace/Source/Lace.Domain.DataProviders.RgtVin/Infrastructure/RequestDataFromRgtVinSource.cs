using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class RequestDataFromRgtVinSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalWebService, ISendCommandToBus command)
        {
            externalWebService.CallTheDataProvider(response, command);
        }
    }
}
