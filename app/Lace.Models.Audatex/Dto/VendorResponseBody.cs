using System;
using System.Collections.Generic;

namespace Lace.Models.Audatex.Dto
{
   // [Serializable]
    public class VendorResponseBody
    {
        public List<HistoryCheckResponse> EntityList { get; set; }

        public VendorResponseBody()
        {
            EntityList = new List<HistoryCheckResponse>();
        }
    }
}
