using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Contracts.Industries.Read
{
    public interface IIndustry : IEntity, INamedEntity
    {
        bool IsSelected { get; set; }
    }
}