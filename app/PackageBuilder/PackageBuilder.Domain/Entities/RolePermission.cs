using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class RolePermission : IRolePermission
    {
        public Guid Id { get; private set; }
        public DateTime ValidUntil { get; set; }
        public IRole Role { get; set; }
        public IAction Action { get; set; }

        public RolePermission(IRole role, IAction action)
        {
            Id = Guid.NewGuid();
            Role = role;
            Action = action;
        }
    }
}