using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class MaxRowsToReturnRequestField : IAmMaxRowsToReturnRequestField
    {
        public MaxRowsToReturnRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
