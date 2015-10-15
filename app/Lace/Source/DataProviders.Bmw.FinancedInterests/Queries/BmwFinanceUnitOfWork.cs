using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Bmw.Finance.Queries
{
    public interface IBmwFinanceQuery
    {
        // IEnumerable<BmwFinance> Finances { get; }
        IEnumerable<BmwFinance> GetWithAccountNumber(string accountNumber);
        IEnumerable<BmwFinance> GetWithVinNumber(string vinNumber);
        IEnumerable<BmwFinance> GetWithLicenceNumber(string licenseNumber);
    }

    public class BmwFinanceQuery : IBmwFinanceQuery
    {
        private static readonly ILog Log = LogManager.GetLogger<BmwFinanceQuery>();
        private readonly IReadOnlyRepository _repository;

        public BmwFinanceQuery(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BmwFinance> GetWithAccountNumber(string accountNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinance>(finance => finance.DealReference == decimal.Parse(accountNumber)).ToList();
                return !finances.Any()
                    ? _repository.Get<BmwFinance>(BmwFinance.SelectWithAccountNumber, new {@AccountNumber = accountNumber})
                    : finances;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting BWM Finance data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<BmwFinance> GetWithVinNumber(string vinNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinance>(finance => finance.Chassis == vinNumber).ToList();

                return !finances.Any() ? _repository.Get<BmwFinance>(BmwFinance.SelectWithVinNumber, new {@VinNumber = vinNumber}) : finances;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting BWM Finance data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<BmwFinance> GetWithLicenceNumber(string licenseNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinance>(finance => finance.RegistrationNumber == licenseNumber).ToList();

                return !finances.Any()
                    ? _repository.Get<BmwFinance>(BmwFinance.SelectWithLicenceNumber, new {@LicenceNumber = licenseNumber})
                    : finances;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting BWM Finance data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
