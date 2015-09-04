using System;
using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Models
{
    public class BmwFinance : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM BmwFinance";

        public const string SelectWithAccountNumber = @"SELECT* FROM BmwFinance WHERE DealReference = @AccountNumber";
        public const string SelectWithVinNumber = @"SELECT* FROM BmwFinance WHERE Chassis = @VinNumber";
        public const string SelectWithLicenceNumber = @"SELECT* FROM BmwFinance WHERE RegNumber = @LicenceNumber";

        public BmwFinance()
        {

        }

        public BmwFinance(string financeHouse, decimal dealReference, DateTime startDate, DateTime expireDate, string chassis,
            string engine, string registrationNumber, string description, int registrationYear, int productCategory, string dealStatus)
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
        }


        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<BmwFinance>(SelectAll);
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
        public int ProductCategory { get; set; }
        public string DealStatus { get; set; }
    }
}