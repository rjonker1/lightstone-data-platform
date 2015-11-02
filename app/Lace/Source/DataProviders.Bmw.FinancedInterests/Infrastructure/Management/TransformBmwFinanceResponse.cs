using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Management
{
    public class TransformBmwFinanceResponse : ITransform
    {
        private readonly IEnumerable<BmwFinanceDto> _response;

        public TransformBmwFinanceResponse(IList<BmwFinanceDto> response)
        {
            Continue = response != null && response.Any();
            Result = Continue ? null : BmwFinanceResponse.Empty();
            _response = Continue ? response : Enumerable.Empty<BmwFinanceDto>();
        }

        public void Transform()
        {
            var financeRecords =
                _response.Select(
                    s =>
                        new BmwFinanceRecord(s.FinanceHouse, s.DealReference, s.StartDate, s.ExpireDate, s.Chassis, s.Engine, s.RegistrationNumber,
                            s.Description, s.RegistrationYear, s.ProductCategory, s.DealStatus,s.ClientNumber));

            Result = new BmwFinanceResponse(financeRecords);
            Result.AddResponseState(State());
        }

        private DataProviderResponseState State()
        {
            return Result != null && Result.Finances.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords;
        }

        public bool Continue { get; private set; }
        public IProvideDataFromBmwFinance Result { get; private set; }
    }
}
