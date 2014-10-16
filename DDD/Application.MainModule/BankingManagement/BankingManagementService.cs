using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LightstoneApp.Application.MainModule.Resources;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.MainModule.BankAccounts;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Application.MainModule.BankingManagement
{
    /// <summary>
    ///     IBankingManagementService implementation
    ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
    /// </summary>
    public class BankingManagementService
        : IBankingManagementService
    {
        #region Members

        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankTransferDomainService _bankTransferDomainService;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this service
        /// </summary>
        /// <param name="bankTransferDomainService">Bank transfer domain service dependency</param>
        /// <param name="bankAccountRepository">Bank account repository dependency</param>
        public BankingManagementService(IBankTransferDomainService bankTransferDomainService,
            IBankAccountRepository bankAccountRepository)
        {
            if (bankTransferDomainService == null)
                throw new ArgumentNullException("bankTransferDomainService",
                    Messages.exception_DependenciesAreNotInitialized);

            if (bankAccountRepository == null)
                throw new ArgumentNullException("bankAccountRepository",
                    Messages.exception_DependenciesAreNotInitialized);

            _bankTransferDomainService = bankTransferDomainService;
            _bankAccountRepository = bankAccountRepository;
        }

        #endregion

        #region IBankingManagementService Members

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="fromAccountNumber">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <param name="toAccountNumber">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <param name="amount">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        public void PerformTransfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            //Process: 1º Start Transaction
            //         2º Get Accounts objects from Repositories
            //         3º Call PerformTransfer method in Domain Service
            //         4º If no exceptions, save changes using repositories and Commit Transaction

            //Create a transaction context for this operation
            var txSettings = new TransactionOptions
            {
                Timeout = TransactionManager.DefaultTimeout,
                IsolationLevel = IsolationLevel.Serializable // review this option
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, txSettings))
            {
                //Get Unit of Work
                IUnitOfWork unitOfWork = _bankAccountRepository.UnitOfWork;

                //Create Queries' Specifications
                var originalAccountQuerySpec = new BankAccountNumberSpecification(fromAccountNumber);
                var destinationAccountQuerySpec = new BankAccountNumberSpecification(toAccountNumber);

                //Query Repositories to get accounts
                BankAccount originAccount = _bankAccountRepository.GetBySpec(originalAccountQuerySpec)
                    .SingleOrDefault();

                BankAccount destinationAccount = _bankAccountRepository.GetBySpec(destinationAccountQuerySpec)
                    .SingleOrDefault();

                if (originAccount == null || destinationAccount == null)
                    throw new InvalidOperationException(Messages.exception_InvalidAccountsForTransfer);

                ////Start tracking STE entities (Self Tracking Entities)
                originAccount.StartTrackingAll();
                destinationAccount.StartTrackingAll();

                //Excute Domain Logic for the Transfer (In Domain Service) 
                _bankTransferDomainService.PerformTransfer(originAccount, destinationAccount, amount);


                //Save changes and commit operations. 
                //This opeation is problematic with concurrency.
                //"balance" property in bankAccount is configured 
                //to FIXED in "WHERE concurrency checked predicates"

                _bankAccountRepository.Modify(originAccount);
                _bankAccountRepository.Modify(destinationAccount);

                //Complete changes in this Unit of Work
                unitOfWork.CommitAndRefreshChanges();

                //Commit the transaction
                scope.Complete();
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </returns>
        public List<BankTransfer> FindBankTransfers(int pageIndex, int pageCount)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");


            //Query BankAccount Repository to get Transfers related
            return _bankAccountRepository.FindPagedBankAccountsWithTransferInformation(pageIndex, pageCount)
                .SelectMany(ba => ba.BankTransfersFromThis)
                .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="bankAccount">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        public void AddBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
                throw new ArgumentNullException("bankAccount");

            IUnitOfWork unitOfWork = _bankAccountRepository.UnitOfWork;


            _bankAccountRepository.Add(bankAccount);

            //complete changes in this unit of work
            unitOfWork.Commit();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="bankAccount">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        public void ChangeBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
                throw new ArgumentNullException("bankAccount");

            IUnitOfWork unitOfWork = _bankAccountRepository.UnitOfWork;

            //charge in balance and commit operation. This opeation is 
            //problematic with concurrency. "balance" propety in bankAccount
            //is configured to FIXED in "WHERE concurrency checked predicates"

            _bankAccountRepository.Modify(bankAccount);

            //complete changes in this unit of work
            unitOfWork.CommitAndRefreshChanges();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="bankAccountNumber">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </returns>
        public BankAccount FindBankAccountByNumber(string bankAccountNumber)
        {
            var specification = new BankAccountNumberSpecification(bankAccountNumber);

            //query repository
            return _bankAccountRepository.GetBySpec(specification).SingleOrDefault();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </returns>
        public List<BankAccount> FindPagedBankAccounts(int pageIndex, int pageCount)
        {
            return _bankAccountRepository.GetPagedElements(pageIndex, pageCount, b => b.BankAccountNumber, true)
                .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </summary>
        /// <param name="bankAccountNumber">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <param name="customerName">
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.BankingManagement.IBankingManagementService" />
        /// </returns>
        public List<BankAccount> FindBankAccounts(string bankAccountNumber, string customerName)
        {
            var specification = new BankAccountSearchSpecification(bankAccountNumber, customerName);

            //query repository
            return _bankAccountRepository.GetBySpec(specification).ToList();
        }

        #endregion
    }
}