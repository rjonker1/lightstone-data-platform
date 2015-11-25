using System.Collections.Generic;
using System.Linq;
using Api.Infrastructure.Dto;

namespace Api.Infrastructure.UserAgent
{
    public sealed class UndefinedDeterminator : IDetermineUserAgent
    {
        public void DetermineUserAgent(List<string> fullUserAgentList, List<ApiRequestUserAgentDto> userAgents)
        {
            var definedCount = userAgents.Where(w => w.UserAgent != Enums.UserAgent.Undefined).Sum(s => s.Value);
            userAgents.Add(new ApiRequestUserAgentDto(Enums.UserAgent.Undefined.ToString(), (fullUserAgentList.Count - definedCount), Enums.UserAgent.Undefined));
        }
    }
}