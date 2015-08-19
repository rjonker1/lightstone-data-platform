using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class EmailAddressRequestField : IAmEmailAddressRequestField
    {
        public string Field { get; private set; }

        public EmailAddressRequestField(string field)
        {
            Field = field;
        }
    }
}
