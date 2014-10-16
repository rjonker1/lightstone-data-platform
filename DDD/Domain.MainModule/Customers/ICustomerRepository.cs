using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Customers
{
    /// <summary>
    ///     Contract for Customer Aggregate Root Repository
    /// </summary>
    public interface ICustomerRepository
        : IRepository<Customer>
    {
        /// <summary>
        ///     Find customers by customer specification and include customer picture association
        /// </summary>
        /// <param name="specification">Specification to satisfy</param>
        /// <returns>Selected customer that match specification</returns>
        Customer FindCustomer(ISpecification<Customer> specification);
    }
}