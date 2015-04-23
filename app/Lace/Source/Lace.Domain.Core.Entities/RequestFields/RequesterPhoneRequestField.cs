using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class RequesterPhoneRequestField : IAmRequesterPhoneRequestField
    {
        public string Field { get; private set; }

        public RequesterPhoneRequestField(string field)
        {
            Field = field;
        }
    }
}