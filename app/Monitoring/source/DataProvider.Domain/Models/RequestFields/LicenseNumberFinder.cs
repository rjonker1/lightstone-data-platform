using DataProvider.Domain.Enums;
namespace DataProvider.Domain.Models.RequestFields
{
    public class LicenseNumberFinder : AbstractRequestFieldFinder
    {
        public LicenseNumberFinder() : base(RequestFieldType.LicenceNumber)
        {

        }

        public LicenseNumberFinder(IFindRequestField next)
            : base(next, RequestFieldType.LicenceNumber)
        {

        }
    }
}