using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
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
    }
}