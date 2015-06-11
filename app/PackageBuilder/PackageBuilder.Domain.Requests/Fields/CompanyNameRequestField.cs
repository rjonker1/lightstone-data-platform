using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class CompanyNameRequestField : IAmCompanyNameRequestField
    {
        public string Field { get; private set; }

        public CompanyNameRequestField(string field)
        {
            Field = field;
        }
    }
}
