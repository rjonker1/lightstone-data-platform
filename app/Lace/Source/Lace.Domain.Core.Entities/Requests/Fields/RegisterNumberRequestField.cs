using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
{
    public class RegisterNumberRequestField : IAmRegisterNumberRequestField
    {
        public string Field { get; private set; }

        public RegisterNumberRequestField(string field)
        {
            Field = field;
        }
    }
}