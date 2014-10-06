using System;
using System.Collections.Generic;
using System.Linq;
using LightstoneApp.Domain.MainModule.Entities.Resources;

namespace LightstoneApp.Domain.MainModule.Entities
{
    /// <summary>
    ///     BankAccount domain entity
    /// </summary>
    public partial class BankAccount
    {
        /// <summary>
        ///     Deduct money to this account
        /// </summary>
        /// <param name="amount">Amount of money to deduct</param>
        public void ChargeMoney(decimal amount)
        {
            //Amount to Charge must be greater than 0. --> Domain logic.
            if (amount <= 0)
                throw new ArgumentException(Messages.exception_InvalidArgument, "amount");

            //Account must not be locked, and balance must be greater than cero.
            if (!CanBeCharged(amount))
                throw new InvalidOperationException(Messages.exception_InvalidAccountToBeCharged);

            //Charge means deducting money to this account. --> Domain Logic
            Balance -= amount;
        }

        /// <summary>
        ///     Add money to this account
        /// </summary>
        /// <param name="amount">Amount of money to add</param>
        public void CreditMoney(decimal amount)
        {
            //Amount to Credit must be greater than 0. --> Domain logic.
            if (amount <= 0)
                throw new ArgumentException(Messages.exception_InvalidArgument, "amount");

            //Account must not be locked.
            if (Locked)
                throw new InvalidOperationException(Messages.exception_AccountIsLocked);

            //Credit means adding money to this account. --> Domain Logic
            Balance += amount;
        }


        /// <summary>
        ///     Calculate diference between received and sended transfers
        /// </summary>
        /// <returns>Amount</returns>
        public decimal TransferRate(DateTime @from, DateTime to)
        {
            IEnumerable<BankTransfer> resultFrom = from bt
                in BankTransfersFromThis
                where
                    bt.TransferDate >= @from && bt.TransferDate <= to
                select bt;

            IEnumerable<BankTransfer> resultTo = from bt
                in BankTransfersToThis
                where
                    bt.TransferDate >= @from && bt.TransferDate <= to
                select bt;

            return resultTo.Sum(bt => bt.Amount) - resultFrom.Sum(bt => bt.Amount);
        }

        /// <summary>
        ///     Check if this bank account is not locked and balance is greater than amount to be charged
        /// </summary>
        /// <param name="amount">Amount of money to charge</param>
        /// <returns>True if this bank account not is locked and balace is greater than <paramref name="amount" /></returns>
        public bool CanBeCharged(decimal amount)
        {
            return !Locked && Balance > amount;
        }
    }
}