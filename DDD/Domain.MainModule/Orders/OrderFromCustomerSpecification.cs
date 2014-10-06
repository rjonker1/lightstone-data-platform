using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Orders
{
    /// <summary>
    ///     Adhoc specification for finding orders
    ///     by customer identifier
    /// </summary>
    public class OrderFromCustomerSpecification
        : Specification<Order>
    {
        #region Members

        private readonly int _CustomerId = default(Int32);

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        public OrderFromCustomerSpecification(int customerId)
        {
            _CustomerId = customerId;
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
            Specification<Order> spec = new TrueSpecification<Order>();

            spec &= new DirectSpecification<Order>(order => order.CustomerId == _CustomerId);

            return spec.SatisfiedBy();
        }

        #endregion
    }
}