using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class Vin12Response
    {
        public Lace.Domain.Core.Entities.Vin12Response Default()
        {
            var result = new Lace.Domain.Core.Entities.Vin12Response(new List<Vin12Record>
            {
                new Vin12Record(0,0,"","","","")
            });
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
