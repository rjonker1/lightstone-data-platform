using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;

namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.EngineNumber
{
    public sealed class EngineNumberMiner : AbstractDataProviderResponseMiner
    {
        public EngineNumberMiner(IMineDataProviderResponse nextMiner, ICollection<IPointToLaceProvider> response)
            : base(
                nextMiner,
                response.Exists<IProvideDataFromIvid>() && response.OfType<IProvideDataFromIvid>().First().Handled
                ? response.OfType<IProvideDataFromIvid>().First().Engine
                : string.Empty)
        {

        }
    }
}
