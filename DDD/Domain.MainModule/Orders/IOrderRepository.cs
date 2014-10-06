using System.Collections.Generic;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Orders
{
    /// <summary>
    ///     Contract for Order Aggregate Root Repository
    /// </summary>
    public interface IOrderRepository
        : IRepository<Order>
    {
        /// <summary>
        ///     Find orders by customer code
        /// </summary>
        /// <param name="customerCode">A Customer code </param>
        /// <returns>Collection of order that matching criteria</returns>
        IEnumerable<Order> FindOrdersByCustomerCode(string customerCode);
    }
}