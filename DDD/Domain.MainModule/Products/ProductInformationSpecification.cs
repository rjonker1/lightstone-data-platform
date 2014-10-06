using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Products
{
    /// <summary>
    ///     Adhoc specification for finding values by
    ///     publisher and description information
    /// </summary>
    public class ProductInformationSpecification
        : Specification<Product>
    {
        #region Members

        private readonly string _Description = default(string);
        private readonly string _Publisher = default(String);

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this specification
        /// </summary>
        /// <param name="productPublisher">Publisher of product or null to not include this value in search process</param>
        /// <param name="productDescription">Product description or null to not inclide this value in search process</param>
        public ProductInformationSpecification(string productPublisher, string productDescription)
        {
            _Publisher = productPublisher;
            _Description = productDescription;
        }

        #endregion

        #region Specification overrides

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </returns>
        public override Expression<Func<Product, bool>> SatisfiedBy()
        {
            Specification<Product> beginSpec = new TrueSpecification<Product>();

            if (_Publisher != null)
                beginSpec &=
                    new DirectSpecification<Product>(p => p.Publisher != null && p.Publisher.Contains(_Publisher));

            if (_Description != null)
                beginSpec &=
                    new DirectSpecification<Product>(
                        p => p.ProductDescription != null && p.ProductDescription.Contains(_Description));

            return beginSpec.SatisfiedBy();
        }

        #endregion
    }
}