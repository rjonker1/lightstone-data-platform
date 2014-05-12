﻿using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Tests.Data;

namespace Lace.Source.Tests.Data
{
    class LicensePlateNumberIvidOnlyRequest : ILaceRequest
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
