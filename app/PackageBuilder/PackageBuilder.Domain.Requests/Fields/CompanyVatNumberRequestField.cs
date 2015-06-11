using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class CompanyVatNumberRequestField : IAmCompanyVatNumberRequestField
    {
        public string Field { get; private set; }

        public CompanyVatNumberRequestField(string field)
        {
            Field = field;
        }
    }
}