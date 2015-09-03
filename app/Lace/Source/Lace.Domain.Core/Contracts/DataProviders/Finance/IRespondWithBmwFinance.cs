using System;

namespace Lace.Domain.Core.Contracts.DataProviders.Finance
{
    public interface IRespondWithBmwFinance
    {
        string FinanceHouse { get; }
        decimal DealReference { get; }
        DateTime StartDate { get; }
        DateTime ExpireDate { get; }
        string Chassis { get; }
        string Engine { get; }
        string RegistrationNumber { get; }
        string Description { get; }
        int RegistrationYear { get; }
        int ProductCategory { get; }
        string DealStatus { get; }
    }
}
