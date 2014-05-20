using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class ActionDatabase : CannedDatabase<IAction>
    {
        public ActionDatabase()
        {
            Add(new Action("Get EzScore"));
        }
    }
}