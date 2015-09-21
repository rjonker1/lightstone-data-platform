using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class MmCodeRequestType: IAmMmCodeRequest
    {
        private MmCodeRequestType()
        {
        }

        public static IAmMmCodeRequest Empty()
        {
            return new MmCodeRequestType();
        }

        public static IAmMmCodeRequest WithCarId(string carId)
        {
            return new MmCodeRequestType()
            {
                CarId = CarIdRequestField.Get(carId)
            };
        }

        public IAmCarIdRequestField CarId { get; private set; }
    }
}
