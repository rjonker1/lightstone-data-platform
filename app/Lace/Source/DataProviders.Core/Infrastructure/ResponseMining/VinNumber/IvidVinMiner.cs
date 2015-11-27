using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;

namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.VinNumber
{
    public sealed class IvidVinMiner : AbstractDataProviderResponseMiner
    {
        public IvidVinMiner(IMineDataProviderResponse nextMiner, ICollection<IPointToLaceProvider> response)
            : base(
                nextMiner,
                response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
                    ? response.OfType<IProvideDataFromIvid>().First().Vin
                    : string.Empty)
        {

        }
    }
}
