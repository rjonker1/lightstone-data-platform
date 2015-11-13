using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class SurnameRequestField : IAmSurnameRequestField
    {
        public string Field { get; private set; }

        public SurnameRequestField(string field)
        {
            Field = field;
        }
    }
}