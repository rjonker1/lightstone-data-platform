using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class RolePackageDatabase : CannedDatabase<IRolePackage>
    {
        public static IEnumerable<IRole> GetRoles(IUser user)
        {
            return Entities.Where(x => x.Customer.Users.Contains(user) && x.Package != null).Select(x => x.Role);
        }
    }
}