using System;
using Lace.Request;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberIvidTitleHolderOnlyRequest : ILaceRequest
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
                return new string[] {"IvidTitleHolder"};
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
                return "AHT31UNK408007735";
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
            get { return null;}
        }


        public string SecurityCode
        {
            get { return null;}
        }
    }
}
