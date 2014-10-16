using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     Paged criteria
    /// </summary>
    [DataContract(Name = "PagedCriteria", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class PagedCriteria
    {
        /// <summary>
        ///     Index of page
        /// </summary>
        [DataMember(Name = "PageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        ///     Number of elements in each page
        /// </summary>
        [DataMember(Name = "PageCount")]
        public int PageCount { get; set; }
    }
}