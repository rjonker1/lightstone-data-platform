using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Orders
{
    /// <summary>
    ///     AdHoc specification for finding orders
    ///     by shipping values
    /// </summary>
    public class OrderShippingSpecification
        : Specification<Order>
    {
        #region Members

        private readonly string _ShippingAddress = default(String);
        private readonly string _ShippingCity = default(String);
        private readonly string _ShippingName = default(String);
        private readonly string _ShippingZip = default(String);

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this specification
        /// </summary>
        /// <param name="shippingName">Shipping Name or null for not include this value in search</param>
        /// <param name="shippingAddress">Shipping Address or null for not include this vlaue in search</param>
        /// <param name="shippingCity">Shipping City or null for not include this value in search</param>
        /// <param name="shippingZip">Shipping Zip or null for not include this value in search</param>
        public OrderShippingSpecification(string shippingName, string shippingAddress, string shippingCity,
            string shippingZip)
        {
            _ShippingName = shippingName;
            _ShippingAddress = shippingAddress;
            _ShippingCity = shippingCity;
            _ShippingZip = shippingZip;
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
            Specification<Order> beginSpec = new TrueSpecification<Order>();

            if (_ShippingName != null)
                beginSpec &=
                    new DirectSpecification<Order>(o => o.ShippingName != null && o.ShippingName.Contains(_ShippingName));

            if (_ShippingAddress != null)
                beginSpec &=
                    new DirectSpecification<Order>(
                        o => o.ShippingAddress != null && o.ShippingAddress.Contains(_ShippingAddress));

            if (_ShippingCity != null)
                beginSpec &=
                    new DirectSpecification<Order>(o => o.ShippingCity != null && o.ShippingCity.Contains(_ShippingCity));

            if (_ShippingZip != null)
                beginSpec &=
                    new DirectSpecification<Order>(o => o.ShippingZip != null && o.ShippingZip.Contains(_ShippingZip));

            return beginSpec.SatisfiedBy();
        }

        #endregion
    }
}