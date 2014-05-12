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

        public LicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Handlers.LicensePlateNumberHandlers().HandlersDictionary;

            foreach (var handler in handlers)
            {
                handler.Value(request, _response);
            }

            return new LicensePlateNumberResponse() {Response = _response};
        }
    }
}