using System;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Domain.MainModule.Resources;

namespace LightstoneApp.Domain.MainModule.BankAccounts
{
    /// <summary>
    ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankTransferDomainService" />
    /// </summary>
    public class BankTransferDomainService
        : IBankTransferDomainService
    {
        #region Constructor

        #endregion

        #region IBankTransferService Implementation

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankTransferDomainService" />
        /// </summary>
        /// <param name="originAccount">
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankTransferDomainService" />
        /// </param>
        /// <param name="destinationAccount">
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankTransferDomainService" />
        /// </param>
        /// <param name="amount">
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankTransferDomainService" />
        /// </param>
        public void PerformTransfer(BankAccount originAccount, BankAccount destinationAccount, decimal amount)
        {
            //Domain Logic
            //Process: Perform transfer operations to in-memory Domain-Model Objects        
            // 1.- Charge money to origin acc
            // 2.- Credit money to destination acc
            // 3.- Annotate transfer to origin account

            //Number Accounts must be different
            if (originAccount.BankAccountNumber != destinationAccount.BankAccountNumber)
            {
                //1. Charge to origin account (Domain Logic)
                originAccount.ChargeMoney(amount);

                //2. Credit to destination account (Domain Logic)
                destinationAccount.CreditMoney(amount);

                //3. Anotate transfer to related origin account                
                originAccount.BankTransfersFromThis.Add(new BankTransfer
                {
                    Amount = amount,
                    TransferDate = DateTime.UtcNow,
                    ToBankAccountId = destinationAccount.BankAccountId
                });
            }
            else
                throw new InvalidOperationException(Messages.exception_InvalidAccountsForTransfer);
        }

        #endregion
    }
}