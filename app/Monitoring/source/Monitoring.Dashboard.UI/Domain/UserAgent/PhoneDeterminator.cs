using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class PhoneDeterminator : AbstractDeterminator
    {
        public PhoneDeterminator()
            : base(Core.Enums.UserAgent.Phone,)
        {
            
        }

        public PhoneDeterminator(IDetermineUserAgent next, List<ApiRequestUserAgentDto> userAgents) : base(next, Core.Enums.UserAgent.Phone, userAgents)
        {
            
        }
    }
}