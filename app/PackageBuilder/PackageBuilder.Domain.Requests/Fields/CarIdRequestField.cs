using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class CarIdRequestField : IAmCarIdRequestField
    {
        public string Field { get; private set; }

        public CarIdRequestField(string field)
        {
            Field = field;
        }
    }
}