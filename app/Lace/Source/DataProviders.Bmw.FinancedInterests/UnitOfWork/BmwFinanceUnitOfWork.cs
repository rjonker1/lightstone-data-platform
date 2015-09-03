using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Bmw.Finance.UnitOfWork
{
    public interface IGetBmwFinance
    {
        // IEnumerable<BmwFinance> Finances { get; }
        IEnumerable<BmwFinance> GetWithAccountNumber(string accountNumber);
        IEnumerable<BmwFinance> GetWithVinNumber(string vinNumber);
        IEnumerable<BmwFinance> GetWithLicenceNumber(string licenseNumber);
    }

    public class BmwFinanceUnitOfWork : IGetBmwFinance
    {
        private readonly ILog Log = LogManager.GetLogger<BmwFinanceUnitOfWork>();
        private readonly IReadOnlyRepository _repository;

        private BmwFinanceUnitOfWork(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public static IEnumerable<BmwFinance> Get(IReadOnlyRepository repository, IAmBmwFinanceRequest request)
        {
            var worker = new BmwFinanceUnitOfWork(repository);

            var value = request.LicenceNumber.GetValue();
            if (!string.IsNullOrEmpty(value))
                return Methods[typeof (IAmLicenceNumberRequestField)](value, worker);

            value = request.VinNumber.GetValue();
            if (!string.IsNullOrEmpty(value))
                return Methods[typeof (IAmVinNumberRequestField)](value, worker);

            return Methods[typeof (IAmAccountNumberRequestField)](value, worker);
        }

        private static readonly IDictionary<Type, Func<string, IGetBmwFinance, IEnumerable<BmwFinance>>> Methods = new Dictionary<Type, Func<string, IGetBmwFinance, IEnumerable<BmwFinance>>>()
        {
            { typeof(IAmLicenceNumberRequestField), (parameter, unit) => unit.GetWithLicenceNumber(parameter) },
            { typeof(IAmVinNumberRequestField), (parameter, unit) => unit.GetWithVinNumber(parameter) },
            { typeof(IAmAccountNumberRequestField), (parameter, unit) => unit.GetWithAccountNumber(parameter) }
        };

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
