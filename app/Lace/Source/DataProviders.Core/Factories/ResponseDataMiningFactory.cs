using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining;
using Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.CarId;
using Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.EngineNumber;
using Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining.VinNumber;

namespace Lace.Domain.DataProviders.Core.Factories
{
    public class ResponseDataMiningFactory : IMineDataProviderResponseFactory
    {
        public IMineDataProviderResponse BuildVinMiners(ICollection<IPointToLaceProvider> response)
        {
            //order to execute
            return new LightstoneAutoVinMiner(new IvidVinMiner(new RgtVinVinMiner(new NullResponseMiner(), response), response), response);
        }

        public IMineDataProviderResponse BuildCarIdMiners(ICollection<IPointToLaceProvider> response)
        {
            return new LightstoneAutoCarIdMiner(new RgtVinCarIdMiner(new NullResponseMiner(), response), response);
        }

        public IMineDataProviderResponse BuildEngineNumberMiners(ICollection<IPointToLaceProvider> response)
        {
            return new EngineNumberMiner(new NullResponseMiner(), response);
        }
    }

    public interface IMineDataProviderResponseFactory
    {
        IMineDataProviderResponse BuildVinMiners(ICollection<IPointToLaceProvider> response);
        IMineDataProviderResponse BuildCarIdMiners(ICollection<IPointToLaceProvider> response);
        IMineDataProviderResponse BuildEngineNumberMiners(ICollection<IPointToLaceProvider> response);
    }
}