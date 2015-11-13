using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class PhoneNumberRequestField : IAmPhoneNumberRequestField
    {
        public string Field { get; private set; }

        public PhoneNumberRequestField(string field)
        {
            Field = field;
        }
    }
}
