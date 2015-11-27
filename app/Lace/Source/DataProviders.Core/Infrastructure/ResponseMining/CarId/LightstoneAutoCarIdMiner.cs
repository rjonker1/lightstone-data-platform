using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;

namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.CarId
{
    public sealed class LightstoneAutoCarIdMiner : AbstractDataProviderResponseMiner
    {
        public LightstoneAutoCarIdMiner(IMineDataProviderResponse nextMiner, ICollection<IPointToLaceProvider> response)
            : base(
                nextMiner,
                response.Exists<IProvideDataFromLightstoneAuto>() && response.Exists<IProvideDataFromLightstoneAuto>() &&
                response.OfType<IProvideDataFromLightstoneAuto>().First().Handled
                    ? response.OfType<IProvideDataFromLightstoneAuto>().First().CarId ?? 0
                    : 0)
        {

        }
    }
}