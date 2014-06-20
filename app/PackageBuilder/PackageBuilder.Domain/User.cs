using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class User : NamedEntity, IUser
    {
        private readonly IList<IUserRole> _userRoles = new List<IUserRole>();
        private readonly IList<IUserGroup> _userGroups = new List<IUserGroup>(); 
        public User(string name)
            : base(name)
        {
        }

        public ICustomer Customer { get; set; }

        public IEnumerable<IUserGroup> UserGroups
        {
            get { return _userGroups; }
        }

        public IEnumerable<IUserRole> UserRoles
        {
            get { return _userRoles; }
        }

        public IEnumerable<IRole> Roles
        {
            get { return _userRoles.Select(x => x.Role); }
        }

        public IEnumerable<IGroup> Groups
        {
            get { return _userGroups.Select(x => x.Group); }
        }

        public bool HasGroups
        {
            get { return Groups != null && Groups.Any(); }
        }

        public bool HasRoles
        {
            get { return Roles != null && Roles.Any(); }
        }

        public bool HasSingleGroup
        {
            get { return HasGroups && Groups.Count() == 1 && !HasRoles; }
        }

        public bool HasSingleRole
        {
            get { return HasRoles && Roles.Count() == 1 && !HasGroups; }
        }

        public bool HasSingleGroupAndRole
        {
            get { return HasSingleGroup && HasSingleRole; }
        }

        public bool HasMultipleGroups
        {
            get { return HasGroups && Groups.Count() > 1 && !HasRoles; }
        }

        public bool HasMultipleRoles
        {
            get { return HasRoles && Roles.Count() > 1 && !HasGroups; }
        }

        public bool HasMultipleGroupsAndRoles
        {
            get { return HasMultipleGroups && HasMultipleRoles; }
        }

        public IGroup DefaultGroup
        {
            get
            {
                return HasSingleGroup ? Groups.First() : null;
            }
        }

        public IRole DefaultRole
        {
            get
            {
                return HasSingleRole ? Roles.First() : null;
            }
        }
    }
}