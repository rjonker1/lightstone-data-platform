using System;

namespace Lace.Models.Audatex.Dto
{
    public class HistoryCheckResponse
    {
        public DateTime? AccidentDate { get; set; }

        public string AssessmentNumber { get; set; }

        public string ClaimReferenceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public string DataSource { get; set; }

        public string InsuredName { get; set; }

        public string Manufacturer { get; set; }

        public string Mileage { get; set; }

        public string Model { get; set; }

        public string Originator { get; set; }

        public string PolicyNumber { get; set; }

        public string Registration { get; set; }

        public decimal? RepairCostExVAT { get; set; }

        public decimal? RepairCostIncVAT { get; set; }

        public DateTime VersionDate { get; set; }

        public string VIN { get; set; }

        public string WorkproviderReference { get; set; }

        public string MatchType { get; set; }
    }
}
