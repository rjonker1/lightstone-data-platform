using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IRolePermission : IEntity, IExpirable
    {
        IRole Role { get; }
        IAction Action { get; }
    }
}