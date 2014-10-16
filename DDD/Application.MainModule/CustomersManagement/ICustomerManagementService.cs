using System.Collections.Generic;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Application.MainModule.CustomersManagement
{
    /// <summary>
    ///     Base contract for Application Customers operations
    /// </summary>
    public interface ICustomerManagementService
    {
        /// <summary>
        ///     Add new customer
        /// </summary>
        /// <param name="customer">Customer to add</param>
        void AddCustomer(Customer customer);

        /// <summary>
        ///     Modify existing customer
        /// </summary>
        /// <param name="customer">Customer with changes to modify</param>
        void ChangeCustomer(Customer customer);

        /// <summary>
        ///     Remove exiting customer
        /// </summary>
        /// <param name="customer">Customer code especification</param>
        void RemoveCustomer(Customer customer);

        /// <summary>
        ///     Find customer by CustomerCode property value
        /// </summary>
        /// <param name="customerCode">Customer code specificaiton</param>
        /// <returns>
        ///     Customer if exist or null if not exist Customer with CustomerCode value equals to
        ///     <paramref name="customerCode" />
        /// </returns>
        Customer FindCustomerByCode(string customerCode);

        /// <summary>
        ///     Find customers in paged mode
        /// </summary>
        /// <param name="pageIndex">Index of page</param>
        /// <param name="pageCount">Number of elements in each page</param>
        /// <returns>A collection of customers</returns>
        List<Customer> FindPagedCustomers(int pageIndex, int pageCount);

        /// <summary>
        ///     Find all countries with name match with <paramref name="countryName" />
        /// </summary>
        /// <param name="countryName">A country name that result match</param>
        /// <returns>A collection of Country type</returns>
        List<Country> FindCountriesByName(string countryName);

        /// <summary>
        ///     Find all countries in paged mode
        /// </summary>
        /// <param name="pageIndex">A page index</param>
        /// <param name="pageCount">Number of elements in each page</param>
        /// <returns>A collection of Country</returns>
        List<Country> FindPagedCountries(int pageIndex, int pageCount);
    }
}