using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class VehicleSpecificInformation : IProvideVehicleSpecificInformation
    {
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

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }
    }
}
