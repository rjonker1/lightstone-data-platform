using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class ChassisNumberRequestField : IAmChassisNumberRequestField
    {
        public string Field { get; private set; }

        public ChassisNumberRequestField(string field)
        {
            Field = field;
        }
    }
}