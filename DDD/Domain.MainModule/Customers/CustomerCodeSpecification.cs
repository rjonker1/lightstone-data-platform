using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Customers
{
    /// <summary>
    ///     AdHoc specification for find customres by code criteria
    ///     For more information about specification
    ///     <see cref=" LightstoneApp.Domain.Core.Specification.ISpecification{TEntity}" />
    /// </summary>
    public class CustomerCodeSpecification
        : Specification<Customer>
    {
        #region Members

        private readonly string _CustomerCode;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="customerCode">A Customer code detail</param>
        public CustomerCodeSpecification(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode)
                ||
                string.IsNullOrWhiteSpace(customerCode)
                )
            {
                throw new ArgumentNullException("customerCode");
            }

            _CustomerCode = customerCode;
        }

        #endregion

        #region Specification overrides

        /// <summary>
        ///     <see cref=" LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref=" LightstoneApp.Domain.Core.Specification.Specification{TEntity}" />
        /// </returns>
        public override Expression<Func<Customer, bool>> SatisfiedBy()
        {
            Specification<Customer> spec = new TrueSpecification<Customer>();

            //only enabled customers
            spec &= new DirectSpecification<Customer>(t => t.IsEnabled);

            //customer code spec
            spec &=
                new DirectSpecification<Customer>(
                    c => c.CustomerCode != null && (c.CustomerCode.ToUpper() == _CustomerCode.ToUpper()));

            return spec.SatisfiedBy();
        }

        #endregion
    }
}