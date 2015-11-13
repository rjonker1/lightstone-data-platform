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

        public BmwFinanceRecord(string financeHouse, string dealReference, DateTime startDate, DateTime expireDate, string chassis,
            string engine, string registrationNumber, string description, int registrationYear, string productCategory, string dealStatus,
            string clientNumber, string accountNumberReference)
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
            AccountNumberReference = accountNumberReference;
        }

        [DataMember]
        public string FinanceHouse { get; private set; }

        [DataMember]
        public string DealReference { get; private set; }

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
        public string ProductCategory { get; private set; }

        [DataMember]
        public string DealStatus { get; private set; }

        [DataMember]
        public string ClientNumber { get; private set; }
        [DataMember]
        public string AccountNumberReference { get; private set; }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }
}