using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Tests.Data;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberAudatexOnlyRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
            }
        }

        public Guid Token
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
            get { return null; }
        }


        public string SecurityCode
        {
            get
            {
                return "c99ef6d2-fdea-4a81-b15f-ff8251ac9050";
            }
        }

        public IField[] Fields
        {
            get
            {
                return new IField[]{ new AccidentClaimField() };
            }
        }
    }
}
