using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class ReasonForApplicationRequestField : IAmReasonForApplicationRequestField
    {
        public string Field { get; private set; }

        public ReasonForApplicationRequestField(string field)
        {
            Field = field;
        }
    }
}