using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Management
{
    public class TransformBmwFinanceResponse : ITransform
    {
        private readonly IEnumerable<BmwFinance> _response;

        public TransformBmwFinanceResponse(IList<BmwFinance> response, ICauseCriticalFailure criticalFailure)
        {
            Continue = response != null && response.Any();
            Result = Continue ? null : criticalFailure.IsCritical() ? BmwFinanceResponse.Failure(criticalFailure.Message) : BmwFinanceResponse.Empty();
            _response = Continue ? response : Enumerable.Empty<BmwFinance>();
        }

        public void Transform()
        {
            var financeRecords =
                _response.Select(
                    s =>
                        new BmwFinanceRecord(s.FinanceHouse, s.DealReference, s.StartDate, s.ExpireDate, s.Chassis, s.Engine, s.RegistrationNumber,
                            s.Description, s.RegistrationYear, s.ProductCategory, s.DealStatus));

            Result = new BmwFinanceResponse(financeRecords);
        }

        public bool Continue { get; private set; }
        public IProvideDataFromBmwFinance Result { get; private set; }
    }
}
