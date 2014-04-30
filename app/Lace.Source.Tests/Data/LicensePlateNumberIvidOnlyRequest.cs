using System;
using Lace.Request;

namespace Lace.Source.Tests.Data
{
    class LicensePlateNumberIvidOnlyRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string CompanyId
        {
            get
            {
                return string.Empty;
            }
        }

        public string ContractId
        {
            get
            {
                return string.Empty;
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
                return new string[] { "Ivid" };
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
            get
            {
                return "XMC167GP";
            }
        }

        public string Product
        {
            get { return string.Empty; }
        }

        public string ReasonForApplication
        {
            get { return string.Empty; }
        }

        public string UserEmail
        {
            get { throw new NotImplementedException(); }
        }

        public string UserPhone
        {
            get { throw new NotImplementedException(); }
        }

        public string Vin
        {
            get { throw new NotImplementedException(); }
        }


        public string UserFirstName
        {
            get { throw new NotImplementedException(); }
        }

        public string UserLastName
        {
            get { throw new NotImplementedException(); }
        }


        public string SecurityCode
        {
            get { throw new NotImplementedException(); }
        }
    }
}
