using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Bmw.Finance.UnitOfWork;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Bmw.Finance.Factory
{
    public sealed class BmwFinanceDataBasedOnRequestFactory :
        AbstractBmwFinanceBasedOnRequestFactory<IBmwFinanceUnitOfWork, IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>>
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();

        public override IEnumerable<BmwFinance> Get(IBmwFinanceUnitOfWork worker, IAmBmwFinanceRequest request,
            ICollection<IPointToLaceProvider> response)
        {
            var records = Enumerable.Empty<BmwFinance>();
            foreach (var fields in RequestFields.OrderBy(o => (int) o.Key))
            {
                records = fields.Value(request, response, worker);
                if (records != null)
                    break;
            }

            return records ?? Enumerable.Empty<BmwFinance>();
        }

        private static readonly
            IDictionary<Order, Func<IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>, IBmwFinanceUnitOfWork, IEnumerable<BmwFinance>>>
            RequestFields = new Dictionary
                <Order, Func<IAmBmwFinanceRequest, ICollection<IPointToLaceProvider>, IBmwFinanceUnitOfWork, IEnumerable<BmwFinance>>>()
            {
                {
                    Order.First,
                    (request, response, worker) =>
                        string.IsNullOrEmpty(request.LicenceNumber.GetValue()) ? null : worker.GetWithLicenceNumber(request.LicenceNumber.GetValue())
                },
                {
                    Order.Second,
                    (request, response, worker) =>
                        string.IsNullOrEmpty(request.AccountNumber.GetValue()) ? null : worker.GetWithAccountNumber(request.AccountNumber.GetValue())
                },
                {
                    Order.Third, (request, response, worker) =>
                    {
                        var vinNumber = !string.IsNullOrEmpty(request.VinNumber.GetValue())
                            ? request.VinNumber.GetValue()
                            : Factory.MineVinNumber(response);
                        return string.IsNullOrEmpty(vinNumber) ? null : worker.GetWithVinNumber(vinNumber);
                    }
                }
            };
    }

    public abstract class AbstractBmwFinanceBasedOnRequestFactory<T1, T2, T3> : IGetBmwFinanceData<T1, T2, T3>
    {
        public abstract IEnumerable<BmwFinance> Get(T1 worker, T2 request, T3 responseFactory);

        public IEnumerable<BmwFinance> Get(object worker, object request, object responseFactory)
        {
            return Get((T1)worker, (T2) request, (T3) responseFactory);
        }
    }

}
