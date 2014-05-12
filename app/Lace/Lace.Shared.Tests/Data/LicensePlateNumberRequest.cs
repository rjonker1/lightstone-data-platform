﻿using System;
using System.Collections.Generic;
using Lace.Request;

namespace Lace.Shared.Tests.Data
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
                return new IField[0];
            }
        }
    }
}
