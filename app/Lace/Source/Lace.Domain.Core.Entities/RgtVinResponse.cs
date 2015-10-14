using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class RgtVinResponse : IProvideDataFromRgtVin
    {
        public RgtVinResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
        }
        
        public static RgtVinResponse Empty()
        {
            return new RgtVinResponse();
        }

        private RgtVinResponse(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public static RgtVinResponse WithState(DataProviderResponseState state)
        {
            return new RgtVinResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }


        public RgtVinResponse(string color, int month, int price, int quarter, int carId, string vehicleMake,
            string vechicleModel, string vehicleType, string vin, int year)
        {
            Colour = color;
            Month = month;
            Price = price;
            Quarter = quarter;
            CarId = carId;
            VehicleMake = vehicleMake;
            VehicleModel = vechicleModel;
            VehicleType = vehicleType;
            Vin = vin;
            Year = year;
        }

        public void SetCarName()
        {
            CarFullname = string.Format("{0} {1}", VehicleMake, VehicleModel);
        }

        [DataMember]
        public IAmRgtVinRequest Request { get; private set; }

        [DataMember]
        public string Vin { get; private set; }

        [DataMember]
        public string VehicleMake { get; private set; }

        [DataMember]
        public string VehicleType { get; private set; }

        [DataMember]
        public string VehicleModel { get; private set; }

        [DataMember]
        public int? Year { get; private set; }

        [DataMember]
        public int? Month { get; private set; }

        [DataMember]
        public int? Quarter { get; private set; }

        [DataMember]
        public int CarId { get; private set; }

        [DataMember]
        public decimal? Price { get; private set; }

        [DataMember]
        public string Colour { get; private set; }

        [DataMember]
        public string CarFullname { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
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