using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class Role : NamedEntity, IRole
    {
        private readonly List<IRolePermission> _rolePermissions = new List<IRolePermission>();
        public Role(string name)
            : base(name)
        {
        }

        public IEnumerable<IRolePermission> RolePermissions
        {
            get { return _rolePermissions; }
        }

        public IEnumerable<IAction> Actions
        {
            get { return _rolePermissions.Select(x => x.Action); }
        }

        public void Add(IAction action)
        {
            if (action == null) return;

            var groupPermission = _rolePermissions.FirstOrDefault(x => Equals(x.Action, action));
            if (groupPermission != null) return;

            groupPermission = new RolePermission(this, action);
            _rolePermissions.Add(groupPermission);
        }
    }
}