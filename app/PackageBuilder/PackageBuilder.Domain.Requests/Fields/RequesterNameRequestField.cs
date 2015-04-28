using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class RequesterNameRequestField : IAmRequesterNameRequestField
    {
        public string Field { get; private set; }

        public RequesterNameRequestField(string field)
        {
            Field = field;
        }
    }
}