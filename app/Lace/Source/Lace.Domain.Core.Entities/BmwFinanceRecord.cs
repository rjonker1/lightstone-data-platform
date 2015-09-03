using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Finance;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class BmwFinanceRecord : IRespondWithBmwFinance
    {
        public BmwFinanceRecord()
        {
            
        }

        public BmwFinanceRecord(string financeHouse, decimal dealReference, DateTime startDate, DateTime expireDate, string chassis,
            string engine,string registrationNumber, string description, int registrationYear, int productCategory, string dealStatus)
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

        [DataMember]
        public string FinanceHouse { get; private set; }
        [DataMember]
        public decimal DealReference { get; private set; }
        [DataMember]
        public DateTime StartDate { get; private set; }
        [DataMember]
        public DateTime ExpireDate { get; private set; }
        [DataMember]
        public string Chassis { get; private set; }
        [DataMember]
        public string Engine { get; private set; }
        [DataMember]
        public string RegistrationNumber { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public int RegistrationYear { get; private set; }
        [DataMember]
        public int ProductCategory { get; private set; }
        [DataMember]
        public string DealStatus { get; private set; }
    }
}
