using System.Runtime.Serialization;

namespace LightstoneApp.DistributedServices.MainModule.DTO
{
    /// <summary>
    ///     BankAccount information
    /// </summary>
    [DataContract(Name = "BankAccountInformation", Namespace = "LightstoneApp.DistributedServices.MainModuleService")]
    public class BankAccountInformation
    {
        /// <summary>
        ///     Bank Account number
        /// </summary>
        [DataMember(Name = "BankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        ///     Customer identifier owner of accounts
        /// </summary>
        [DataMember(Name = "CustomerName")]
        public string CustomerName { get; set; }
    }
}