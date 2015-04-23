using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class ImageRequestField : IAmImageRequestField
    {
        public string Field { get; private set; }

        public ImageRequestField(string field)
        {
            Field = field;
        }
    }
}