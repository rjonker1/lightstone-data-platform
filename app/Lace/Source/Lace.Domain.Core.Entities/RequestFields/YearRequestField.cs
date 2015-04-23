using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class YearRequestField : IAmYearRequestField
    {
        public string Field { get; private set; }

        public YearRequestField(string field)
        {
            Field = field;
        }
    }
}