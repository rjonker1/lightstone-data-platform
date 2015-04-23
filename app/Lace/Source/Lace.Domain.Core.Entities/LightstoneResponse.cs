using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Json;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;
using Newtonsoft.Json;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstoneAutoResponse : IProvideDataFromLightstoneAuto
    {
        public LightstoneAutoResponse()
        {
        }

        public LightstoneAutoResponse(int carId, int year, string vin, string imageUrl, string quarter, string carFullName,
            string model, IRespondWithValuation vehicleValuation)
        {
            CarId = carId;
            Year = year;
            Vin = vin;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullName;
            Model = model;
            VehicleValuation = vehicleValuation;
        }

        [DataMember]
        public IAmLightstoneAutoRequest Request { get; private set; }
        [DataMember]
        public int? CarId { get; private set; }
        [DataMember]
        public int? Year { get; private set; }
        [DataMember]
        public string Vin { get; private set; }
        [DataMember]
        public string ImageUrl { get; private set; }
        [DataMember]
        public string Quarter { get; private set; }
        [DataMember]
        public string CarFullname { get; private set; }
        [DataMember]
        public string Model { get; private set; }
        [DataMember, JsonConverter(typeof(JsonTypeResolverConverter))]
        public IRespondWithValuation VehicleValuation { get; private set; }
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
    }
}
