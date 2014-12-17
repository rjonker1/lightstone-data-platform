using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class Group : NamedEntity, IGroup
    {
        private readonly List<IGroupPermission> _groupPermissions = new List<IGroupPermission>();
        public Group(string name)
            : base(name)
        {
        }

        public IEnumerable<IGroupPermission> GroupPermissions
        {
            get { return _groupPermissions; }
        }

        public IEnumerable<IAction> Actions
        {
            get { return _groupPermissions.Select(x => x.Action); }
        }

        public void Add(IAction action)
        {
            if (action == null) return;

            var groupPermission = _groupPermissions.FirstOrDefault(x => Equals(x.Action, action));
            if (groupPermission != null) return;

            groupPermission = new GroupPermission(this, action);
            _groupPermissions.Add(groupPermission);
        }
    }
}