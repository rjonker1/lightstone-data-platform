using System;
using System.Collections.Generic;
using System.Linq;
using LightstoneApp.Application.MainModule.Resources;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Countries;
using LightstoneApp.Domain.MainModule.Customers;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Application.MainModule.CustomersManagement
{
    /// <summary>
    ///     ICustomerManagementService implementation
    ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
    /// </summary>
    public class CustomerManagementService
        : ICustomerManagementService
    {
        #region Members

        private readonly ICountryRepository _countryRepository;
        private readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create new instance
        /// </summary>
        /// <param name="customerRepository">Customer repository dependency, intented to be resolved with dependency injection</param>
        /// <param name="countryRepository">Country repository dependency, intended to be resolved with dependency injection</param>
        public CustomerManagementService(ICustomerRepository customerRepository, ICountryRepository countryRepository)
        {
            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            if (countryRepository == null)
                throw new ArgumentNullException("countryRepository");

            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
        }

        #endregion

        #region ICustomerManagementService Members

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="customer">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        public void AddCustomer(Customer customer)
        {
            //Begin unit of work ( if Transaction is required init here a new TransactionScope element
            IUnitOfWork unitOfWork = _customerRepository.UnitOfWork;


            _customerRepository.Add(customer);


            //Complete changes in this unit of work
            unitOfWork.Commit();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="customer">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        public void ChangeCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            IUnitOfWork unitOfWork = _customerRepository.UnitOfWork;

            _customerRepository.Modify(customer);

            unitOfWork.CommitAndRefreshChanges();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="customer">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        public void RemoveCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            //Begin unit of work ( if Transaction is required init here a new TransactionScope element
            IUnitOfWork unitOfWork = _customerRepository.UnitOfWork;


            //Set IsEnabled property to false, remove customer is only a logical operation 
            // cannot remove this item in  persistence store

            customer.IsEnabled = false;

            _customerRepository.Modify(customer);

            //Complete changes in this unit of work
            unitOfWork.CommitAndRefreshChanges();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="customerCode">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </returns>
        public Customer FindCustomerByCode(string customerCode)
        {
            //Create specification
            var spec = new CustomerCodeSpecification(customerCode);

            return _customerRepository.FindCustomer(spec);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </returns>
        public List<Customer> FindPagedCustomers(int pageIndex, int pageCount)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");


            //Create "enabled variable" transform adhoc execution plan in prepared plan
            //for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            bool enabled = true;
            Specification<Customer> onlyEnabledSpec = new DirectSpecification<Customer>(c => c.IsEnabled == enabled);

            return
                _customerRepository.GetPagedElements(pageIndex, pageCount, c => c.CustomerCode, onlyEnabledSpec, true)
                    .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="countryName">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </returns>
        public List<Country> FindCountriesByName(string countryName)
        {
            var spec = new CountryNameSpecification(countryName);

            return _countryRepository.GetBySpec(spec)
                .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </summary>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Application.MainModule.CustomersManagement.ICustomerManagementService" />
        /// </returns>
        public List<Country> FindPagedCountries(int pageIndex, int pageCount)
        {
            return _countryRepository.GetPagedElements(pageIndex, pageCount, c => c.CountryName, true)
                .ToList();
        }

        #endregion
    }
}