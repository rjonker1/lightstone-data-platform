using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Infrastructure.ResponseMining
{
    public class NullResponseMiner : IMineDataProviderResponse
    {
        public string MineVin()
        {
            return string.Empty;
        }

        public int MineCarId()
        {
            return 0;
        }


        public string MineEngineNumber()
        {
            return string.Empty;
        }
    }
}