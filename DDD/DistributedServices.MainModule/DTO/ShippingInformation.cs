using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     Shipping information DTO
    /// </summary>
    [DataContract(Name = "ShippingInformation", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class ShippingInformation
    {
        /// <summary>
        ///     Get or set a shipping name
        /// </summary>
        [DataMember(Name = "ShippingName")]
        public string ShippingName { get; set; }

        /// <summary>
        ///     Get or set shipping address
        /// </summary>
        [DataMember(Name = "ShippingAddress")]
        public string ShippingAddress { get; set; }

        /// <summary>
        ///     Get or set shipping city
        /// </summary>
        [DataMember(Name = "ShippingCity")]
        public string ShippingCity { get; set; }

        /// <summary>
        ///     Get or set shipping zip
        /// </summary>
        [DataMember(Name = "ShippingZip")]
        public string ShippingZip { get; set; }
    }
}