using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Scans;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequesPropertyInformation : IProvidePropertyInformationForRequest
    {
        public RequesPropertyInformation()
        {
            
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
    }
}
