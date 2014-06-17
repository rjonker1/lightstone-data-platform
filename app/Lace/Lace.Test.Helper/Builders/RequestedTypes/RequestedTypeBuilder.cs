using Lace.Request.Entry;
using Lace.Test.Helper.Fakes.Loader;

namespace Lace.Test.Helper.Builders.RequestedTypes
{
    public class RequestedTypeBuilder
    {
       
        public IGetRequiredRequestedTypes ForLicensePlateNumber()
        {
            return new FakeRequestedTypesForLicensePlateNumber();
        }

    }
}
