using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
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