using System.Runtime.Serialization;
namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{

    [DataContract]
    public class Results
    {
        public Results()
        {
            
        }

        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool HasResults { get; set; }

        //{"Results":{"ElapsedTime":"00:00:01.2286714","Name":"IVIDVerify_E_WS"},"HasResults":true}
    }
}