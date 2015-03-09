using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Lsp;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LspResponse : IProvideDataFromLspDecryption
    {
        public LspResponse(IRespondWithLspInformation lspInformation, string data)
        {
            LspInformation = lspInformation;


            Data = data;
        }
       

         [DataMember]
        public IRespondWithLspInformation LspInformation { get; private set; }

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
