using System;
using Lace.Request;

namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    public class MockLaceRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
            }
        }


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
            get
            {
                return string.Empty;
            }
        }

        public string LicenceNo
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string Product
        {
            get
            {
                return "XMC167GP";
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
                return null;
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
