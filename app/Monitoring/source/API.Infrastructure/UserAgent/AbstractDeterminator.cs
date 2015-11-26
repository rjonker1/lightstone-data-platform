using System.Collections.Generic;
using System.Linq;
using Api.Infrastructure.Dto;
using Api.Infrastructure.Enums;

namespace Api.Infrastructure.UserAgent
{
    public interface IDetermineUserAgent
    {
        void DetermineUserAgent(List<string> fullUserAgentList, List<ApiRequestUserAgentDto> userAgents);
    }
    public abstract class AbstractDeterminator : IDetermineUserAgent
    {
        private readonly IDetermineUserAgent _next;
        private readonly Enums.UserAgent _userAgent;

        protected AbstractDeterminator(Enums.UserAgent userAgent)
        {
            _userAgent = userAgent;
        }

        protected AbstractDeterminator(IDetermineUserAgent next, Enums.UserAgent userAgent)
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