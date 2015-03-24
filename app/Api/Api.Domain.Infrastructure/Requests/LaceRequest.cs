using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Api.Domain.Infrastructure.Requests
{
    public class LaceRequest : ILaceRequest
    {
        public IProvideCoOrdinateInformationForRequest CoOrdinates { get; private set; }

        public IProvideContextForRequest Context { get; private set; }

        public IProvideDriversLicenseInformationForRequest DriversLicense { get; private set; }

        public IProvideFicaInformationForRequest Fica { get; private set; }

        public IProvideJisInformation Jis { get; private set; }

        public IPackage Package { get; private set; }
        public IProvidePropertyInformationForRequest Property { get; private set; }
        public IProvideBusinessInformationForRequest Business { get; private set; }

        public IProvideRequestAggregation RequestAggregation { get; private set; }

        public DateTime RequestDate { get; private set; }

        public IProvideUserInformationForRequest User { get; private set; }

        public IProvideVehicleInformationForRequest Vehicle { get; private set; }

        public void LicensePlateNumberRequest(IPackage package, IProvideUserInformationForRequest user,
            IProvideContextForRequest context, IProvideVehicleInformationForRequest vehicle,
            IProvideRequestAggregation requestAggregation)
        {
            Package = package;
            User = user;
            Context = context;
            Vehicle = vehicle;
            RequestAggregation = requestAggregation;
            RequestDate = DateTime.UtcNow;
        }

        public void DriversLicenseRequest(IPackage package,
            IProvideDriversLicenseInformationForRequest driversLicense, IProvideRequestAggregation aggregation)
        {
            DriversLicense = driversLicense;
            Package = package;
            RequestAggregation = aggregation;
        }

        public void FicaRequest(IPackage package,
            IProvideFicaInformationForRequest fica,IProvideRequestAggregation aggregation)
        {
            Fica = fica;
            Package = package;
            RequestAggregation = aggregation;
        }

        public void PropertyRequest(IPackage package, IProvideUserInformationForRequest user, IProvidePropertyInformationForRequest property, IProvideRequestAggregation aggregation)
        {
            Package = package;
            User = user;
            RequestAggregation = aggregation;
            Property = property;
        }

        public void BusinessRequest(IPackage package, IProvideBusinessInformationForRequest business, IProvideRequestAggregation aggregation)
        {
            Package = package;
            //User = user;
            RequestAggregation = aggregation;
            Business = business;
        }
    }

    public class Business : IProvideBusinessInformationForRequest
    {
        public Business(string userToken, string companyName, string companyRegNumber, string companyVatNumber)
        {
            CompanyVatNumber = companyVatNumber;
            CompanyRegNumber = companyRegNumber;
            CompanyName = companyName;
            UserToken = userToken;
        }

        public string UserToken { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyRegNumber { get; private set; }
        public string CompanyVatNumber { get; private set; }
    }

    public class Property : IProvidePropertyInformationForRequest
    {

        public Property (string trackingNumber, int maxNumberOfRows, Guid userid, string idNumber)
        {
            IdCkOfOwner = idNumber;
            TrackingNumber = trackingNumber;
            MaxRowsToReturn = maxNumberOfRows;
            UserId = userid.ToString();
        }

        public string DeedTown { get; private set; }

        public string ErfNumber { get; private set; }

        public string EstateName { get; private set; }

        public string FarmName { get; private set; }

        public string IdCkOfOwner { get; private set; }

        public int MaxRowsToReturn { get; private set; }

        public string Municipality { get; private set; }

        public string OwnerName { get; private set; }

        public string Portion { get; private set; }

        public string Province { get; private set; }

        public string SectionalTitle { get; private set; }

        public string Street { get; private set; }

        public string StreetNumber { get; private set; }

        public string Suburb { get; private set; }

        public string TrackingNumber { get; private set; }

        public string Unit { get; private set; }

        public string UserId { get; private set; }
    }

    public class User : IProvideUserInformationForRequest
    {

        public User(Guid userId, string userName, string firstName)
        {
            UserFirstName = firstName;
            UserId = userId;
            UserName = userName;
        }

        public string UserEmail { get; private set; }

        public string UserFirstName { get; private set; }

        public Guid UserId { get; private set; }

        public string UserLastName { get; private set; }

        public string UserName { get; private set; }

        public string UserPhone { get; private set; }
    }

    public class Context : IProvideContextForRequest
    {
        public Context(string product, string reasonForApplication)
        {
            Product = product;
            ReasonForApplication = reasonForApplication;
        }

        public string Product { get; private set; }
        public string ReasonForApplication { get; private set; }

        public string SecurityCode { get; private set; }
    }

    public class Aggregation : IProvideRequestAggregation
    {
        public Aggregation(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }

    public class Vehicle : IProvideVehicleInformationForRequest
    {
        public Vehicle()
        {
            
        }

        public Vehicle(string engineNumber, string licenseNumber, string make, string registrationNumber,
            string vinNumber, string vinOrChassisNumber)
        {
            EngineNo = engineNumber;
            LicenceNo = licenseNumber;
            Make = make;
            RegisterNo = registrationNumber;
            Vin = vinNumber;
            VinOrChassis = vinOrChassisNumber;
        }

        public string EngineNo { get; private set; }

        public string LicenceNo { get; private set; }

        public string Make { get; private set; }

        public string RegisterNo { get; private set; }

        public string Vin { get; private set; }

        public string VinOrChassis { get; private set; }


        public void SetLicenseNo(string licenceNo)
        {
            LicenceNo = licenceNo;
        }

        public void SetMake(string make)
        {
            Make = make;
        }

        public void SetVinNumber(string vinNumber)
        {
            Vin = vinNumber;
        }
    }

    public class DriversLicense : IProvideDriversLicenseInformationForRequest
    {
        public DriversLicense(string registrationCode, string scanData, Guid userId, string userName)
        {
            RegistrationCode = registrationCode;
            ScanData = scanData;
            UserId = userId;
            Username = userName;
        }

        public string RegistrationCode { get; private set; }

        public string ScanData { get; private set; }

        public Guid UserId { get; private set; }

        public string Username { get; private set; }
    }

    public class Fica : IProvideFicaInformationForRequest
    {
        public Fica(int ficaTransactionId, long idNumber, Guid transactionToken, string username)
        {
            FicaTransactionId = ficaTransactionId;
            IdNumber = idNumber;
            TransactionToken = transactionToken;
            Username = username;
        }

        public int FicaTransactionId { get; private set; }

        public long IdNumber { get; private set; }

        public Guid TransactionToken { get; private set; }

        public string Username { get; private set; }
    }
}