namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto
{
    public class RgtVinRequest
    {
        public string Vin { get; private set; }
        public string SecurityCode { get; private set; }

        public RgtVinRequest(string vin, string securityCode)
        {
            Vin = vin;
            SecurityCode = securityCode;
        }
    }
}
