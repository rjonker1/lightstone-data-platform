using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class RequesterNameRequestField : IAmRequesterNameRequestField
    {
        public string Field { get; private set; }

        public RequesterNameRequestField(string field)
        {
            Field = field;
        }
    }
}