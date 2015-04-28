using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class LicenceNumberRequestField : IAmLicenceNumberRequestField
    {
        public string Field { get; private set; }

        public LicenceNumberRequestField(string field)
        {
            Field = field;
        }
    }
}