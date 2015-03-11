using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequesPropertyInformation : IProvidePropertyInformationForRequest
    {

        public RequesPropertyInformation()
        {
            UserId = "5a7222e1-ee65-433b-b673-827319e89cbb";
            //Province = "Province";
            //Municipality = "Municipality";
            //DeedTown = "DeedTown";
            //Erf = "Erf";
            //Portion = "Portion";
            //Sectional_Title = "Sectional_Title";
            //Suburb = "Suburb";
            //Street = "Street";
            //Owner_Name = "Owner_Name";
            IdCkOfOwner = "7902065199085";
            //Estate_Name = "Estate_Name";
            //FARM_NAME = "FARM_NAME";
            MaxRowsToReturn = 1000;
            TrackingNumber = Guid.NewGuid().ToString();
        }

        public string EstateName { get; private set; }

        public string FarmName { get; private set; }

        public string IdCkOfOwner { get; private set; }

        public string OwnerName { get; private set; }

        public string SectionalTitle { get; private set; }

        public string UserId { get; private set; }

        public string DeedTown { get; private set; }

        public string Erf { get; private set; }

        public int MaxRowsToReturn { get; private set; }

        public string Municipality { get; private set; }

        public string Portion { get; private set; }

        public string Province { get; private set; }

        public string Street { get; private set; }

        public string StreetNumber { get; private set; }

        public string Suburb { get; private set; }

        public string TrackingNumber { get; private set; }

        public string Unit { get; private set; }
    }
}
