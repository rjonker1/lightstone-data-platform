using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.LightstoneProperty;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstonePropertyResponse : IProvideDataFromLightstoneProperty
    {
        public LightstonePropertyResponse(IRespondWithLightstonePropertyInformation lightstonePropertyInformation, string data)
        {
            LightstonePropertyInformation = lightstonePropertyInformation;
            Data = data;
        }
       

        [DataMember]
        public IRespondWithLightstonePropertyInformation LightstonePropertyInformation { get; private set; }

        [DataMember]
        public string Data { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }
}
