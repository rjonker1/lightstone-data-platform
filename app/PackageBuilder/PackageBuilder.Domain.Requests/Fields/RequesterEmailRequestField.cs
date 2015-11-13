using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class RequesterEmailRequestField : IAmRequesterEmailRequestField
    {
        public string Field { get; private set; }

        public RequesterEmailRequestField(string field)
        {
            Field = field;
        }
    }
}