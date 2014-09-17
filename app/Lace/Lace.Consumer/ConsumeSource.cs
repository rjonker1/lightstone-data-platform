using Lace.Events;
using Lace.Models;
using Lace.Source;

namespace Lace.Consumer
{
    public class ConsumeSource : IConsumeSource
    {
        private readonly ICallTheSource _externalWebSourceCall;
        private readonly IHandleSourceCall _handleServiceCall;
        

        public ConsumeSource(IHandleSourceCall handleServiceCall,
            ICallTheSource externalSourceCall)
        {
            _handleServiceCall = handleServiceCall;
            _externalWebSourceCall = externalSourceCall;
        }

        public void ConsumeExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            _handleServiceCall
                .Request(c =>
                    c.FetchDataFromSource(response, _externalWebSourceCall, laceEvent));
        }
    }
}
