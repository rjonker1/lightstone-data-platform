using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class UndefinedDeterminator : IDetermineUserAgent
    {
        public void DetermineUserAgent(List<string> fullUserAgentList, List<ApiRequestUserAgentDto> userAgents)
        {
            var definedCount = userAgents.Where(w => w.UserAgent != Core.Enums.UserAgent.Undefined).Sum(s => s.Value);
            userAgents.Add(new ApiRequestUserAgentDto(Core.Enums.UserAgent.Undefined.ToString(), (fullUserAgentList.Count - definedCount), Core.Enums.UserAgent.Undefined));
        }
    }
}