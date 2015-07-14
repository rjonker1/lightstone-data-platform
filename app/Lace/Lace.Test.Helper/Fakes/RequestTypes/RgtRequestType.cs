using System;
using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class RgtRequestType : IAmRgtRequest
    {
        private RgtRequestType()
        {
        }

        public static IAmRgtRequest Empty()
        {
            return new RgtRequestType();
        }

        public static IAmRgtRequest WithCarId(string carId)
        {
            return new RgtRequestType()
            {
                CarId = CarIdRequestField.Get(carId)
            };
        }

        public IAmCarIdRequestField CarId { get; private set; }
    }
}
