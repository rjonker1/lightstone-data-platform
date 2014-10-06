using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     Publisher information
    /// </summary>
    [DataContract(Name = "PublisherInformation", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class PublisherInformation
    {
        /// <summary>
        ///     A publisher name criteria
        /// </summary>
        [DataMember(Name = "PublisherName")]
        public string PublisherName { get; set; }

        /// <summary>
        ///     A description criteria
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description { get; set; }
    }
}