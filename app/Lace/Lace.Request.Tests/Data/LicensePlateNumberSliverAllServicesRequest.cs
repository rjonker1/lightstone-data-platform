using System;
using System.Collections.Generic;
using Lace.Tests.Data;

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

        public Guid Token
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

        public IField[] Fields
        {
            get
            {
                return new List<IField>()
                {
                    //Ivid
                    new RegistrationField(),
                    new VinField(),
                    new EngineField(),
                    new MakeDescription(),

                    //Ivid title holder
                    new BankNameField(),
                    new AccountNumberField(),
                    new AccountOpenDateField(),
                    new AccountClosedDateField(),

                    //rgt vin
                    new VehicleMakeField(),
                    new ColourField(),
                    new PriceField(),

                    //audatex
                    new AccidentClaimField()

                }.ToArray();
            }
        }
    }
}
