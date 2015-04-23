using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
{
    public abstract class RequestField : IAmRequestField
    {
        public string Field { get; private set; }

        protected RequestField(string field)
        {
            Field = field;
        }
    }
}