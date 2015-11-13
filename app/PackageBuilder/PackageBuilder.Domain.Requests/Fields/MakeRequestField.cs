using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class MakeRequestField : IAmMakeRequestField
    {
        public string Field { get; private set; }

        public MakeRequestField(string field)
        {
            Field = field;
        }
    }
}