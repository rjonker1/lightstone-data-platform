using Castle.Facilities.TypedFactory.Internal;
using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class Vin12Request : IAmVin12Request
    {
        public static Vin12Request WithVinNumber(string vinNumber)
        {
            return new Vin12Request
            {
                VinNumber = VinNumberRequestField.Get(vinNumber)
            };
        }

        public static Vin12Request Empty()
        {
            return new Vin12Request();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}