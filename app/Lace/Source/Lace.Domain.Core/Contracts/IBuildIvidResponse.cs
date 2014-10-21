﻿using Lace.Domain.Core.Dto;

namespace Lace.Domain.Core.Contracts
{
    public interface IBuildIvidResponse
    {
        void Build(string statusMessage, string reference, string license, string registration, string registrationDate, string vin, string engine,
            string displacement, string tare);

        void SetErrorFlag(bool check);

        void SetHasIssuesFlag(bool check);

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
    }
}