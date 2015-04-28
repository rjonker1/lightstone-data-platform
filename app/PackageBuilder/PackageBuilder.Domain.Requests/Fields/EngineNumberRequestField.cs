using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
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