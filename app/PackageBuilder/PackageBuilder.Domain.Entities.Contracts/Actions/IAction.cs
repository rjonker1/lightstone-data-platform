
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Contracts.Actions
{
    public interface IAction : INamedEntity, IEntity
    {
        ICriteria Criteria { get; }
    }
}