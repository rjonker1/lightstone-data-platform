using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class FirstNameRequestField : IAmFirstNameRequestField
    {
        public string Field { get; private set; }

        public FirstNameRequestField(string field)
        {
            Field = field;
        }
    }
}