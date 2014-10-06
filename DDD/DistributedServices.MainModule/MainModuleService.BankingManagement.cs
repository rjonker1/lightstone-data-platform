using System;
using System.Collections.Generic;
using System.ServiceModel;
using LightstoneApp.Application.MainModule.BankingManagement;
using LightstoneApp.DistributedServices.Core.ErrorHandlers;
using LightstoneApp.DistributedServices.MainModule.DTO;
using LightstoneApp.DistributedServices.MainModule.Resources;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.IoC;
using LightstoneApp.Infrastructure.CrossCutting.Logging;

namespace LightstoneApp.DistributedServices.MainModule
{
    public partial class MainModuleService
    {
        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="pagedCriteria">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<BankAccount> GetPagedBankAccounts(PagedCriteria pagedCriteria)
        {
            try
            {
                //Resolve root dependency and perform operation

                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();

                List<BankAccount> bankAccounts = null;

                //perform work!
                bankAccounts = bankingManagement.FindPagedBankAccounts(pagedCriteria.PageIndex, pagedCriteria.PageCount);

                return bankAccounts;
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
            catch (NullReferenceException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="bankAccountInformation">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<BankAccount> GetBankAccounts(BankAccountInformation bankAccountInformation)
        {
            //Resolve root dependency and perform operation
            var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();

            List<BankAccount> bankAccounts = null;

            //perform work!
            bankAccounts = bankingManagement.FindBankAccounts(bankAccountInformation.BankAccountNumber,
                bankAccountInformation.CustomerName);

            return bankAccounts;
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="bankAccountNumber">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public BankAccount GetBankAccountByNumber(string bankAccountNumber)
        {
            try
            {
                //Resolve root dependency and perform operation
                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();
                BankAccount bankAccount = null;

                //perform work!

                bankAccount = bankingManagement.FindBankAccountByNumber(bankAccountNumber);

                return bankAccount;
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="bankAccount">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void ChangeBankAccount(BankAccount bankAccount)
        {
            try
            {
                //Resolve root dependency and perform operation
                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();
                bankingManagement.ChangeBankAccount(bankAccount);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="bankAccount">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void AddBankAccount(BankAccount bankAccount)
        {
            try
            {
                //Resolve root dependency and perform operation
                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();
                bankingManagement.AddBankAccount(bankAccount);
            }
            catch (ArgumentNullException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="pagedCriteria">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<BankTransfer> GetPagedTransfers(PagedCriteria pagedCriteria)
        {
            try
            {
                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();

                return bankingManagement.FindBankTransfers(pagedCriteria.PageIndex, pagedCriteria.PageCount);
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate bussines exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="transferInformation">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void PerformBankTransfer(TransferInformation transferInformation)
        {
            try
            {
                var bankingManagement = IoCFactory.Instance.CurrentContainer.Resolve<IBankingManagementService>();
                bankingManagement.PerformTransfer(transferInformation.OriginAccountNumber,
                    transferInformation.DestinationAccountNumber, transferInformation.Amount);
            }
            catch (InvalidOperationException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate bussines exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidBankAccountForTransfer
                };

                throw new FaultException<ServiceError>(detailedError);
            }
            catch (ArgumentException ex)
            {
                //trace data for internal health system and return specific FaultException here!
                //Log and throw is a knowed anti-pattern but in this point ( entry point for clients this is admited!)

                //log exception for manage health system
                var traceManager = IoCFactory.Instance.CurrentContainer.Resolve<ITraceManager>();
                traceManager.TraceError(ex.Message);

                //propagate bussines exception to client
                var detailedError = new ServiceError
                {
                    ErrorMessage = Messages.exception_InvalidArguments
                };

                throw new FaultException<ServiceError>(detailedError);
            }
        }
    }
}