using System.Collections.Generic;
using System.Linq;
using Lace.Models.Audatex;
using Lace.Models.Audatex.Dto;

namespace Lace.Source.Audatex.Transform
{
    public class AccidentClaimCleaner
    {
        public static void CleanAccidentClaims(IResponseFromAudatex result)
        {
            RemoveDuplicates(result);
            RemoveInvalidQuotes(result);
            RemoveDuplicateAssessments(result);
        }

        private static void RemoveDuplicates(IResponseFromAudatex result)
        {
            if (result != null && result.AccidentClaims != null)
            {
                result.AccidentClaims = result.AccidentClaims.Distinct().ToList();
            }
        }

        private static void RemoveDuplicateAssessments(IResponseFromAudatex result)
        {
            var duplicateAssessments = GroupByAssesmentNumber(result);
            if (duplicateAssessments == null || duplicateAssessments.Count == 0) return;

            // keep the first item, remove the others
            var itemsToRemove =
                duplicateAssessments.Where(ac => ac.Key != duplicateAssessments.FirstOrDefault().Key).ToList();
            result.AccidentClaims = result.AccidentClaims.Except(itemsToRemove).ToList();
        }

        private static void RemoveInvalidQuotes(IResponseFromAudatex result)
        {
            var invalidDates = GroupByQuoteEstimateExVat(result);
            if (invalidDates != null && invalidDates.Count > 0)
            {
                result.AccidentClaims = result.AccidentClaims.Except(invalidDates).ToList();
            }
        }

        private static List<AccidentClaim> GroupByQuoteEstimateExVat(IResponseFromAudatex result)
        {
            if (result.AccidentClaims == null) return null;

            return result.AccidentClaims
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

        private static List<AccidentClaim> GroupByAssesmentNumber(IResponseFromAudatex result)
        {

            if (result.AccidentClaims == null) return null;

            var r1 = result.AccidentClaims
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
