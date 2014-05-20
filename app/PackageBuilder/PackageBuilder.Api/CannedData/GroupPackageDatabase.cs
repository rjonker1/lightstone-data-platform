using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class GroupPackageDatabase : CannedDatabase<IGroupPackage>
    {
        public static IEnumerable<IGroup> GetGroups(IUser user)
        {
            return Entities.Where(x => x.Customer.Users.Contains(user) && x.Package != null).Select(x => x.Group);
        }
    }
}