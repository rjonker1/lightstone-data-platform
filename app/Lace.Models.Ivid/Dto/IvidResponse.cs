using System.Collections.Generic;
using Lace.Models.Ivid.Enums;

namespace Lace.Models.Ivid.Dto
{
    public class IvidResponse
    {
        //public List<VehicleSpecificInformation> SpecificInformation
        //{
        //    get;
        //    set;
        //}

        public VehicleSpecificInformation SpecificInformation
        {
            get;
            set;
        }
       
        public string StatusMessage
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }

        public string License
        {
            get;
            set;
        }

       
        public string Registration
        {
            get;
            set;
        }

      
        public string RegistrationDate
        {
            get;
            set;
        }

      
        public string Vin
        {
            get;
            set;
        }

      
        public string Engine
        {
            get;
            set;
        }

      
        public string Displacement
        {
            get;
            set;
        }

       
        public string Tare
        {
            get;
            set;
        }

        public string MakeCode
        {
            get;
            set;
        }

   
        public string MakeDescription
        {
            get;
            set;
        }

        
        public string ModelCode
        {
            get;
            set;
        }

      
        public string ModelDescription
        {
            get;
            set;
        }

      
        public string ColourCode
        {
            get;
            set;
        }

      
        public string ColourDescription
        {
            get;
            set;
        }

      
        public string DrivenCode
        {
            get;
            set;
        }

      
        public string DrivenDescription
        {
            get;
            set;
        }

       
        public string CategoryCode
        {
            get;
            set;
        }

       
        public string CategoryDescription
        {
            get;
            set;
        }

       
        public string DescriptionCode
        {
            get;
            set;
        }

       
        public string Description
        {
            get;
            set;
        }

       
        public string EconomicSectorCode
        {
            get;
            set;
        }

     
        public string EconomicSectorDescription
        {
            get;
            set;
        }

       
        public string LifeStatusCode
        {
            get;
            set;
        }

       
        public string LifeStatusDescription
        {
            get;
            set;
        }

        public string SapMarkCode
        {
            get;
            set;
        }

       
        public string SapMarkDescription
        {
            get;
            set;
        }

     
        public bool HasIssues
        {
            get;
            set;
        }

       
        public bool HasErrors { get; set; }

       
        public string CarFullname
        {
            get;
            set;
        }

       
        public ServiceCallState ServiceProviderCallState { get; set; }
    }
}
