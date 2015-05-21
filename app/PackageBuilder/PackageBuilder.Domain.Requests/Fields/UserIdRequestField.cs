using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class UserIdRequestField : IAmUserIdRequestField
    {
        public UserIdRequestField(string field)
        {
            Field = field;
        }
        public string Field { get; private set; }
    }
}
