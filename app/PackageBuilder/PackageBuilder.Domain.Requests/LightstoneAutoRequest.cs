using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class LightstoneAutoRequest : IAmLightstoneAutoRequest
    {
        public IAmCarIdRequestField CarId { get; private set; }
        public IAmYearRequestField Year { get; private set; }
        public IAmMakeRequestField Make { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }

        public LightstoneAutoRequest(IAmCarIdRequestField carId, IAmYearRequestField year, IAmMakeRequestField make, IAmVinNumberRequestField vinNumber)
        {
            CarId = carId;
            Year = year;
            Make = make;
            VinNumber = vinNumber;
        }
    }
}