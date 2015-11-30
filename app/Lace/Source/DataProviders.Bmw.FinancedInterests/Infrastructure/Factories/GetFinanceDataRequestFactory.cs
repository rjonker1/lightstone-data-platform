using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Base;
using Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Dto;
using Lace.Domain.DataProviders.Bmw.Finance.Queries;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Dtos;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Factories
{
    public sealed class GetFinanceDataRequestFactory :
        AbstractGetFinanceRequestFactory<IBmwFinanceQuery, IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>, IEnumerable<BmwFinanceDto>>
    {
        private static readonly IMineDataProviderResponseFactory Factory = new ResponseDataMiningFactory();

        public override IEnumerable<BmwFinanceDto> Get(IBmwFinanceQuery query, IAmBmwFinanceRequest request,
            ICollection<IPointToLaceProvider> response)
        {
            var vinNumber = !string.IsNullOrEmpty(request.VinNumber.GetValue())
                ? request.VinNumber.GetValue()
                : Factory.BuildVinMiners(response).MineVin();

            var engineNumber = !string.IsNullOrEmpty(request.EngineNumber.GetValue())
                ? request.EngineNumber.GetValue()
                : Factory.BuildEngineNumberMiners(response).MineEngineNumber();

            var vinEngineNumber = new VinEngineIdDto(vinNumber, engineNumber).VinAndEngineNumber;
            return !string.IsNullOrEmpty(vinEngineNumber)
                ? query.GetWithVinEngineId(vinEngineNumber)
                : Enumerable.Empty<BmwFinanceDto>();
        }
    }
}