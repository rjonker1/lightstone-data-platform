using Monitoring.Dashboard.UI.Core.Enums;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields
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