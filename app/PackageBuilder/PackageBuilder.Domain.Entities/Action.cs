
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Actions;

namespace PackageBuilder.Domain.Entities
{
    public class Action : NamedEntity, IAction
    {
        public Action()
        {
            
        }

        public Action(string name)
            : base(name)
        {
        }

        public ICriteria Criteria { get; set; }
    }
}