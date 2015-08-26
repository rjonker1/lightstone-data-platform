using System;
using System.Xml.Serialization;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Dto
{
    [Serializable]
    [XmlRoot(ElementName = "MsgData")]
    public class VendorResponse
    {
        public VendorResponseHeader Header { get; set; }

        public VendorResponseBody Body { get; set; }
    }
}
