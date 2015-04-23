using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class VinNumberRequestField : IAmVinNumberRequestField
    {
        public string Field { get; private set; }

        public VinNumberRequestField(string field)
        {
            Field = field;
        }
    }
}