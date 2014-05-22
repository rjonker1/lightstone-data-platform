using Lace.Models.RgtVin.Dto;
using Lace.Request;

namespace Lace.Source.RgtVin.ServiceConfig
{
    public class ConfigureRgtVinRequestMessage
    {
        public RgtVinRequest RgtVinRequest { get; private set; }

        public ConfigureRgtVinRequestMessage(ILaceRequest request)
        {
            RgtVinRequest = new RgtVinRequest()
            {
                SecurityCode = request.Context.SecurityCode,
                Vin =  request.Vehicle.Vin
            };
        }
    }
}
