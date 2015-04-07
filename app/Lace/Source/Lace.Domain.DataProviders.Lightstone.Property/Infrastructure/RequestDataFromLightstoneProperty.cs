using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Workflow.Lace.Messages.Core;


namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class RequestDataFromLightstonePropertySource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalSource,
            ISendCommandToBus command)
        {
            externalSource.CallTheDataProvider(response, command);
        }
    }
}
