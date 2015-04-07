using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Workflow.Lace.Messages.Core;


namespace Lace.Domain.DataProviders.Core.Consumer
{
    public class ConsumeSource : IConsumeDataProviderSource
    {
        private readonly ICallTheDataProviderSource _externalWebSourceCall;
        private readonly IHandleDataProviderSourceCall _handleServiceCall;


        public ConsumeSource(IHandleDataProviderSourceCall handleServiceCall,
            ICallTheDataProviderSource externalSourceCall)
        {
            _handleServiceCall = handleServiceCall;
            _externalWebSourceCall = externalSourceCall;
        }

        public void ConsumeExternalSource(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromSource(response, _externalWebSourceCall, command));
        }
    }
}
