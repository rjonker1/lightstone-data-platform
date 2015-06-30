using Lace.Domain.Core.Models;

namespace Lace.Domain.Core.Contracts
{
    public interface IBuildIvidResponse
    {
        void SetErrorFlag(bool check);

        void SetHasIssuesFlag(bool check);
        void SetHasNoRecordsFlag(bool check);

        void SetMake(IvidCodePair pair);

        void SetModel(IvidCodePair pair);

        void SetColor(IvidCodePair pair);

        void SetDriven(IvidCodePair pair);

        void SetCategory(IvidCodePair pair);

        void SetDescription(IvidCodePair pair);

        void SetEconomicSector(IvidCodePair pair);

        void SetLifeStatus(IvidCodePair pair);

        void SetSapMark(IvidCodePair pair);

        void BuildSpecificInformation();

        void SetCarFullName();
        void AddReportStatusMessage(string message);
    }
}
