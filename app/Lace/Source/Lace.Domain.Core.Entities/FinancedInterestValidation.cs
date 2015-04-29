using System.Linq;

namespace Lace.Domain.Core.Entities
{
    public class FinancedInterestValidation
    {
        private static readonly string[] Banks =
        {
            "wesbank",
            "absa",
            "mfc/nedbank"
        };

        private readonly string _bankName;

        public bool FinancedInterestIsAvailable { get; private set; }
        public string FinancialInterestInvite { get; private set; }
       

        public FinancedInterestValidation(string bankName, bool financedInterestAvailble)
        {
            _bankName = bankName;
            FinancedInterestIsAvailable = financedInterestAvailble;
        }

        public void Check()
        {
            if (IsNoBankIsFoundCheck()) return;

            if (IsBankFoundButNotFinancedInterestAvailable()) return;

            if (IsFoundButBankNotAvailableCheck()) return;

            ThereIsFinancialInterest();
        }

        private bool IsFoundButBankNotAvailableCheck()
        {
            if (Banks.Any(b => b.Equals(_bankName))) return false;

            FinancialInterestInvite =
                string.Format("Financed Interest was found for {0} but is not available", _bankName);
            FinancedInterestIsAvailable = false;
            return true;
        }

        private bool IsBankFoundButNotFinancedInterestAvailable()
        {
            if (!Banks.Any(b => b.Equals(_bankName))) return false;

            if (FinancedInterestIsAvailable) return false;

            FinancialInterestInvite =
                "No account interest is available for this vehicle";
            FinancedInterestIsAvailable = false;
            return true;
        }

        private bool IsNoBankIsFoundCheck()
        {
            if (!string.IsNullOrEmpty(_bankName) && !"none found".Equals(_bankName)) return false;

            FinancialInterestInvite = "No financial interest is available";
            FinancedInterestIsAvailable = false;
            return true;
        }

        private void ThereIsFinancialInterest()
        {
            FinancialInterestInvite = "To request financial interest please click on the 'Request' button";
            FinancedInterestIsAvailable = true;
        }

    }
}
