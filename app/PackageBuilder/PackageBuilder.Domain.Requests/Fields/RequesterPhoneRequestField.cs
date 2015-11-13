using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class RequesterPhoneRequestField : IAmRequesterPhoneRequestField
    {
        public string Field { get; private set; }

        public RequesterPhoneRequestField(string field)
        {
            Field = field;
        }
    }
}