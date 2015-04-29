using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
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