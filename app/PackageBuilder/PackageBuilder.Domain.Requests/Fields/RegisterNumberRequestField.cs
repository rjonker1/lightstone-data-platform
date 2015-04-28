using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class RegisterNumberRequestField : IAmRegisterNumberRequestField
    {
        public string Field { get; private set; }

        public RegisterNumberRequestField(string field)
        {
            Field = field;
        }
    }
}