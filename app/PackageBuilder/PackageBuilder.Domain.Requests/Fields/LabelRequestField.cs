using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class LabelRequestField : IAmLabelRequestField
    {
        public string Field { get; private set; }

        public LabelRequestField(string field)
        {
            Field = field;
        }
    }
}