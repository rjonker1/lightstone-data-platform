using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Scans;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequesPropertyInformation : IProvidePropertyInformationForRequest
    {
        public RequesPropertyInformation()
        {
            // "User_ID={0}&Province={1}1&Municipality={2}&DeedTown={3}&Erf={4}&Portion={5}&Sectional_Title=s{6}&Unit={7}&Suburb={8}&Street={9}&StreetNumber={10}&Owner_Name={11}&ID_CK={12}&Estate_Name={13}&FARM_NAME={14}&MaxRowsToReturn={15}&TrackingNumber={16}"

        }

      
        public int sr_id
        {
            get { return 1; }
        }

        public decimal prop_id
        {
            get { return 1; }
        }

        public decimal DEED_ID
        {
            get { return 1; }
        }
        public decimal PROPTYPE_ID
        {
            get { return 1; }
        }
        public decimal SS_ID
        {
            get { return 1; }
        }
        public decimal NAD_ID
        {
            get { return 1; }
        }
        public string property_type
        {
            get { return "property_type"; }
        }
        public string PROVINCE
        {
            get { return "property_type"; }
        }
        public string MUNICNAME
        {
            get { return "PROVINCE"; }
        }
        public string DEEDTOWN  {
            get { return "DEEDTOWN"; }
        }
        public string FARMNAME
        {
            get { return "FARMNAME"; }
        }
        public string SECTIONAL_TITLE
        {
            get { return "SECTIONAL_TITLE"; }
        }

        //TODO: implement the rest of the fields after puliching the package...
    }
}
