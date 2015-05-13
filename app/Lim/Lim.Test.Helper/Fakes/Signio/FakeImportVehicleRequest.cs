using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lim.Test.Helper.Fakes.Signio
{

    [DataContract]
    public class ImportVehicleRequest
    {

        public ImportVehicleRequest(DateTime dateTime, User user, Vehicle vehicle, Stock stock)
        {
            DateTime = dateTime;
            User = user;
            Vehicle = vehicle;
            Stock = stock;
        }

        [DataMember]
        public DateTime DateTime { get; private set; }

        [DataMember]
        public User User { get; private set; }

        [DataMember]
        public Vehicle Vehicle { get; private set; }

        [DataMember]
        public Stock Stock { get; private set; }
    }

    [DataContract]
    public class User
    {
        public User(string username, Guid uuid)
        {
            UserName = username;
            Uuid = uuid;

        }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public Guid Uuid { get; set; }

    }

    [DataContract]
    public class Vehicle
    {

        public Vehicle()
        {
        }

        public Vehicle(IList<string> scanRequest)
        {
            LicenseNumber = scanRequest[6];
            RegistrationNumber = scanRequest[7];
            VinNumber = scanRequest[12];
            EngineNumber = scanRequest[13];
            SmartId = "0";
            Segment = scanRequest[8];
            Manufacturer = scanRequest[9];
            Model = scanRequest[10];
            Year = "0";
            Colour = scanRequest[11];
            LicenseExpiryDate = scanRequest[14];
            RetailValue = "0.00";
        }

        public Vehicle(string licenseNumber, string registrationNumber, string vinNumber, string engineNumber,
            string smartId, string segment, string manufacturer, string model,
            string year, string colour, string licenseExpiryDate, string retailValue)
        {
            LicenseNumber = licenseNumber;
            RegistrationNumber = registrationNumber;
            VinNumber = vinNumber;
            EngineNumber = engineNumber;
            SmartId = smartId;
            Segment = segment;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Colour = colour;
            LicenseExpiryDate = licenseExpiryDate;
            RetailValue = retailValue;
        }

        [DataMember]
        public string LicenseNumber { get; private set; }

        [DataMember]
        public string RegistrationNumber { get; private set; }

        [DataMember]
        public string VinNumber { get; private set; }

        [DataMember]
        public string EngineNumber { get; private set; }

        [DataMember]
        public string SmartId { get; private set; } //Car ID

        [DataMember]
        public string Segment { get; private set; }

        [DataMember]
        public string Manufacturer { get; private set; }

        [DataMember]
        public string Model { get; private set; }

        [DataMember]
        public string Year { get; private set; }

        [DataMember]
        public string Colour { get; private set; }

        [DataMember]
        public string LicenseExpiryDate { get; private set; }

        [DataMember]
        public string RetailValue { get; private set; }


        //public void SetSmartId(string smartId)
        //{
        //    SmartId = smartId;
        //}

        //public Vehicle EnsureAvailableCarDetail(Car car)
        //{

        //    if (!_carExists(car.CarId)) return this;

        //    SmartId = Convert.ToString(car.CarId);
        //    RetailValue = Convert.ToString(car.SalePrice);
        //    Year = Convert.ToString(car.YearId);

        //    Manufacturer = car.MakeName ?? Manufacturer;
        //    Model = car.CarModel ?? Model;
        //    Colour = car.Colour ?? Colour;

        //    return this;
        //}

        private readonly Func<int, bool> _carExists = i => i > 0;

    }

    [DataContract]
    public class Stock
    {
        public Stock(char verified, bool intoStock)
        {
            Verified = verified;
            IntoStock = intoStock;
        }

        [DataMember]
        public char Verified { get; private set; }

        [DataMember]
        public bool IntoStock { get; private set; }
    }
}