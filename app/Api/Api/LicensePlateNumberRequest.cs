using System;
using DataPlatform.Shared.Public.Entities;
using Lace.Request;

namespace Api
{
    public class LicensePlateNumberRequest : ILaceRequest
    {
        public LicensePlateNumberRequest(IPackage package, ILaceRequestUserInformation user, ILaceRequestContext context, ILaceRequestVehicleInformation vehicle, IProvideRequestAggregation requestAggregation)
        {
            Package = package;
            User = user;
            Context = context;
            Vehicle = vehicle;
            RequestAggregation = requestAggregation;
        }

        public LicensePlateNumberRequest(string licenceNo)
        {
            Vehicle = new Vechicle(licenceNo, "WAUZZZ8K8DA074674");
        }

        public IPackage Package { get; set; }
        //{
        //    get
        //    {
        //        return new Package()
        //        {
        //            DataSets = new List<IDataSet>() {new DataSet()},
        //            Id = 0,
        //            Name = "License Plate Number Lookup"
        //        };
        //    }
        //}

        public ILaceRequestUserInformation User { get; private set; }

        public ILaceRequestContext Context { get; private set; }

        public ILaceRequestVehicleInformation Vehicle { get; private set; }

        public IProvideRequestAggregation RequestAggregation { get; private set; }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }


       
    }

    public class User : ILaceRequestUserInformation
    {

        public Guid UserId { get; private set; }

        public Guid AggregateId { get; private set; }

        public string UserName { get; private set; }

        public string UserFirstName { get; private set; }

        public string UserLastName { get; private set; }

        public string UserEmail { get; private set; }

        public string UserPhone { get; private set; }
    }

    public class Context : ILaceRequestContext
    {

        public string Product { get; private set; }

        public string ReasonForApplication { get; private set; }

        public string SecurityCode
        {
            get
            {
                return "c99ef6d2-fdea-4a81-b15f-ff8251ac9050";
            }
        }
    }

    public class Vechicle : ILaceRequestVehicleInformation
    {
        public Vechicle()
        {
        }

        public Vechicle(string licenseNo, string vinNo)
        {
            LicenceNo = licenseNo;
            Vin = vinNo;
        }

        public string EngineNo { get; private set; }

        public string VinOrChassis { get; private set; }

        public string Make { get; private set; }

        public string RegisterNo { get; private set; }

        public string LicenceNo { get; private set; }

        public string Vin { get; private set; }
    }
}