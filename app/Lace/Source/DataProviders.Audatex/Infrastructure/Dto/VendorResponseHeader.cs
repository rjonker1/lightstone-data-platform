﻿namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Dto
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
