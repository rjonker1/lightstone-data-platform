using System;

namespace Lace.Models.Audatex.Dto
{
    public class AccidentClaim
    {
        public Guid Key { get; set; }

        public DateTime? AccidentDate { get; set; }

        public string AssessmentNumber { get; set; }
       
        public string ClaimReferenceNumber { get; set; }
       
        public DateTime? CreationDate { get; set; }
       
        public string CreationDateString { get; set; }
       
        public string DataSource { get; set; }
       
        public string InsuredName { get; set; }

        public string Manufacturer { get; set; }
       
        public string Mileage { get; set; }
       
        public string Model { get; set; }
       
        public string Originator { get; set; }
       
        public string PolicyNumber { get; set; }
       
        public string Registration { get; set; }
       
        public decimal? RepairCostExVat { get; set; }
       
        public decimal? RepairCostIncVat { get; set; }
       
        public DateTime? VersionDate { get; set; }
       
        public string Vin { get; set; }
       
        public string WorkproviderReference { get; set; }
       
        public string MatchType { get; set; }
       
        public string QuoteValueIndicator { get; set; }
    }
}
