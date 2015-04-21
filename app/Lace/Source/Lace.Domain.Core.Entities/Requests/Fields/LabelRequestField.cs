using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
{
    public class LabelRequestField : IAmLabelRequestField
    {
        public string Field { get; private set; }
    }
}