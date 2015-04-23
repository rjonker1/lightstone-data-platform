using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class EngineNumberRequestField : IAmEngineNumberRequestField
    {
        public string Field { get; private set; }
        public EngineNumberRequestField(string field)
        {
            Field = field;
        }
    }
}