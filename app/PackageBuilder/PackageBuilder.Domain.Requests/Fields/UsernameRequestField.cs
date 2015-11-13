using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class UsernameRequestField : IAmUserNameRequestField
    {
        public UsernameRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
