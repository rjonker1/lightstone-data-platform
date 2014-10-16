using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Orders
{
    /// <summary>
    ///     AdHoc specification for finding
    ///     orders for specific customers
    ///     in a range of date
    /// </summary>
    public class OrderFromCustomerDateRangeSpecification
        : Specification<Order>
    {
        #region Members

        private readonly int _CustomerId = default(Int32);
        private readonly DateTime? _FromDate;
        private readonly DateTime? _ToDate;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this specification
        /// </summary>
        /// <param name="customerId">A customer identifier</param>
        /// <param name="from">Orders from this date</param>
        /// <param name="to">Orders to this date</param>
        public OrderFromCustomerDateRangeSpecification(int customerId, DateTime? from, DateTime? to)
        {
            _CustomerId = customerId;
            _FromDate = from;
            _ToDate = to;
        }

        #endregion

        #region Specification overrides

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </returns>
        public override Expression<Func<Order, bool>> SatisfiedBy()
        {
            Specification<Order> order = new OrderFromCustomerSpecification(_CustomerId) &&
                                         new OrderDateSpecification(_FromDate, _ToDate);

            return order.SatisfiedBy();
        }

        #endregion
    }
}