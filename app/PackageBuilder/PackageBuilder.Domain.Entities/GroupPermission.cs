using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class GroupPermission : IGroupPermission
    {
        public Guid Id { get; private set; }
        public DateTime ValidUntil { get; set; }
        public IGroup Group { get; set; }
        public IAction Action { get; set; }

        public GroupPermission(IGroup @group, IAction action)
        {
            Id = Guid.NewGuid();
            Group = @group;
            Action = action;
        }
    }
}