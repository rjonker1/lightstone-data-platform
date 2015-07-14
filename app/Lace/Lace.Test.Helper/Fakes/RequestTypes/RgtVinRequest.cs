using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class RgtVinRequest : IAmRgtVinRequest
    {
        private RgtVinRequest()
        {
            
        }

        public static IAmRgtVinRequest Empty()
        {
            return new RgtVinRequest();
        }

        public static IAmRgtVinRequest WithVin(string vinNumber)
        {
            return new RgtVinRequest()
            {
                VinNumber = VinNumberRequestField.Get(vinNumber)
            };
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}
