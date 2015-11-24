using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
    [DataContract]
    public class DataProviders
    {
        [DataMember]
        public int Name { get; set; }

        [DataMember]
        public string DataProviderJson { get; set; }

        //[DataMember]
        //public JValue Request
        //{

        //    get
        //    {
        //        var obj = !string.IsNullOrEmpty(RequestJson) ? RequestJson.JsonToObject<dynamic>() ?? new RequestField() : new RequestField();
        //        return obj;
        //    }
        //}
        //[DataMember]
        //public string DataProvider { get; set; }

        //[DataMember]
        //public DataProviderContainer Container { get; set; }
    }

    //[DataContract]
    //public class DataProviderContainer
    //{
    //   [DataMember]
    //    public List<DataProviderObject> DataProvider { get; set; }
    //}

    //[DataContract]
    //public class DataProviderObject
    //{
    //    [DataMember]
    //    public int Name { get; set; }

    //    [DataMember]
    //    public string RequestJson { get; set; }

    //    [DataMember]
    //    public RequestField Request {

    //        get
    //        {
    //            var obj =  !string.IsNullOrEmpty(RequestJson) ? RequestJson.JsonToObject<dynamic>() ?? new RequestField() : new RequestField();
    //            return obj;
    //        }
    //    }
    //}

}