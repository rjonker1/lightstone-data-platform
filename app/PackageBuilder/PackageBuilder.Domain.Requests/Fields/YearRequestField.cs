using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class YearRequestField : IAmYearRequestField
    {
        public string Field { get; private set; }

        public YearRequestField(string field)
        {
            Field = field;
        }
    }
}
