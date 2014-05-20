using System;
using DataPlatform.Shared.Public.Entities;
using Lace.Request;

namespace Api
{
    public class LicensePlateNumberRequest : ILaceRequest
    {
        //public LicensePlateNumberRequest(string licenceNo, string[] sources)
        //{
        //    LicenceNo = licenceNo;
        //    Sources = sources;
        //    Vin = "WAUZZZ8K8DA074674";
        //}

        public LicensePlateNumberRequest(string licenceNo)
        {
            LicenceNo = licenceNo;
            Vin = "WAUZZZ8K8DA074674";
        }

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPhone { get; private set; }
        public string CompanyId { get; private set; }
        public string ContractId { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string EngineNo { get; private set; }
        public string VinOrChassis { get; private set; }
        public string Make { get; private set; }
        public string RegisterNo { get; private set; }
        public string LicenceNo { get; private set; }
        public string Product { get; private set; }
        public string ReasonForApplication { get; private set; }
        public string Vin { get; private set; }
        public string SecurityCode { get; private set; }
        //public string[] Sources { get; private set; }


        public Guid Token
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public IField[] Fields {
            get
            {

                return new IField[]
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
                };
              
            }
        }

    }

    //************
    //Ivid
    //************
    public class RegistrationField : IField
    {
        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Registration";
            }
        }
    }

    public class VinField : IField
    {

        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Vin";
            }
        }
    }

    public class EngineField : IField
    {

        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "Engine";
            }
        }
    }

    public class MakeDescription : IField
    {
        public int SourceId
        {
            get
            {
                return 1;
            }
        }

        public string Name
        {
            get
            {
                return "MakeDescription";
            }
        }
    }

    //************
    //Audatex
    //************
    public class AccidentClaimField : IField
    {
        public int SourceId
        {
            get
            {
                return 4;
            }
        }

        public string Name
        {
            get
            {
                return "AccidentClaims";
            }
        }
    }

    //************
    //Ivid title holder
    //************
    public class BankNameField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "BankName";
            }
        }
    }

    public class AccountNumberField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountNumber";
            }
        }
    }

    public class AccountOpenDateField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountOpenDate";
            }
        }
    }

    public class AccountClosedDateField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountClosedDate";
            }
        }
    }

    //************
    // RGT VIN
    //************
    public class VehicleMakeField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "VehicleMake";
            }
        }
    }

    public class ColourField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "Colour";
            }
        }
    }

    public class PriceField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "Price";
            }
        }
    }

}