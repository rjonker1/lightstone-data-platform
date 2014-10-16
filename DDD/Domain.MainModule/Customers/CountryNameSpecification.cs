using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Customers
{
    /// <summary>
    ///     Spec for get countries by country name
    /// </summary>
    public class CountryNameSpecification
        : Specification<Country>
    {
        #region Members

        private readonly string _countryName = default(String);

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="countryName">Country name that result match</param>
        public CountryNameSpecification(string countryName)
        {
            _countryName = countryName;
        }

        #endregion

        #region Specification<Country> Members

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{Country}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{Country}" />
        /// </returns>
        public override Expression<Func<Country, bool>> SatisfiedBy()
        {
            Specification<Country> spec = new TrueSpecification<Country>();

            if (!String.IsNullOrEmpty(_countryName)
                &&
                !String.IsNullOrWhiteSpace(_countryName))
            {
                //construct expression and ad new condition to this specification
                Expression<Func<Country, bool>> expression =
                    country => country.CountryName.ToLower() == _countryName.ToLower();

                spec &= new DirectSpecification<Country>(expression);
            }


            return spec.SatisfiedBy();
        }

        #endregion
    }
}