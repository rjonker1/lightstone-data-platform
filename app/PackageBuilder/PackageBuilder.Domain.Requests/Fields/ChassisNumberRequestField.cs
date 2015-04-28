using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
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