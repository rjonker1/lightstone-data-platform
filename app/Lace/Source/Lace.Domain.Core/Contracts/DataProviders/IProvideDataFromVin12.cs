using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Vin12;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromVin12 : IPointToLaceProvider
    {
        IAmVin12Request Request { get; }
        IEnumerable<IRespondWithVin12> Vin12Information { get; } 
    }
}
