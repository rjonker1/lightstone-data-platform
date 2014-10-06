using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LightstoneApp.Domain.MainModule.BankAccounts;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.MainModule.Resources;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;

namespace LightstoneApp.Infrastructure.Data.MainModule.Repositories
{
    /// <summary>
    ///     IBankAccountRepository implementation
    ///     For more information <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankAccountRepository" />
    /// </summary>
    public class BankAccountRepository
        : Repository<BankAccount>, IBankAccountRepository
    {
        #region Constructor

        /// <summary>
        ///     Default constructor for this repository
        /// </summary>
        /// <param name="traceManager">ITraceManager dependency, intented to be resolved with IoC</param>
        /// <param name="unitOfWork">IMainModuleUnitOfWork dependency, intented to be resolved with IoC</param>
        public BankAccountRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
        }

        #endregion

        #region IBankAccountRepository implementation

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankAccountRepository" />
        /// </summary>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankAccountRepository" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankAccountRepository" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.MainModule.BankAccounts.IBankAccountRepository" />
        /// </returns>
        public IEnumerable<BankAccount> FindPagedBankAccountsWithTransferInformation(int pageIndex, int pageCount)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");

            var context = UnitOfWork as IMainModuleUnitOfWork;

            if (context != null)
            {
                return (from ba
                    in context.BankAccounts.Include(ba => ba.BankTransfersFromThis)
                    orderby ba.BankAccountNumber
                    select ba).AsEnumerable();
            }
            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                Messages.exception_InvalidStoreContext,
                GetType().Name));
        }

        #endregion
    }
}