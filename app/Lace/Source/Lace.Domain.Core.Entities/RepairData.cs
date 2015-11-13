using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Newtonsoft.Json;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class RepairDataResponse : IRespondWithRepairData
    {
        public RepairDataResponse()
        {
            
        }

        public RepairDataResponse(string vehicleDescription, string cost, int date, string driversName, string location)
        {
            VehicleDescription = vehicleDescription;
            Cost = cost;
            Date = date;
            DriversName = driversName;
            Location = location;
        }

        [DataMember]
        [JsonProperty(PropertyName = "Vehicle Desc")]
        public string VehicleDescription { get; private set; }

        [DataMember]
        public string Cost { get; private set; }

        [DataMember]
        public int Date { get; private set; }

        [DataMember]
        [JsonProperty(PropertyName = "dName")]
        public string DriversName { get; private set; }

        [DataMember]
        public string Location { get; private set; }

        [DataMember]
        [JsonProperty(PropertyName = "CarID")]
        public int CarId { get; private set; }
    }
}
