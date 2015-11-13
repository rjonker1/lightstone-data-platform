using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Extensions;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class VehicleSpecificInformation : IProvideVehicleSpecificInformation
    {
        private VehicleSpecificInformation()
        {
            ResponseState = DataProviderResponseState.NoRecords;
        }

        public VehicleSpecificInformation(string odometer, string color, string registrationNumber, string vinNumber,
            string licenseNumber,
            string engineNumber, string categoryDescription)
        {
            Odometer = odometer;
            Colour = color;
            RegistrationNumber = registrationNumber;
            VinNumber = vinNumber;
            LicenseNumber = licenseNumber;
            EngineNumber = engineNumber;
            CategoryDescription = categoryDescription;
        }

        public static VehicleSpecificInformation Empty()
        {
            return new VehicleSpecificInformation();
        }
        
        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public string Odometer { get; private set; }
        [DataMember]
        public string Colour { get; private set; }
        [DataMember]
        public string RegistrationNumber { get; private set; }
        [DataMember]
        public string VinNumber { get; private set; }
        [DataMember]
        public string LicenseNumber { get; private set; }
        [DataMember]
        public string EngineNumber { get; private set; }
        [DataMember]
        public string CategoryDescription { get; private set; }
        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }

        [DataMember]
        public bool Handled { get; private set; }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}
