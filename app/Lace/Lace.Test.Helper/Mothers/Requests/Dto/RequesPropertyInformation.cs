using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequesPropertyInformation : IProvidePropertyInformationForRequest
    {

        public RequesPropertyInformation()
        {
            User_ID = "5a7222e1-ee65-433b-b673-827319e89cbb";
            //Province = "Province";
            //Municipality = "Municipality";
            //DeedTown = "DeedTown";
            //Erf = "Erf";
            //Portion = "Portion";
            //Sectional_Title = "Sectional_Title";
            //Suburb = "Suburb";
            //Street = "Street";
            //Owner_Name = "Owner_Name";
            ID_CK = "7902065199085";
            //Estate_Name = "Estate_Name";
            //FARM_NAME = "FARM_NAME";
            MaxRowsToReturn = 1000;
            TrackingNumber = Guid.NewGuid().ToString();

        }

        public string User_ID { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string DeedTown { get; set; }
        public string Erf { get; set; }
        public string Portion { get; set; }
        public string Sectional_Title { get; set; }
        public string Unit { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string Owner_Name { get; set; }
        public string ID_CK { get; set; }
        public string Estate_Name { get; set; }
        public string FARM_NAME { get; set; }
        public int MaxRowsToReturn { get; set; }
        public string TrackingNumber { get; set; }
    }
}
