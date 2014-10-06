using System.Collections.Generic;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.BankAccounts
{
    /// <summary>
    ///     Contract for bank account aggregate root repository
    /// </summary>
    public interface IBankAccountRepository
        : IRepository<BankAccount>
    {
        /// <summary>
        ///     Find all bank accounts in page with bank transfer information
        /// </summary>
        /// <returns>A collection of bank account with transfer information</returns>
        IEnumerable<BankAccount> FindPagedBankAccountsWithTransferInformation(int pageIndex, int pageCount);
    }
}