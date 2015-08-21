using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class AccessKeyRequestField: IAmAccessKeyRequestField
    {
        public string Field { get; private set; }

        public AccessKeyRequestField(string field)
        {
            Field = field;
        }
    }
}