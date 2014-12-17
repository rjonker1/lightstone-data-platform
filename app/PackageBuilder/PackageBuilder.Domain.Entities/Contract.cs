
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class Contract : NamedEntity, IContract
    {
        public Contract(string name)
            : base(name)
        {
        }

        public ICustomer Customer { get; set; }
    }
}