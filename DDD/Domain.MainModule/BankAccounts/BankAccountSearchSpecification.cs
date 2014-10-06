using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.BankAccounts
{
    /// <summary>
    ///     Search specification for bankAccounts
    /// </summary>
    public class BankAccountSearchSpecification
        : Specification<BankAccount>
    {
        #region Members

        private readonly string _BankAccountNumber;
        private readonly string _CustomerName;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this specification
        /// </summary>
        /// <param name="bankAccountNumber">BankAccount number</param>
        /// <param name="customerName">A Customer identifier</param>
        public BankAccountSearchSpecification(string bankAccountNumber, string customerName)
        {
            _CustomerName = customerName;
            _BankAccountNumber = bankAccountNumber;
        }

        #endregion

        #region Override Specification

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{BankAccount}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.Specification.Specification{BankAccount}" />
        /// </returns>
        public override Expression<Func<BankAccount, bool>> SatisfiedBy()
        {
            Specification<BankAccount> spec = new TrueSpecification<BankAccount>();

            if (!String.IsNullOrEmpty(_BankAccountNumber)
                &&
                !String.IsNullOrWhiteSpace(_BankAccountNumber))
            {
                spec &= new BankAccountNumberSpecification(_BankAccountNumber);
            }
            if (!String.IsNullOrEmpty(_CustomerName)
                &&
                !String.IsNullOrWhiteSpace(_CustomerName))
            {
                spec &=
                    new DirectSpecification<BankAccount>(
                        ba => ba.Customer.ContactName.ToLower().Contains(_CustomerName.ToLower()));
            }

            return spec.SatisfiedBy();
        }

        #endregion
    }
}