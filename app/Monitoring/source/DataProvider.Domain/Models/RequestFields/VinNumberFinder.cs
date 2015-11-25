using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Models.RequestFields
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