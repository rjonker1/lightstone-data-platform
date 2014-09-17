using System;
using Lace.Models.Responses.Sources;

namespace Lace.Models.Audatex.Dto
{
    public class AccidentClaim : IAccidentClaim
    {

        public AccidentClaim(DateTime? accidentDate, string assessmentNumber, string claimReferenceNumber,
            DateTime? creationDate,
            string dataSource, string insuredName, string manufacturer, string mileage, string model, string orginator,
            string policyNumber, string registration,
            decimal? repairCostExVat, decimal? repairCostIncVat, DateTime? versionDate, string vin,
            string workProviderReference, string matchType,
            string quoteValueIndicator)
        {
          //  Key = key;
            AccidentDate = accidentDate;
            AssessmentNumber = assessmentNumber;
            ClaimReferenceNumber = claimReferenceNumber;
            CreationDate = creationDate;
            DataSource = dataSource;
            InsuredName = insuredName;
            Manufacturer = manufacturer;
            Mileage = mileage;
            Originator = orginator;
            Model = model;
            PolicyNumber = policyNumber;
            Registration = registration;
            RepairCostExVat = repairCostExVat;
            RepairCostIncVat = repairCostIncVat;
            VersionDate = versionDate;
            Vin = vin;
            WorkproviderReference = workProviderReference;
            MatchType = matchType;
            QuoteValueIndicator = quoteValueIndicator;
        }

        public Guid Key { get; private set; }

        public DateTime? AccidentDate { get; private set; }

        public string AssessmentNumber { get; private set; }

        public string ClaimReferenceNumber { get; private set; }

        public DateTime? CreationDate { get; private set; }

        public string CreationDateString
        {
            get
            {
               return GetCreationDateString(CreationDate);
            }
        }

        public string DataSource { get; private set; }

        public string InsuredName { get; private set; }

        public string Manufacturer { get; private set; }

        public string Mileage { get; private set; }

        public string Model { get; private set; }

        public string Originator { get; private set; }

        public string PolicyNumber { get; private set; }

        public string Registration { get; private set; }

        public decimal? RepairCostExVat { get; private set; }

        public decimal? RepairCostIncVat { get; private set; }

        public DateTime? VersionDate { get; private set; }

        public string Vin { get; private set; }

        public string WorkproviderReference { get; private set; }

        public string MatchType { get; private set; }

        public string QuoteValueIndicator { get; private set; }

    
        private static string GetCreationDateString(DateTime? creationDate)
        {
            var creationDateString = creationDate.HasValue &&
                                     (creationDate.Value.ToShortDateString() != "0001-01-01" &&
                                      creationDate.Value.ToShortDateString() != "0001/01/01")
                ? creationDate.Value.ToShortDateString()
                : "Date Not Available";

            return creationDateString;
        }
    }
}
