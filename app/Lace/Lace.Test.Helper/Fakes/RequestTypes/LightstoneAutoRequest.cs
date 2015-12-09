using System;
using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class LightstoneAutoRequest : IAmLightstoneAutoRequest
    {
        private LightstoneAutoRequest()
        {
            
        }

        public static IAmLightstoneAutoRequest Empty()
        {
            return new LightstoneAutoRequest();
        }

        public static IAmLightstoneAutoRequest WithVin(string vinNumber)
        {
            return new LightstoneAutoRequest()
            {
                VinNumber = VinNumberRequestField.Get(vinNumber)
            };
        }

        

        public static IAmLightstoneAutoRequest WithCarIdAndYear(int carId, int year)
        {
            return new LightstoneAutoRequest()
            {
                CarId = CarIdRequestField.Get((Convert.ToString(carId))),
                Year = YearRequestField.Get((Convert.ToString(year)))
            };
        }

        public static IAmLightstoneAutoRequest WithCarId(int carId)
        {
            return new LightstoneAutoRequest()
            {
                CarId = CarIdRequestField.Get(Convert.ToString(carId))
            };
        }


        public IAmCarIdRequestField CarId { get; private set; }

        public IAmMakeRequestField Make { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmYearRequestField Year { get; private set; }
    }
}
