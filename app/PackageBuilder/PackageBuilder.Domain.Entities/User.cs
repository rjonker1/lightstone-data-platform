using System.Collections.Generic;
using System.Linq;

namespace PackageBuilder.Domain.Entities
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

        public void Add(IRole role)
        {
            if (role == null) return;

            var userRole = _userRoles.FirstOrDefault(x => Equals(x.Role, role));
            if (userRole != null) return;

            userRole = new UserRole(this, role);
            _userRoles.Add(userRole);
        }

        public void Add(IGroup group)
        {
            if (group == null) return;

            var userGroup = _userGroups.FirstOrDefault(x => Equals(x.Group, group));
            if (userGroup != null) return;

            userGroup = new UserGroup(this, group);
            _userGroups.Add(userGroup);
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
            get { return HasGroups && Groups.Count() == 1; }
        }

        public bool HasSingleRole
        {
            get { return HasRoles && Roles.Count() == 1; }
        }

        public bool HasSingleGroupAndRole
        {
            get { return HasSingleGroup && HasSingleRole; }
        }

        public bool HasMultipleGroups
        {
            get { return HasGroups && Groups.Count() > 1; }
        }

        public bool HasMultipleRoles
        {
            get { return HasRoles && Roles.Count() > 1; }
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