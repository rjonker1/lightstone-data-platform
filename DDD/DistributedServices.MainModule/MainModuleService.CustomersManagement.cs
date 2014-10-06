using System;
using System.Collections.Generic;
using System.ServiceModel;
using LightstoneApp.Application.MainModule.CustomersManagement;
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
        /// <param name="customerCode">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public Customer GetCustomerByCode(string customerCode)
        {
            try
            {
                var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

                return customerService.FindCustomerByCode(customerCode);
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
        /// <param name="customer">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void ChangeCustomer(Customer customer)
        {
            try
            {
                //Resolve root dependency and perform operation
                var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
                customerService.ChangeCustomer(customer);
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
        /// <param name="customer">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void RemoveCustomer(Customer customer)
        {
            try
            {
                var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
                customerService.RemoveCustomer(customer);
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
        /// <param name="customer">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        public void AddCustomer(Customer customer)
        {
            try
            {
                //Resolve root dependency and perform operation
                var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
                customerService.AddCustomer(customer);
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
        public List<Customer> GetPagedCustomer(PagedCriteria pagedCriteria)
        {
            try
            {
                //resolve root dependencies and perform query
                var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

                return customerService.FindPagedCustomers(pagedCriteria.PageIndex, pagedCriteria.PageCount);
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
        /// <param name="pagedCriteria">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Country> GetPagedCountries(PagedCriteria pagedCriteria)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var countryService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

                return countryService.FindPagedCountries(pagedCriteria.PageIndex, pagedCriteria.PageCount);
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
        }

        /// <summary>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </summary>
        /// <param name="countryName">
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.DistributedServices.MainModule.IMainModuleService" />
        /// </returns>
        public List<Country> GetCountriesByName(string countryName)
        {
            try
            {
                //Resolve root dependencies and perform operations
                var countryService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

                return countryService.FindCountriesByName(countryName);
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
        }
    }
}