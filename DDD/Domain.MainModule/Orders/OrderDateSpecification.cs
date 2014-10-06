using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Orders
{
    /// <summary>
    ///     Adhoc specification for finding order
    ///     by OrderDate values
    /// </summary>
    public class OrderDateSpecification
        : Specification<Order>
    {
        #region Members

        private DateTime? _FromDate;
        private DateTime? _ToDate;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for OrderDateSpecification
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        public OrderDateSpecification(DateTime? fromDate, DateTime? toDate)
        {
            _FromDate = fromDate;
            _ToDate = toDate;
        }

        #endregion

        #region Specification Overrides

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </returns>
        public override Expression<Func<Order, bool>> SatisfiedBy()
        {
            Specification<Order> spec = new TrueSpecification<Order>();

            if (_FromDate.HasValue)
                spec &= new DirectSpecification<Order>(o => o.OrderDate > (_FromDate ?? DateTime.MinValue));

            if (_ToDate.HasValue)
                spec &= new DirectSpecification<Order>(o => o.OrderDate < (_ToDate ?? DateTime.MaxValue));

            return spec.SatisfiedBy();
        }

        #endregion
    }
}