using System;
using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     Order information
    /// </summary>
    [DataContract(Name = "OrderInformation", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class OrderInformation
    {
        /// <summary>
        ///     Customer identifier of orders
        /// </summary>
        [DataMember(Name = "CustomerId")]
        public int CustomerId { get; set; }

        /// <summary>
        ///     Orders from this date
        /// </summary>
        [DataMember(Name = "DateTimeFrom")]
        public DateTime? DateTimeFrom { get; set; }

        /// <summary>
        ///     Orders to this date
        /// </summary>
        [DataMember(Name = "DateTimeTo")]
        public DateTime? DateTimeTo { get; set; }
    }
}