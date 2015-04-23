using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
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