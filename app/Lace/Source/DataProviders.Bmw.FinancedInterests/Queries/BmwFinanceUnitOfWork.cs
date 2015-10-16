using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Bmw.Finance.Queries
{
    public interface IBmwFinanceQuery
    {
        // IEnumerable<BmwFinanceDto> Finances { get; }
        IEnumerable<BmwFinanceDto> GetWithAccountNumber(string accountNumber);
        IEnumerable<BmwFinanceDto> GetWithVinNumber(string vinNumber);
        IEnumerable<BmwFinanceDto> GetWithLicenceNumber(string licenseNumber);
    }

    public class BmwFinanceQuery : IBmwFinanceQuery
    {
        private static readonly ILog Log = LogManager.GetLogger<BmwFinanceQuery>();
        private readonly IReadOnlyRepository _repository;

        public BmwFinanceQuery(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BmwFinanceDto> GetWithAccountNumber(string accountNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinanceDto>(finance => finance.DealReference == decimal.Parse(accountNumber)).ToList();
                return !finances.Any()
                    ? _repository.Get<BmwFinanceDto>(BmwFinanceDto.SelectWithAccountNumber, new {@AccountNumber = accountNumber})
                    : finances;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting BWM Finance data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<BmwFinanceDto> GetWithVinNumber(string vinNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinanceDto>(finance => finance.Chassis == vinNumber).ToList();

                return !finances.Any() ? _repository.Get<BmwFinanceDto>(BmwFinanceDto.SelectWithVinNumber, new {@VinNumber = vinNumber}) : finances;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting BWM Finance data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<BmwFinanceDto> GetWithLicenceNumber(string licenseNumber)
        {
            try
            {
                var finances =
                    _repository.GetAll<BmwFinanceDto>(finance => finance.RegistrationNumber == licenseNumber).ToList();

                return !finances.Any()
                    ? _repository.Get<BmwFinanceDto>(BmwFinanceDto.SelectWithLicenceNumber, new {@LicenceNumber = licenseNumber})
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
