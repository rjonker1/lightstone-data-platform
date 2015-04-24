using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.Domain.Entities.Requests
{
    public class LicensePlateRequest : IAmLicensePlateRequest
    {

        public LicensePlateRequest(IHaveUser user, IHaveVehicle vehicle, IHaveContract contract,
            IHavePackageForRequest package, IHaveRequestContext context, DateTime requestDate)
        {
            User = user;
            Vehicle = vehicle;
            Contract = contract;
            Package = package;
            Request = context;
            RequestDate = requestDate;
        }
        public IHaveUser User { get; private set; }

        public IHaveVehicle Vehicle { get; private set; }

        public IHaveContract Contract { get; private set; }

        public IHavePackageForRequest Package { get; private set; }

        public IHaveRequestContext Request { get; private set; }

        public DateTime RequestDate { get; private set; }

    }

    public class BusinessRequest : IAmBusinessRequest
    {
        public IHaveBusiness Business { get; private set; }

        public IHaveUser User { get; private set; }

        public IHaveContract Contract { get; private set; }

        public IHavePackageForRequest Package { get; private set; }

        public IHaveRequestContext Request { get; private set; }

        public DateTime RequestDate { get; private set; }
    }

    public class PropertyRequest : IAmPropertyRequest
    {
        public PropertyRequest(IHaveProperty property, IHaveUser user, IHaveContract contract,
            IHavePackageForRequest package, IHaveRequestContext request, DateTime requestDate)
        {
            Property = property;
            User = user;
            Contract = contract;
            Package = package;
            Request = request;
            RequestDate = requestDate;
        }

        public IHaveProperty Property { get; private set; }

        public IHaveUser User { get; private set; }

        public IHaveContract Contract { get; private set; }

        public IHavePackageForRequest Package { get; private set; }

        public IHaveRequestContext Request { get; private set; }

        public DateTime RequestDate { get; private set; }


    }

    public class DriversLicenseRequest : IAmDriversLicenseRequest
    {

        public IHaveDriversLicense DriversLicense { get; private set; }

        public IHaveContract Contract { get; private set; }
        public IHaveUser User { get; private set; }

        public IHavePackageForRequest Package { get; private set; }

        public IHaveRequestContext Request { get; private set; }

        public DateTime RequestDate { get; private set; }
    }

    public class User : IHaveUser
    {

        public User(Guid userId, string userName, string firstName)
        {
            UserFirstName = firstName;
            UserId = userId;
            UserName = userName;
        }

        public string UserFirstName { get; private set; }

        public Guid UserId { get; private set; }

        public string UserName { get; private set; }
    }


    public class RequestContext : IHaveRequestContext
    {
        public RequestContext(Guid requestId, Lace.Domain.Core.Requests.DeviceTypes fromDevice, string fromIpAddress, string osVersion, Lace.Domain.Core.Requests.SystemType system)
        {
            RequestId = requestId;
            FromDeviceType = fromDevice;
            FromIpAddress = fromIpAddress;
            OsVersion = osVersion;
            System = system;
        }

        public Lace.Domain.Core.Requests.DeviceTypes FromDeviceType { get; private set; }

        public string FromIpAddress { get; private set; }

        public string OsVersion { get; private set; }

        public Guid RequestId { get; private set; }

        public Lace.Domain.Core.Requests.SystemType System { get; private set; }
    }

    public class Vehicle : IHaveVehicle
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

    public class DriversLicense : IHaveDriversLicense
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

    public class Fica : IHaveFica
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

    public class Contract : IHaveContract
    {
        public Contract(long contractVersion, string accountNumber, Guid contractId)
        {
            ContractVersion = contractVersion;
            AccountNumber = accountNumber;
            ContractId = contractId;
        }
        public string AccountNumber { get; private set; }

        public Guid ContractId { get; private set; }

        public long ContractVersion { get; private set; }
    }

    public class RequestPackage : IHavePackageForRequest
    {
        public RequestPackage(string action, IAmDataProvider[] dataProviders, Guid id, string name, long version)
        {
            Action = action;
            DataProviders = dataProviders;
            Id = id;
            Name = name;
            Version = version;
        }

        public string Action { get; private set; }

        public Guid Id { get; private set; }

        public IAmDataProvider[] DataProviders { get; private set; }
        public string Name { get; private set; }

        public long Version { get; private set; }
    }

    public class Property : IHaveProperty
    {
        public Property(string trackingNumber, int maxNumberOfRows, Guid userid, string idNumber)
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
}