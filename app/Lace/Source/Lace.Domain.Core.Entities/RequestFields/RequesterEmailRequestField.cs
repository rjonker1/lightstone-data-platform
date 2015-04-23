using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class RequesterEmailRequestField : IAmRequesterEmailRequestField
    {
        public string Field { get; private set; }

        public RequesterEmailRequestField(string field)
        {
            Field = field;
        }
    }
}