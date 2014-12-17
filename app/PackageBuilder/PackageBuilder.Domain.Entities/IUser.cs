using System.Collections.Generic;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IUser : INamedEntity
    {
        ICustomer Customer { get; }
        IEnumerable<IUserGroup> UserGroups { get; }
        IEnumerable<IUserRole> UserRoles { get; }
        IEnumerable<IRole> Roles { get; }
        IEnumerable<IGroup> Groups { get; }
        void Add(IRole role);
        void Add(IGroup group);
        bool HasGroups { get; }
        bool HasRoles { get; }
        bool HasSingleGroup { get; }
        bool HasSingleRole { get; }
        bool HasSingleGroupAndRole { get; }
        bool HasMultipleGroups { get; }
        bool HasMultipleRoles { get; }
        bool HasMultipleGroupsAndRoles { get; }
        IGroup DefaultGroup { get; }
        IRole DefaultRole { get; }
    }
}