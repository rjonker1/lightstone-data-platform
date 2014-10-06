using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.BankAccounts
{
    /// <summary>
    ///     Contract for Domain Bank Transfer Service
    /// </summary>
    public interface IBankTransferDomainService
    {
        /// <summary>
        ///     Performs money transfer between two valid accounts
        /// </summary>
        /// <param name="originAccount">Origin account where money is charged</param>
        /// <param name="destinationAccount">Destination account where money is credited</param>
        /// <param name="amount">Amount to transfer between accounts</param>
        void PerformTransfer(BankAccount originAccount, BankAccount destinationAccount, decimal amount);
    }
}