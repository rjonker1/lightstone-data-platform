using System;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;
using Action = PackageBuilder.Api.Entities.Action;

namespace PackageBuilder.Api.CannedData
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }

    public class ActionRepository : NamedRepository<IAction>, IActionRepository
    {
        public ActionRepository()
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