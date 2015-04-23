using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class UsernameRequestField : IAmUsernameRequestField
    {
        public string Field { get; private set; }

        public UsernameRequestField(string field)
        {
            Field = field;
        }
    }
}