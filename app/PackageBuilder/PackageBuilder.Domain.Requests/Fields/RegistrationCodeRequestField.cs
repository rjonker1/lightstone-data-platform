using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class RegistrationCodeRequestField : IAmRegistrationCodeRequestField
    {
        public RegistrationCodeRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
