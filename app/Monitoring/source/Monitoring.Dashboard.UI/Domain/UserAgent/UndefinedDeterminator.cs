using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class UndefinedDeterminator : IDetermineUserAgent
    {
        public ApiRequestUserAgentDto DetermineUserAgent(List<string> fullUserAgentList)
        {
            return new ApiRequestUserAgentDto(Core.Enums.UserAgent.Undefined.ToString(), fullUserAgentList.Count);
        }
    }
}