using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class Vin12Request : IAmVin12Request
    {
        public Vin12Request(IAmVinNumberRequestField vinNumber)
        {
            VinNumber = vinNumber;
        }
        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}
