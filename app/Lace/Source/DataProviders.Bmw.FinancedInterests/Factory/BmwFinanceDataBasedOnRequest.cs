using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Bmw.Finance.Queries;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Bmw.Finance.Factory
{
    public sealed class BmwFinanceDataBasedOnRequestFactory :
        AbstractBmwFinanceBasedOnRequestFactory<IBmwFinanceQuery, IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>>
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
                        string.IsNullOrEmpty(request.LicenceNumber.GetValue()) ? null : query.GetWithLicenceNumber(request.LicenceNumber.GetValue())
                },
                {
                    Order.Second,
                    (request, response, query) =>
                        string.IsNullOrEmpty(request.AccountNumber.GetValue()) ? null : query.GetWithAccountNumber(request.AccountNumber.GetValue())
                },
                {
                    Order.Third, (request, response, query) =>
                    {
                        var vinNumber = !string.IsNullOrEmpty(request.VinNumber.GetValue())
                            ? request.VinNumber.GetValue()
                            : Factory.MineVinNumber(response);
                        return string.IsNullOrEmpty(vinNumber) ? null : query.GetWithVinNumber(vinNumber);
                    }
                }
            };
    }

    public abstract class AbstractBmwFinanceBasedOnRequestFactory<T1, T2, T3> : IGetBmwFinanceData<T1, T2, T3>
    {
        public abstract IEnumerable<BmwFinanceDto> Get(T1 query, T2 request, T3 responseFactory);

        public IEnumerable<BmwFinanceDto> Get(object query, object request, object responseFactory)
        {
            return Get((T1)query, (T2)request, (T3)responseFactory);
        }
    }

}
