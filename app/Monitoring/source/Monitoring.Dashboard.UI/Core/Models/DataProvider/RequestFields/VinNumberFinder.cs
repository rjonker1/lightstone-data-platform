using Monitoring.Dashboard.UI.Core.Enums;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields
{
    public class VinNumberFinder : AbstractRequestFieldFinder
    {
        public VinNumberFinder() : base(RequestFieldType.VinNumber)
        {

        }

        public VinNumberFinder(IFindRequestField next)
            : base(next, RequestFieldType.VinNumber)
        {

        }
    }
}