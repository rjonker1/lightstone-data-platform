using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public interface IDetermineUserAgent
    {
        List<ApiRequestUserAgentDto> UserAgents { get; }
        void DetermineUserAgent(List<string> fullUserAgentList);
    }
    public abstract class AbstractDeterminator : IDetermineUserAgent
    {
        private readonly IDetermineUserAgent _next;
        private readonly Core.Enums.UserAgent _userAgent;

        protected AbstractDeterminator(Core.Enums.UserAgent userAgent, List<ApiRequestUserAgentDto> userAgents)
        {
            UserAgents = userAgents;
            _userAgent = userAgent;
        }

        protected AbstractDeterminator(IDetermineUserAgent next, Core.Enums.UserAgent userAgent, List<ApiRequestUserAgentDto> userAgents)
            : this(userAgent, userAgents)
        {
            _next = next;
        }

        public void DetermineUserAgent(List<string> fullUserAgentList)
        {
            var check = fullUserAgentList.Where(w => fullUserAgentList.Count(_userAgent.Checks())).ToList();
            UserAgents.Add(new ApiRequestUserAgentDto(_userAgent.ToString(), check.Count));
        }

        public List<ApiRequestUserAgentDto> UserAgents { get; private set; }
    }
}