using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class ScanDataRequestField : IAmScanDataRequestField
    {
        public ScanDataRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
