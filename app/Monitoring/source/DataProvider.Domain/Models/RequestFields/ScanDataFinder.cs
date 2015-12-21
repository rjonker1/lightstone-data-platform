using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Models.RequestFields
{
    public class ScanDataFinder: AbstractRequestFieldFinder
    {
        public ScanDataFinder() : base(RequestFieldType.ScanData)
        {

        }

        public ScanDataFinder(IFindRequestField next)
            : base(next, RequestFieldType.ScanData)
        {

        }
    }
}