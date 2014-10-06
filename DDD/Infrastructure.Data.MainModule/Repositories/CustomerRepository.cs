using System;
using System.Globalization;
using System.Linq;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Domain.MainModule.Customers;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.MainModule.Resources;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;

namespace LightstoneApp.Infrastructure.Data.MainModule.Repositories
{
    /// <summary>
    ///     ICustomer repository implementation
    ///     <see cref="LightstoneApp.Domain.MainModule.Customers.ICustomerRepository" />
    /// </summary>
    public class CustomerRepository
        : Repository<Customer>, ICustomerRepository
    {
        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="traceManager">Trace manager dependency</param>
        /// <param name="unitOfWork">Specific unitOfWork for this repository</param>
        public CustomerRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
        }

        #endregion

        #region ICustomerRepository implementation

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.MainModule.Customers.ICustomerRepository" />
        /// </summary>
        /// <param name="specification">
        ///     <see cref="LightstoneApp.Domain.MainModule.Customers.ICustomerRepository" />
        /// </param>
        /// <returns>Customer that match <paramref name="specification" /></returns>
        public Customer FindCustomer(ISpecification<Customer> specification)
        {
            //validate specification
            if (specification == null)
                throw new ArgumentNullException("specification");

            var activeContext = UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Customers
                    .Include(c => c.CustomerPicture)
                    .Where(specification.SatisfiedBy())
                    .SingleOrDefault();
            }
            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                Messages.exception_InvalidStoreContext,
                GetType().Name));
        }

        #endregion
    }
}