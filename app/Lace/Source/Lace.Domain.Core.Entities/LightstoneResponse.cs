﻿using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstoneResponse : IProvideDataFromLightstone
    {
        public LightstoneResponse()
        {
        }

        public LightstoneResponse(int carId, int year, string vin, string imageUrl, string quarter, string carFullName,
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
        [DataMember]
        public IRespondWithValuation VehicleValuation { get; private set; }
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
