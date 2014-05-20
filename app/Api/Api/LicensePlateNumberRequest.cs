using System;
using System.Collections.Generic;
using Api.Modules;
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

        public Guid Token
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public IPackage Package
        {
            get
            {
                return new Package()
                {
                    DataSets = new List<IDataSet>() {new DataSet()},
                    Id = 0,
                    Name = "License Plate Number Lookup"
                };
            }
        }
    }
}