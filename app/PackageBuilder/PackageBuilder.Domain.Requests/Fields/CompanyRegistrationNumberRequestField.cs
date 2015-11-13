using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class CompanyRegistrationNumberRequestField : IAmCompanyRegistrationNumberRequestField
    {
        public string Field { get; private set; }

        public CompanyRegistrationNumberRequestField(string field)
        {
            Field = field;
        }
    }
}
