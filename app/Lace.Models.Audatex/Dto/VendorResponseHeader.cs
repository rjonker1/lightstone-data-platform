using System;

namespace Lace.Models.Audatex.Dto
{
   // [Serializable]
    public class VendorResponseHeader
    {
        public string MsgTypeIdentifier { get; set; }

        public string Reference { get; set; }

        public VendorResponseHeader()
        {
            MsgTypeIdentifier = string.Empty;
            Reference = string.Empty;
        }
    }
}
