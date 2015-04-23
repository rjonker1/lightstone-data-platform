using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
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