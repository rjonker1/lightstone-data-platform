using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.BankAccounts
{
    /// <summary>
    ///     AdHoc specification for finding BankAccounts for number criteria.
    ///     For more information about specification
    ///     <see cref="LightstoneApp.Domain.Core.Specification.ISpecification{TEntity}" />
    /// </summary>
    public class BankAccountNumberSpecification
        : Specification<BankAccount>
    {
        #region Members

        private readonly string _BankAccountNumber = default(String);

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="bankAccountNumber">Bank account number for this specification</param>
        public BankAccountNumberSpecification(string bankAccountNumber)
        {
            if (string.IsNullOrEmpty(bankAccountNumber)
                ||
                string.IsNullOrWhiteSpace(bankAccountNumber))
            {
                throw new ArgumentNullException("bankAccountNumber");
            }

            _BankAccountNumber = bankAccountNumber;
        }

        #endregion

        #region Specification

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{BankAccount}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{BankAccount}" />
        /// </returns>
        public override Expression<Func<BankAccount, bool>> SatisfiedBy()
        {
            return ba => ba.BankAccountNumber == _BankAccountNumber;
        }

        #endregion
    }
}