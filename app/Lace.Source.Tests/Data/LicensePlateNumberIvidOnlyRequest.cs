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
            get { return null; }
        }

        public string EngineNo
        {
            get { return null; }
        }

        public string VinOrChassis
        {
            get { return null; }
        }

        public string Make
        {
            get { return null; }
        }

        public string RegisterNo
        {
            get { return null; }
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
            get { return null; }
        }

        public string ReasonForApplication
        {
            get { return null; }
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
