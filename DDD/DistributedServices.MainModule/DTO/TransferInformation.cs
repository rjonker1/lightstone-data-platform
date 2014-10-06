using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     Transfer Information DTO
    /// </summary>
    [DataContract(Name = "TransferInformation", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class TransferInformation
    {
        /// <summary>
        ///     Origin account number in this transfer information
        /// </summary>
        [DataMember(Name = "OriginAccountNumber")]
        public string OriginAccountNumber { get; set; }

        /// <summary>
        ///     Destination account number in this transfer information
        /// </summary>
        [DataMember(Name = "DestinationAccountNumber")]
        public string DestinationAccountNumber { get; set; }

        /// <summary>
        ///     Amount of money for this transfer
        /// </summary>
        [DataMember(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}