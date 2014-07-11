using Lace.Models.Ivid.Dto;

namespace Lace.Models.Ivid
{
    public interface IResponseFromIvid
    {
        //void Build(string statusMessage, string reference, string license, string registration, string registrationDate, string vin, string engine,
        //    string displacement, string tare, string carFullName);

        //void SetErrorFlag(bool check);

        //void SetHasIssuesFlag(bool check);

        //void SetMake(IvidCodePair pair);

        //void SetModel(IvidCodePair pair);

        //void SetColor(IvidCodePair pair);

        //void SetDriven(IvidCodePair pair);

        //void SetCategory(IvidCodePair pair);

        //void SetDescription(IvidCodePair pair);

        //void SetEconomicSector(IvidCodePair pair);

        //void SetLifeStatus(IvidCodePair pair);

        //void SetSapMark(IvidCodePair pair);

        //void BuildSpecificInformation();

        VehicleSpecificInformation SpecificInformation { get; }

        string StatusMessage { get; }

        string Reference { get; }

        string License { get; }

        string Registration { get; }

        string RegistrationDate { get; }

        string Vin { get; }

        string Engine { get; }

        string Displacement { get; }

        string Tare { get; }

        string MakeCode { get; }

        string MakeDescription { get; }

        string ModelCode { get; }

        string ModelDescription { get; }

        string ColourCode { get; }

        string ColourDescription { get; }

        string DrivenCode { get; }

        string DrivenDescription { get; }

        string CategoryCode { get; }

        string CategoryDescription { get; }

        string DescriptionCode { get; }

        string Description { get; }

        string EconomicSectorCode { get; }

        string EconomicSectorDescription { get; }

        string LifeStatusCode { get; }

        string LifeStatusDescription { get; }

        string SapMarkCode { get; }

        string SapMarkDescription { get; }

        bool HasIssues { get; }

        bool HasErrors { get; }

        string CarFullname { get; }

      //  ServiceCallState ServiceProviderCallState { get; }
    }
}
