using Lace.Models.Enums;
using Lace.Models.Ivid.Dto;

namespace Lace.Models.Ivid
{
    public interface IResponseFromIvid
    {
        VehicleSpecificInformation SpecificInformation
        {
            get;
            set;
        }

        string StatusMessage
        {
            get;
            set;
        }

        string Reference
        {
            get;
            set;
        }

        string License
        {
            get;
            set;
        }


        string Registration
        {
            get;
            set;
        }


        string RegistrationDate
        {
            get;
            set;
        }


        string Vin
        {
            get;
            set;
        }


        string Engine
        {
            get;
            set;
        }


        string Displacement
        {
            get;
            set;
        }


        string Tare
        {
            get;
            set;
        }

        string MakeCode
        {
            get;
            set;
        }


        string MakeDescription
        {
            get;
            set;
        }


        string ModelCode
        {
            get;
            set;
        }


        string ModelDescription
        {
            get;
            set;
        }


        string ColourCode
        {
            get;
            set;
        }


        string ColourDescription
        {
            get;
            set;
        }


        string DrivenCode
        {
            get;
            set;
        }


        string DrivenDescription
        {
            get;
            set;
        }


        string CategoryCode
        {
            get;
            set;
        }


        string CategoryDescription
        {
            get;
            set;
        }


        string DescriptionCode
        {
            get;
            set;
        }


        string Description
        {
            get;
            set;
        }


        string EconomicSectorCode
        {
            get;
            set;
        }


        string EconomicSectorDescription
        {
            get;
            set;
        }


        string LifeStatusCode
        {
            get;
            set;
        }


        string LifeStatusDescription
        {
            get;
            set;
        }

        string SapMarkCode
        {
            get;
            set;
        }


        string SapMarkDescription
        {
            get;
            set;
        }


        bool HasIssues
        {
            get;
            set;
        }


        bool HasErrors { get; set; }


        string CarFullname
        {
            get;
            set;
        }

        ServiceCallState ServiceProviderCallState { get; set; }
    }
}
