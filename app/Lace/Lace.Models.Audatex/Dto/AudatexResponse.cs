using System.Collections.Generic;
using System.Linq;

namespace Lace.Models.Audatex.Dto
{
    public class AudatexResponse : IResponseFromAudatex
    {

        public AudatexResponse(IList<AccidentClaim> accidentClaims)
        {
            AccidentClaims = accidentClaims;
        }

        public IList<AccidentClaim> AccidentClaims { get; private set; }

        public bool HasAccidentClaims { get; private set; }

        public string QuoteValueIndicatorNote
        {
            get
            {
                return "* Indicates the repair quote band segment";
            }
        }

        public string LowConfidenceLevelIndicatorNote
        {
            get
            {
                return "! Indicates that we have a low confidence in the record returned";
            }
        }

        public string RegistrationNumberOnlyIndicatorNote
        {
            get
            {
                return "** This record is matched on Registration number only";
            }
        }

      //  public ServiceCallState ServiceProviderCallState { get; private set; }

        public void AddAccidentClaim(AccidentClaim claim)
        {
            if (AccidentClaims.Any(ac => ac.Equals(claim))) return;

            AccidentClaims.Add(claim);
        }


        public void CheckForAccidentClaims(bool check)
        {
            HasAccidentClaims |= check;
        }

        public void ResetAccidentClaimFlag()
        {
            HasAccidentClaims = false;
        }

        public void CleanAccidentClaims()
        {
            RemoveDuplicates();
            RemoveInvalidQuotes();
            RemoveDuplicateAssessments();
        }

        private void RemoveDuplicates()
        {
            if (AccidentClaims != null && AccidentClaims != null)
            {
                AccidentClaims = AccidentClaims.Distinct().ToList();
            }
        }

        private void RemoveDuplicateAssessments()
        {
            var duplicateAssessments = GroupByAssesmentNumber();
            if (duplicateAssessments == null || duplicateAssessments.Count == 0) return;

            // keep the first item, remove the others
            var itemsToRemove =
                duplicateAssessments.Where(ac => ac.Key != duplicateAssessments.FirstOrDefault().Key).ToList();
            AccidentClaims = AccidentClaims.Except(itemsToRemove).ToList();
        }


        private void RemoveInvalidQuotes()
        {
            var invalidDates = GroupByQuoteEstimateExVat();
            if (invalidDates != null && invalidDates.Count > 0)
            {
                AccidentClaims = AccidentClaims.Except(invalidDates).ToList();
            }
        }

        private List<AccidentClaim> GroupByQuoteEstimateExVat()
        {
            if (AccidentClaims == null) return null;

            return AccidentClaims
                .GroupBy(repairCost => repairCost.RepairCostExVat.Value,
                    accidentClaim => accidentClaim)
                .Where(
                    g =>
                        g.Any(
                            ac =>
                                ac.CreationDate.HasValue &&
                                (ac.CreationDate.Value.ToShortDateString() == "0001-01-01" ||
                                 ac.CreationDate.Value.ToShortDateString() == "0001/01/01")))
                .Where(g => g.Count() > 1)
                .SelectMany(a => a)
                .Where(
                    ac =>
                        ac.CreationDate.HasValue &&
                        (ac.CreationDate.Value.ToShortDateString() == "0001-01-01" ||
                         ac.CreationDate.Value.ToShortDateString() == "0001/01/01"))
                .ToList();
        }


        private List<AccidentClaim> GroupByAssesmentNumber()
        {

            if (AccidentClaims == null) return null;

            var r1 = AccidentClaims
                .GroupBy(assessment => assessment.AssessmentNumber,
                    accidentClaim => accidentClaim);
            var r2 =
                r1.Where(
                    g =>
                        g.Any(
                            ac =>
                                ac.CreationDate.HasValue &&
                                (ac.CreationDate.Value.ToShortDateString() != "0001-01-01" &&
                                 ac.CreationDate.Value.ToShortDateString() != "0001/01/01")) &&
                        g.Count() > 1);
            var r3 = r2.SelectMany(a => a)
                .Where(
                    ac =>
                        ac.CreationDate.HasValue &&
                        (ac.CreationDate.Value.ToShortDateString() != "0001-01-01" &&
                         ac.CreationDate.Value.ToShortDateString() != "0001/01/01"))
                .OrderByDescending(ac => ac.CreationDate)
                .ToList();
            return r3;
        }
    }
}
