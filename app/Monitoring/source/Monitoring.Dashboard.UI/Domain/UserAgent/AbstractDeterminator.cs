using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public interface IDetermineUserAgent
    {
        void DetermineUserAgent(List<string> fullUserAgentList, List<ApiRequestUserAgentDto> userAgents);
    }
    public abstract class AbstractDeterminator : IDetermineUserAgent
    {
        private readonly IDetermineUserAgent _next;
        private readonly Core.Enums.UserAgent _userAgent;

        protected AbstractDeterminator(Core.Enums.UserAgent userAgent)
        {
            _userAgent = userAgent;
        }

        protected AbstractDeterminator(IDetermineUserAgent next, Core.Enums.UserAgent userAgent)
            : this(userAgent)
        {
            _next = next;
        }

        public void DetermineUserAgent(List<string> fullUserAgentList, List<ApiRequestUserAgentDto> userAgents)
        {
            var check = fullUserAgentList.Where(w => w.Exists(_userAgent.Checks())).ToList();
            userAgents.Add(new ApiRequestUserAgentDto(_userAgent.ToString(), check.Count,_userAgent));

            if (_next != null)
                _next.DetermineUserAgent(fullUserAgentList,userAgents);
        }
    }
}