using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Domain.MainModule.Orders;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Infrastructure.Data.MainModule.Resources;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;

namespace LightstoneApp.Infrastructure.Data.MainModule.Repositories
{
    /// <summary>
    ///     IOrderRepository implementation
    ///     <see cref="LightstoneApp.Domain.MainModule.Orders.IOrderRepository" />
    /// </summary>
    public class OrderRepository
        : Repository<Order>, IOrderRepository
    {
        #region Constructor

        /// <summary>
        ///     Default constructor for this repository
        /// </summary>
        /// <param name="unitOfWork">unitOfWork dependency, intented to be resolved with IoC</param>
        /// <param name="traceManager">ITraceManager dependency, intended to be resolved wiht IoC</param>
        public OrderRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
        }

        #endregion

        #region IOrderRepository Implementation

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.MainModule.Orders.IOrderRepository" />
        /// </summary>
        /// <param name="customerCode">
        ///     <see cref="LightstoneApp.Domain.MainModule.Orders.IOrderRepository" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.MainModule.Orders.IOrderRepository" />
        /// </returns>
        public IEnumerable<Order> FindOrdersByCustomerCode(string customerCode)
        {
            if (String.IsNullOrEmpty(customerCode)
                ||
                String.IsNullOrWhiteSpace(customerCode)
                )
            {
                throw new ArgumentNullException("customerCode");
            }

            //
            // Other valid query for this case is base.GetFilteredElements(o => o.Customer.CustomerCode == customerCode);
            // In this case also you can use OrderFromCustomerSpecification but for sample purposed this method
            // is created using linq to entities implementation
            //

            var actualContext = base.UnitOfWork as IMainModuleUnitOfWork;
            if (actualContext != null)
            {
                return (from order
                    in actualContext.Orders
                    where
                        order.Customer.CustomerCode == customerCode
                    select
                        order).AsEnumerable();
            }
            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                Messages.exception_InvalidStoreContext,
                GetType().Name));
        }

        #endregion
    }
}