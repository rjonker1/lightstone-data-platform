using System;

namespace Lace.Request.Tests.Data
{
    public class LicensePlateNumberSliverAllServicesRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public int CompanyId { get; set; }

        public int ContractId { get; set; }

        public string ProductName { get; set; }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

       

        public string[] Sources
        {
            get
            {
                return new string[] { "Ivid", "IvidTitleHolder", "RgtVin", "Audatex" };
            }
        }


        public string UserName
        {
            get { return string.Empty; }
        }

        public string EngineNo
        {
            get { return string.Empty; }
        }

        public string VinOrChassis
        {
            get { return string.Empty; }
        }

        public string Make
        {
            get { return string.Empty; }
        }

        public string RegisterNo
        {
            get { return string.Empty; }
        }

        public string LicenceNo
        {
            get { return "XMC167GP"; }
        }

        public string Product
        {
            get
            {
                return string.Empty;
            }
        }

        public string ReasonForApplication
        {
            get { return string.Empty; }
        }
        

        public string UserEmail
        {
            get
            {
                return "pennyl@lightstone.co.za";
            }
        }

        public string UserPhone
        {
            get
            {
                return null;
            }
        }

        public string Vin
        {
            get
            {
                return "SB1KV58E40F039277";
            }
        }


        public string UserFirstName
        {
            get
            {
                return "Penny";
            }
        }

        public string UserLastName
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public string SecurityCode
        {
            get
            {
                return "c99ef6d2-fdea-4a81-b15f-ff8251ac9050";
            }
        }
    }
}
