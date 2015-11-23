using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Models.DataProvider;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class RequestTypeDto
    {
        public RequestTypeDto()
        {

        }

        public RequestTypeDto(ExecutionBegan @event)
        {
            RequestFields = @event.Payload.Pacakge.DataProviders.Select(s => s.Name).ToList();
        }

        [DataMember]
        public List<string> RequestFields { get; set; }
    }
}