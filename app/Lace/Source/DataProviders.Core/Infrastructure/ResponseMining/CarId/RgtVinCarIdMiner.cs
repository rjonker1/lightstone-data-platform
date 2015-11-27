using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;

namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.CarId
{
    public sealed class RgtVinCarIdMiner: AbstractDataProviderResponseMiner
    {
        public RgtVinCarIdMiner(IMineDataProviderResponse nextMiner, ICollection<IPointToLaceProvider> response)
            : base(
                nextMiner,
                response.Exists<IProvideDataFromRgtVin>() && response.OfType<IProvideDataFromRgtVin>().First().Handled
                        ? response.OfType<IProvideDataFromRgtVin>().First().CarId : 0)
        {

        }
    }
}