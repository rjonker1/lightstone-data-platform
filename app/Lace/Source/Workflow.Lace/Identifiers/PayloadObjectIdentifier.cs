using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class PayloadObjectIdentifier
    {
        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        public PayloadObjectIdentifier(string metaData, string payload, string message)
        {
            MetaData = metaData;
            Payload = payload;
            Message = message;
        }

        public PayloadObjectIdentifier()
        {

        }

        public static PayloadObjectIdentifier Generate(string metaData, string payload, string message)
        {
            return new PayloadObjectIdentifier(metaData,  payload, message);
        }

        //private static object ValidateJson(string json)
        //{
        //    var token = JToken.Parse(json);
        //    return token is JArray ? JArray.Parse(json) : json.JsonToObject();
        //}

        //private static string GetJArrayString(string json)
        //{
        //    var token = JToken.Parse(json);

        //    if (token is JArray)
        //    {
        //        var jarray = new JArray();
        //        jarray.Add(JArray.Parse(json.JsonToObject().ObjectToJson()));
        //        return jarray.ToString(Formatting.None);
        //    }

        //    return JObject.Parse(json).ToString(Formatting.None);

        //}
    }
}
