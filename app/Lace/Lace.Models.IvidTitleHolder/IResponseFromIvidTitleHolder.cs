using System;
using Lace.Models.Enums;

namespace Lace.Models.IvidTitleHolder
{
    public interface IResponseFromIvidTitleHolder
    {
        string BankName { get; }
        string AccountNumber { get; }
        DateTime? DateOpened { get; }


        string FinancialInterestsHeading { get; }


        string AccountOpenDate { get;  }
         string AccountClosedDate { get; }
         string AgreementType { get;  }
         string YearOfLiabilityForLicensing { get; }
         string RequestFinancialInterestInvite { get; }
         bool FinancialInterestAvailable { get;  }


         bool PartialResponse { get; }
         bool HasErrors { get; }
        // ServiceCallState ServiceProviderCallState { get;  }
         string ExpiredMessage { get; }
    }
}
