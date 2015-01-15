using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

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

        public void ConsumeExternalSource(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromSource(response, _externalWebSourceCall, monitoring));
        }
    }
}
