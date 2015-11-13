using System;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Dto
{
   // [Serializable]
    public class HistoryCheckResponse
    {

        public HistoryCheckResponse()
        {
            AccidentDate = DateTime.MinValue;
            AssessmentNumber = string.Empty;
            ClaimReferenceNumber = string.Empty;
            CreationDate = DateTime.MinValue;
            DataSource = string.Empty;
            InsuredName = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Originator = string.Empty;
            PolicyNumber = string.Empty;
            Mileage = string.Empty;
            Registration = string.Empty;
            RepairCostExVAT = null;
            RepairCostIncVAT = null;
            VersionDate = DateTime.MinValue;
            VIN = string.Empty;
            WorkproviderReference = string.Empty;
            MatchType = string.Empty;
        }

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
