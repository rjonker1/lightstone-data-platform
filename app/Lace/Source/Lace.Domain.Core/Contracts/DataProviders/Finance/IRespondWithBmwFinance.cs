using System;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Finance
{
    public interface IRespondWithBmwFinance : IProvideType
    {
        string FinanceHouse { get; }
        string DealReference { get; }
        DateTime StartDate { get; }
        DateTime ExpireDate { get; }
        string Chassis { get; }
        string Engine { get; }
        string RegistrationNumber { get; }
        string Description { get; }
        int RegistrationYear { get; }
        string ProductCategory { get; }
        string DealStatus { get; }
        string ClientNumber { get; }
        string AccountNumberReference { get; }
    }
}
