using System.Collections.Generic;

namespace Lace.Models.Audatex.Dto
{
    public class VendorResponseBody
    {
        public List<HistoryCheckResponse> EntityList { get; set; }

        public VendorResponseBody()
        {
            EntityList = new List<HistoryCheckResponse>();
        }
    }
}
