using System;
using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Dtos
{
    public class BmwFinanceDto : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Finances";

        public const string SelectWithAccountNumber = @"SELECT * FROM Finances WHERE DealReference = @AccountNumber";
        public const string SelectWithVinNumber = @"SELECT * FROM Finances WHERE Chassis = @VinNumber";
        public const string SelectWithLicenceNumber = @"SELECT* FROM Finances WHERE RegistrationNumber = @LicenceNumber";
        public const string SelectWithVinAndEngineId = @"SELECT * FROM Finances WHERE VinEngineId = @VinEngineId";

        public BmwFinanceDto()
        {

        }

        public BmwFinanceDto(string financeHouse, decimal dealReference, DateTime startDate, DateTime expireDate, string chassis,
            string engine, string registrationNumber, string description, int registrationYear, string productCategory, string dealStatus, string clientNumber)
        {
            FinanceHouse = financeHouse;
            DealReference = dealReference;
            StartDate = startDate;
            ExpireDate = expireDate;
            Chassis = chassis;
            Engine = engine;
            RegistrationNumber = registrationNumber;
            Description = description;
            RegistrationYear = registrationYear;
            ProductCategory = productCategory;
            DealStatus = dealStatus;
            ClientNumber = clientNumber;
        }


        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<BmwFinanceDto>(SelectAll);
        }

        public string FinanceHouse { get; set; }
        public decimal DealReference { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Chassis { get; set; }
        public string Engine { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
        public int RegistrationYear { get; set; }
        public string ProductCategory { get; set; }
        public string DealStatus { get; set; }
        public string ClientNumber { get; set; }
        public string VinEngineId { get; set; }
    }
}