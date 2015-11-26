
using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Models.RequestFields
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