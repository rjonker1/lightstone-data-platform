using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
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
    }
}