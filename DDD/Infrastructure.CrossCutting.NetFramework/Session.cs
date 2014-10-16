using System.Runtime.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    [DataContract]
    public class Session
    {
        #region Properties

        //[Display(ResourceType = typeof(ApplicationResources), Name = "User")]
        //[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "ValidationFieldRequired")]
        //[StringLength(11, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "ValidationFieldMaxLenght")]
        [DataMember]
        public string User { get; set; }

        //[Display(ResourceType = typeof(ApplicationResources), Name = "Password")]
        //[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "ValidationFieldRequired")]
        //[StringLength(10, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "ValidationFieldMaxLenght")]
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ConnectionString { get; set; }

        [DataMember]
        public string IdCache { get; set; }

        [DataMember]
        public int[] Permissions { get; set; }

        #endregion
    }
}