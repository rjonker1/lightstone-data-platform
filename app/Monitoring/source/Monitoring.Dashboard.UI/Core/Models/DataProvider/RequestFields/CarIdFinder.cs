using Monitoring.Dashboard.UI.Core.Enums;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields
{
    public class CarIdFinder : AbstractRequestFieldFinder
    {
        public CarIdFinder() : base(RequestFieldType.CarId)
        {

        }

        public CarIdFinder(IFindRequestField next)
            : base(next, RequestFieldType.CarId)
        {

        }
    }
}