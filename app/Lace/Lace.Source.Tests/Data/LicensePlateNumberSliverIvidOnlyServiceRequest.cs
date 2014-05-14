using System.Collections.Generic;
using Lace.Request;
using System;
using Lace.Tests.Data;

namespace Lace.Source.Tests.Data
{
    class LicensePlateNumberSliverIvidOnlyServiceRequest : ILaceRequest
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

        public string LicensePlateNumber
        {
            get
            {
                return "XMC167GP";
            }
        }

      
        public string UserName
        {
            get { return "rudi@customapp.co.za"; }
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
            get { return null; }
        }

        public string UserPhone
        {
            get { return null; }
        }

        public string Vin
        {
            get { return null; }
        }


        public string UserFirstName
        {
            get { return null; }
        }

        public string UserLastName
        {
            get { return null; }
        }


        public string SecurityCode
        {
            get { return null; }
        }

        public IField[] Fields
        {
            get
            {
                return new List<IField>()
                {
                   new RegistrationField(),
                   new VinField(),
                   new EngineField(),
                   new MakeDescription()

                }.ToArray();
            }
        }
    }
}
