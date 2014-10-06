﻿using System.Collections.Generic;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Application.MainModule.BankingManagement
{
    /// <summary>
    ///     Contract for application banking operations
    /// </summary>
    public interface IBankingManagementService
    {
        /// <summary>
        ///     Add new bank account
        /// </summary>
        /// <param name="bankAccount">Bank account to add</param>
        void AddBankAccount(BankAccount bankAccount);

        /// <summary>
        ///     Change BankAccount
        /// </summary>
        /// <param name="bankAccount">BankAccount with changes to modify</param>
        void ChangeBankAccount(BankAccount bankAccount);

        /// <summary>
        ///     Find paged bank accounts
        /// </summary>
        /// <param name="pageIndex">The page index</param>
        /// <param name="pageCount">The page count</param>
        /// <returns>A collection of BankAccount in specific page</returns>
        List<BankAccount> FindPagedBankAccounts(int pageIndex, int pageCount);

        /// <summary>
        ///     Find bank account by number
        /// </summary>
        /// <param name="bankAccountNumber">Bank account number specification</param>
        /// <returns>BankAccount with this number or null if not exists</returns>
        BankAccount FindBankAccountByNumber(string bankAccountNumber);

        /// <summary>
        ///     Find bank accounts by number and/or customer owner
        /// </summary>
        /// <param name="bankAccountNumber">Bank account number</param>
        /// <param name="customerName">Customer identifier</param>
        /// <returns>List of bank account that match criteria</returns>
        List<BankAccount> FindBankAccounts(string bankAccountNumber, string customerName);

        /// <summary>
        ///     Perform money transfer into two valid accounts
        /// </summary>
        /// <param name="fromAccountNumber">Origin account number for this transfer</param>
        /// <param name="toAccountNumber">Destination account number for this transfer</param>
        /// <param name="amount">Amount of money to transfer into accounts</param>
        void PerformTransfer(string fromAccountNumber, string toAccountNumber, decimal amount);

        /// <summary>
        ///     Return a collection of BankTransfer in a specific page
        /// </summary>
        /// <param name="pageIndex">Index of page</param>
        /// <param name="pageCount">Number of elements in each page</param>
        /// <returns>Collection of bank transfers</returns>
        List<BankTransfer> FindBankTransfers(int pageIndex, int pageCount);
    }
}