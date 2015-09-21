using System;
using System.Runtime.Serialization;

namespace Toolbox.Bmw.Dtos
{
    [DataContract]
    public class BmwFinanceDataDto
    {
        public BmwFinanceDataDto()
        {

        }

        public BmwFinanceDataDto(string chassis, string engine, string registrationNumber, string description, int registrationYear,
            string dealStatus, string financeHouse, string dealReference, DateTime startDate, DateTime expireDate, string productCategory)
        {
            Chassis = chassis;
            Engine = engine;
            RegistrationNumber = registrationNumber;
            Description = description;
            RegistrationYear = registrationYear;
            DealStatus = dealStatus;
          //  DealType = dealType;
            FinanceHouse = financeHouse;
            DealReference = dealReference;
            StartDate =  startDate;
            ExpireDate = expireDate;
            ProductCategory = productCategory;
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

        //[DataMember]
        //public string DealType { get; private set; }

        [DataMember]
        public string DealStatus { get; private set; }

        [DataMember]
        public string ProductCategory { get; set; }
    }
}
