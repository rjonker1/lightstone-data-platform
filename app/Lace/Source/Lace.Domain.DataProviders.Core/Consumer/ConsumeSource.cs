using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

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

        public void ConsumeExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromSource(response, _externalWebSourceCall, laceEvent));
        }
    }
}
