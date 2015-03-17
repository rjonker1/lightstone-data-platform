using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.Domain.Entities.Contracts.States.Read
{
    public interface IState : IEntity
    {
        StateName Name { get; set; }
        string Alias { get; set; }
    }
}