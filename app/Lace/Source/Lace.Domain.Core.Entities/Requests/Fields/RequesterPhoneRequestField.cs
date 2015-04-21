using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
{
    public class RequesterPhoneRequestField : IAmRequesterPhoneRequestField
    {
        public string Field { get; private set; }
    }
}