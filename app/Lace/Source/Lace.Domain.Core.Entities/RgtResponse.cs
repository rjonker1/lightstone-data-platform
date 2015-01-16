using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class RgtResponse : IProvideDataFromRgt
    {
        public RgtResponse()
        {
        }

        public RgtResponse(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy,
            string acceleration, string torque, string emissions,
            string engineSize, string bodyShape, string fuelType, string transmissionType, string carFullName,
            string colour, string rainSensorWipers, string headsUpDisplay,
            string vehicleType, string model, string make, string carType)
        {
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            ModelType = modelType;
            TopSpeed = topSpeed;
            Kilowatts = kilowatts;
            FuelEconomy = fuelEconomy;
            Acceleration = acceleration;
            Torque = torque;
            Emissions = emissions;
            EngineSize = engineSize;
            BodyShape = bodyShape;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            CarFullname = carFullName;
            Colour = colour;
            RainSensorWindscreenWipers = rainSensorWipers;
            HeadUpDisplay = headsUpDisplay;
            VehicleType = vehicleType;
            Model = model;
            Make = make;
            CarType = carType;
        }

        [DataMember]
        public string Manufacturer { get; private set; }
        [DataMember]
        public int ModelYear { get; private set; }
        [DataMember]
        public string ModelType { get; private set; }
        [DataMember]
        public string TopSpeed { get; private set; }
        [DataMember]
        public string Kilowatts { get; private set; }
        [DataMember]
        public string FuelEconomy { get; private set; }
        [DataMember]
        public string Acceleration { get; private set; }
        [DataMember]
        public string Torque { get; private set; }
        [DataMember]
        public string Emissions { get; private set; }
        [DataMember]
        public string EngineSize { get; private set; }
        [DataMember]
        public string BodyShape { get; private set; }
        [DataMember]
        public string FuelType { get; private set; }
        [DataMember]
        public string TransmissionType { get; private set; }
        [DataMember]
        public string CarFullname { get; private set; }
        [DataMember]
        public string Colour { get; private set; }
        [DataMember]
        public string RainSensorWindscreenWipers { get; private set; }
        [DataMember]
        public string HeadUpDisplay { get; private set; }
        [DataMember]
        public string VehicleType { get; private set; }
        [DataMember]
        public string Model { get; private set; }
        [DataMember]
        public string Make { get; private set; }
        [DataMember]
        public string CarType { get; private set; }
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
