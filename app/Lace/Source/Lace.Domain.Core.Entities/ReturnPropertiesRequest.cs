using System;
using System.Runtime.Serialization;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class ReturnPropertiesRequest //: IProvidePropertyInformationForRequest
    {

        public ReturnPropertiesRequest()
        {
            
        }

        public ReturnPropertiesRequest(string userId, string province, string municipality, string deedTown, string erf,
            string sectionalTitle, string unit, string suburb, string street, string streetNumber, string ownerName,
            string idCk, string estateName, string farmName, int maxRowsToReturn, string trackingNumber)
        {
            TrackingNumber = trackingNumber;
            MaxRowsToReturn = maxRowsToReturn;
            FARM_NAME = farmName;
            Estate_Name = estateName;
            ID_CK = idCk;
            Owner_Name = ownerName;
            StreetNumber = streetNumber;
            Street = street;
            Suburb = suburb;
            Unit = unit;
            Sectional_Title = sectionalTitle;
            Erf = erf;
            DeedTown = deedTown;
            Municipality = municipality;
            Province = province;
            User_ID = userId;
        }

        [DataMember]
        public string User_ID { get; private set; }

        [DataMember]
        public string Province { get; private set; }

        [DataMember]
        public string Municipality { get; private set; }

        [DataMember]
        public string DeedTown { get; private set; }

        [DataMember]
        public string Erf { get; private set; }

        [DataMember]
        public string Portion { get; private set; }

        [DataMember]
        public string Sectional_Title { get; private set; }

        [DataMember]
        public string Unit { get; private set; }

        [DataMember]
        public string Suburb { get; private set; }

        [DataMember]
        public string Street { get; private set; }

        [DataMember]
        public string StreetNumber { get; private set; }

        [DataMember]
        public string Owner_Name { get; private set; }

        [DataMember]
        public string ID_CK { get; private set; }

        [DataMember]
        public string Estate_Name { get; private set; }

        [DataMember]
        public string FARM_NAME { get; private set; }

        [DataMember]
        public int MaxRowsToReturn { get; private set; }

        [DataMember]
        public string TrackingNumber { get; private set; }
    }
}