using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }

    public class ActionCannedRepository : NamedCannedRepository<IAction>, IActionRepository
    {
        public ActionCannedRepository()
        {
            Add(
                new Action("Get EzScore"),
                new Action("License plate search")
                {
                    Criteria = new Criteria
                    {
                        Fields = new IDataField[]
                        {
                            new DataField("LicenceNo") {Type = typeof (string).ToString()},
                            new DataField("Vin") {Type = typeof (string).ToString()}
                        }
                    }
                }
                );
        }
    }
}