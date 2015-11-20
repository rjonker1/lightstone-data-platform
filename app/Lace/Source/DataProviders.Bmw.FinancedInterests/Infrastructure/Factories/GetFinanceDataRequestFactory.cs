using System;
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
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();

        public override IEnumerable<BmwFinanceDto> Get(IBmwFinanceQuery query, IAmBmwFinanceRequest request,
            ICollection<IPointToLaceProvider> response)
        {
            var records = Enumerable.Empty<BmwFinanceDto>();
            foreach (var fields in RequestFields.OrderBy(o => (int) o.Key))
            {
                records = fields.Value(request, response, query);
                if (records != null)
                    break;
            }

            return records ?? Enumerable.Empty<BmwFinanceDto>();
        }

        private static readonly
            IDictionary<Order, Func<IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>, IBmwFinanceQuery, IEnumerable<BmwFinanceDto>>>
            RequestFields = new Dictionary
                <Order, Func<IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>, IBmwFinanceQuery, IEnumerable<BmwFinanceDto>>>()
            {
                {
                    Order.First,
                    (request, response, query) =>
                    {
                        var vinNumber = !string.IsNullOrEmpty(request.VinNumber.GetValue())
                            ? request.VinNumber.GetValue()
                            : Factory.MineVinNumber(response);

                        var engineNumber = !string.IsNullOrEmpty(request.EngineNumber.GetValue())
                            ? request.EngineNumber.GetValue()
                            : Factory.MineEngineNumber(response);

                        var vinEngineNumber = new VinEngineIdDto(vinNumber, engineNumber).VinAndEngineNumber;
                        return !string.IsNullOrEmpty(vinEngineNumber)
                            ? query.GetWithVinEngineId(vinEngineNumber) : null;
                    }

                },

                {
                    Order.Second,
                    (request, response, query) =>
                        string.IsNullOrEmpty(request.LicenceNumber.GetValue()) ? null : query.GetWithLicenceNumber(request.LicenceNumber.GetValue())
                },
                {
                    Order.Third,
                    (request, response, query) =>
                        string.IsNullOrEmpty(request.AccountNumber.GetValue()) ? null : query.GetWithAccountNumber(request.AccountNumber.GetValue())
                }
            };
    }
}