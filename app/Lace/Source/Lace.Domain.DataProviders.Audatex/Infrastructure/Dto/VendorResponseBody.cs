using System;
using System.Collections.Generic;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Dto
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
