using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Lsp;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LspResponse : IProvideDataFromLspDecryption
    {
        public LspResponse(IRespondWithReturnProperties returnProperties, string decodedData)
        {
            ReturnProperties = returnProperties;
            DecodedData = decodedData;
        }

        [DataMember]
        public IRespondWithReturnProperties ReturnProperties { get; private set; }

        [DataMember]
        public string DecodedData { get; private set; }

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
