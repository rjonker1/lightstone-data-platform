using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class IdentityNumberRequestField : IAmIdentityNumberRequestField
    {
        public string Field { get; private set; }

        public IdentityNumberRequestField(string field)
        {
            Field = field;
        }
    }
}