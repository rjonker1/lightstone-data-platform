using Lace.Events;
using Lace.Models.Request.LicensePlateNumber;
using Lace.Response;

namespace Lace.Request.Types.LicensePlateNumber.Chain
{
    public class LicensePlateNumberSourceChain
    {
        private readonly ILaceResponse _response;

        public LicensePlateNumberSourceChain()
        {
            _response = new LaceResponse();
        }

        public LicensePlateNumberResponse Build(ILaceRequest request, ILaceEvent laceEvent)
        {
            var handlers = new Handlers.LicensePlateNumberHandlers().Handlers;

            foreach (var handler in handlers)
            {
                handler.Value(request, laceEvent, _response);
            }

            return new LicensePlateNumberResponse() {Response = _response};
        }
    }
}