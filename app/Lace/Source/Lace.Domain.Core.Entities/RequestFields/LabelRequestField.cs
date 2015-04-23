using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
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