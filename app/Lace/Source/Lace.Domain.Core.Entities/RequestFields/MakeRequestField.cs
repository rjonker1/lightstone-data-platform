using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class MakeRequestField : IAmMakeRequestField
    {
        public string Field { get; private set; }

        public MakeRequestField(string field)
        {
            Field = field;
        }
    }
}