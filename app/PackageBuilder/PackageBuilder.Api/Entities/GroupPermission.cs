using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class GroupPermission : IGroupPermission
    {
        public Guid Id { get; set; }
        public DateTime ValidUntil { get; set; }
        public IGroup Group { get; set; }
        public IAction Action { get; set; }

        public GroupPermission(IGroup @group, IAction action)
        {
            Group = @group;
            Action = action;
        }
    }
}