
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IRolePermission : IEntity, IExpirable
    {
        PackageBuilder.Domain.Entities.IRole Role { get; }
        IAction Action { get; }
    }
}