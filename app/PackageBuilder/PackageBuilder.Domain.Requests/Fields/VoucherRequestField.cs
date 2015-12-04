using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class VoucherRequestField : IAmVoucherCodeRequestField
    {
        public VoucherRequestField(string field)
        {
            Field = field;
        }

        public string Field { get; private set; }
    }
}