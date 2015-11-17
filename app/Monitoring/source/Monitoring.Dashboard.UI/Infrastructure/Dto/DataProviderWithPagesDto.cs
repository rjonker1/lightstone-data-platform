using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    [Serializable]
    [DataContract]
    public class DataProviderWithPagesDto
    {
        public DataProviderWithPagesDto()
        {
            
        }

        public DataProviderWithPagesDto(List<DataProviderDto> response)
        {
            Response = response;
            Pages = new List<short>();
        }

        public void SetPages(int rows, int pageSize)
        {
            var pages = Math.Ceiling(decimal.Divide((rows > 0 ? rows : 1), (pageSize > 0 ? pageSize : 1)));
            Pages = new List<short>();
            for (short i = 1; i <= pages; i++)
            {
                Pages.Add(i);
            }
        }

        [DataMember]
        public List<short> Pages { get; private set; }  
        [DataMember]
        public List<DataProviderDto> Response { get; private set; }
    }
}