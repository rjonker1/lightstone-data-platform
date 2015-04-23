using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class LicenseNumberRequestField : IAmLicenseNumberRequestField
    {
        public string Field { get; private set; }

        public LicenseNumberRequestField(string field)
        {
            Field = field;
        }
    }
}